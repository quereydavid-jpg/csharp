
using Piedra_papel_o_tijera_con_apuestas.Models;

namespace Piedra_papel_o_tijera_con_apuestas.Services
{
    public class Computadora
    {
        private readonly Random _azar = new Random();

        public Jugada ElegirJugada()
        {
            string[] opciones = { "piedra", "papel", "tijera" };

            int numero = _azar.Next(0, opciones.Length);

            return new Jugada(opciones[numero]);
        }
    }
}
