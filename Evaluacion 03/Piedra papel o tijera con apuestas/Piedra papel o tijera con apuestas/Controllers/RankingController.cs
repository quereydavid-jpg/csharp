
using Microsoft.AspNetCore.Mvc;
using Piedra_papel_o_tijera_con_apuestas.Data;
using Piedra_papel_o_tijera_con_apuestas.Models;

namespace Piedra_papel_o_tijera_con_apuestas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RankingController : ControllerBase
    {
        private readonly SupabaseCliente _supabase;

        public RankingController(SupabaseCliente supabase)
        {
            _supabase = supabase;
        }

        // Mostrar los 10 mejores jugadores.
        [HttpGet]
        public async Task<IActionResult> ObtenerRanking()
        {
            try
            {
                List<Puntaje> mejores =
                    await _supabase.Listar<Puntaje>(
                        "puntajes?select=*&order=puntos.desc,creado.asc&limit=10"
                    );

                return Ok(mejores);
            }
            catch (Exception)
            {
                return StatusCode(500, "No se pudo obtener el ranking.");
            }
        }
    }
}
