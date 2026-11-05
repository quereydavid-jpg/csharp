
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using Piedra_papel_o_tijera_con_apuestas.Data;
using Piedra_papel_o_tijera_con_apuestas.Models;
using Piedra_papel_o_tijera_con_apuestas.Services;

namespace Piedra_papel_o_tijera_con_apuestas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JuegoController : ControllerBase
    {
        private readonly SupabaseCliente _supabase;
        private readonly Computadora _computadora = new Computadora();

        // Las partidas permanecen en el servidor.
        private static readonly ConcurrentDictionary<Guid, Juego> Partidas = new();

        public JuegoController(SupabaseCliente supabase)
        {
            _supabase = supabase;
        }

        // INICIAR PARTIDA
        [HttpPost("iniciar")]
        public IActionResult Iniciar([FromBody] SolicitudInicio solicitud)
        {
            string nombre = solicitud.Nombre?.Trim() ?? "";

            if (nombre.Length < 1 || nombre.Length > 20)
            {
                return BadRequest("El nombre debe tener entre 1 y 20 caracteres.");
            }

            Guid idPartida = Guid.NewGuid();

            Juego juego = new Juego(nombre);

            Partidas[idPartida] = juego;

            return Ok(new
            {
                idPartida,
                jugador = nombre,
                fichas = juego.Jugador.Fichas
            });
        }

        // JUGAR UNA RONDA
        [HttpPost("ronda")]
        public async Task<IActionResult> Ronda([FromBody] SolicitudRonda solicitud)
        {
            if (!Partidas.TryGetValue(solicitud.IdPartida, out Juego? juego))
            {
                return NotFound("No se encontró la partida.");
            }

            string jugada = solicitud.Jugada?.Trim().ToLower() ?? "";

            if (jugada != "piedra" && jugada != "papel" && jugada != "tijera")
            {
                return BadRequest("La jugada debe ser piedra, papel o tijera.");
            }

            if (solicitud.Apuesta < 1 || solicitud.Apuesta > juego.Jugador.Fichas)
            {
                return BadRequest("La apuesta no es válida.");
            }

            // La computadora elige en el servidor.
            Jugada jugadaComputadora = _computadora.ElegirJugada();

            string resultado = juego.JugarRonda(
                jugada,
                solicitud.Apuesta,
                jugadaComputadora.Nombre
            );

            bool terminado = juego.Jugador.PartidaTerminada();

            // Guardar el resultado final en Supabase.
            if (terminado)
            {
                await _supabase.Insertar("puntajes", new Puntaje
                {
                    Jugador = juego.Jugador.Nombre,
                    Puntos = juego.Jugador.Fichas
                });

                Partidas.TryRemove(solicitud.IdPartida, out _);
            }

            return Ok(new
            {
                resultado,
                jugadaJugador = jugada,
                jugadaComputadora = jugadaComputadora.Nombre,
                fichas = juego.Jugador.Fichas,
                terminado
            });
        }
    }

    // Datos que recibe el servidor para iniciar.
    public class SolicitudInicio
    {
        public string Nombre { get; set; } = "";
    }

    // Datos que recibe el servidor para jugar.
    public class SolicitudRonda
    {
        public Guid IdPartida { get; set; }

        public string Jugada { get; set; } = "";

        public int Apuesta { get; set; }
    }
}

