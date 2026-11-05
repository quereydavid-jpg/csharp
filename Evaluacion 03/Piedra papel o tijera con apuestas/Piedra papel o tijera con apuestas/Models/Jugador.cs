
namespace Piedra_papel_o_tijera_con_apuestas.Models
{
    public class Jugador
    {
        public string Nombre { get; set; }

        public int Fichas { get; private set; }

        public Jugador(string nombre)
        {
            Nombre = nombre;
            Fichas = 100;
        }

        public bool Apostar(int cantidad)
        {
            if (cantidad < 1 || cantidad > Fichas)
            {
                return false;
            }

            Fichas -= cantidad;
            return true;
        }

        public void Ganar(int cantidad)
        {
            Fichas = Math.Min(Fichas + cantidad, 500);
        }

        public bool PartidaTerminada()
        {
            return Fichas <= 0 || Fichas >= 500;
        }
    }
}

