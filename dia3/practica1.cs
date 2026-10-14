using System;
double CalcularSubtotal(double precio, int cantidad)
{
    return precio * cantidad;
}

double AplicarDescuento(double monto, int porcentaje)
{
    return monto - monto * porcentaje / 100;
}

double subtotal = CalcularSubtotal(100000, 2);
double descuento;
descuento = AplicarDescuento(subtotal, 5);
Console.WriteLine($"Subtotal = {subtotal}");
Console.WriteLine($"Con descuento del 5% = {descuento}");
