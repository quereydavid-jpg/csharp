
namespace Piedra_papel_o_tijera_con_apuestas.Models
{
    public class Jugada : IJugada
    {
        public string Nombre { get; set; }

        public Jugada(string nombre)
        {
            Nombre = nombre.ToLower();
        }

        public string Comparar(IJugada otraJugada)
        {
            if (Nombre == otraJugada.Nombre)
            {
                return "Empate";
            }

            if (Nombre == "piedra" && otraJugada.Nombre == "tijera" ||
                Nombre == "papel" && otraJugada.Nombre == "piedra" ||
                Nombre == "tijera" && otraJugada.Nombre == "papel")
            {
                return "Gana";
            }

            return "Pierde";
        }
    }
}
