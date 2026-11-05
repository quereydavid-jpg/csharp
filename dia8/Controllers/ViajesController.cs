using Microsoft.AspNetCore.Mvc;
using Billetaje.Models;

namespace Billetaje.Controllers;

public class ViajesController : Controller
{
    public IActionResult Index()
    {
        List<Viaje> viajes = new List<Viaje>
        {
            new Viaje { Linea = "Linea 12", NumeroTarjeta = "0001", Monto = 3400 },
            new Viaje { Linea = "Linea 12", NumeroTarjeta = "0002", Monto = 1700 },
            new Viaje { Linea = "Linea 30", NumeroTarjeta = "0003", Monto = 3400 },
            new Viaje { Linea = "Linea 56", NumeroTarjeta = "0001", Monto = 3400 },
            new Viaje { Linea = "Linea 30", NumeroTarjeta = "0004", Monto = 1700 }
        };

        return View(viajes);
    }
}
