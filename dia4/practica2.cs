using System;
Dictionary<string, double> precios = new Dictionary<string, double>
{
    { "Medialuna", 2500 },
    { "Chipa", 3000 },
    { "Pan por kilo", 12000 },
    { "Gaseosa", 8000 },
    { "Leche", 9500 },
};

Dictionary<string, int> tasaIva = new Dictionary<string, int>
{
    { "Medialuna", 10 },
    { "Chipa", 10 },
    { "Pan por kilo", 5 },
    { "Gaseosa", 10 },
    { "Leche", 5 },
};

Console.WriteLine("===Catalogo===");
foreach (string producto in precios.Keys)
{
    Console.WriteLine(producto + ": " + FormatoGs(precios[producto]) + " (IVA " + tasaIva[producto] + " %)");
}

static string FormatoGs(double precio)
{
    return precio.ToString("N0") + " Gs.";
}







