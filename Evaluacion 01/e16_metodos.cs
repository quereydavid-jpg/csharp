using System;

decimal precio = 150000m;

Console.WriteLine("Precio sin IVA: " +  precio);
Console.WriteLine("IVA 10%: " + CalcularIva(precio, 10));
Console.WriteLine("Total con IVA 10%: " + PrecioConIva(precio, 10));
Console.WriteLine("Total con IVA 5%: " + PrecioConIva(precio, 5));

decimal CalcularIva(decimal monto, decimal puntaje)
{
    return monto * puntaje / 100;
}

decimal PrecioConIva(decimal monto, decimal porcentaje)
{
    return monto + CalcularIva(monto, porcentaje);
}
