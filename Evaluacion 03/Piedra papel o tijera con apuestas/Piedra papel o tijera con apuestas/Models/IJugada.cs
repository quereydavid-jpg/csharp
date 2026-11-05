
namespace Piedra_papel_o_tijera_con_apuestas.Models
{
    public interface IJugada
    {
        string Nombre { get; }

        string Comparar(IJugada otraJugada);
    }
}
