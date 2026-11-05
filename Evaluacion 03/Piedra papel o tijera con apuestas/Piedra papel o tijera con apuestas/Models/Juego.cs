
namespace Piedra_papel_o_tijera_con_apuestas.Models
{
    public class Juego
    {
        public Jugador Jugador { get; private set; }

        public Juego(string nombreJugador)
        {
            Jugador = new Jugador(nombreJugador);
        }

        public string JugarRonda(string jugadaJugador, int apuesta, string jugadaComputadora)
        {
            if (Jugador.PartidaTerminada())
            {
                return "La partida ya terminó.";
            }

            if (!Jugador.Apostar(apuesta))
            {
                return "Apuesta inválida.";
            }

            Jugada jugador = new Jugada(jugadaJugador);
            Jugada computadora = new Jugada(jugadaComputadora);

            string resultado = jugador.Comparar(computadora);

            if (resultado == "Gana")
            {
                Jugador.Ganar(apuesta * 2);
            }
            else if (resultado == "Empate")
            {
                Jugador.Ganar(apuesta);
            }

            return resultado;
        }
    }
}
