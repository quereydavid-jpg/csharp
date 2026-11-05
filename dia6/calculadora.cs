using System;

Calculadora cal = new Calculadora();

Console.WriteLine("10 / 2 = " + cal.Dividir(10, 2));
Console.WriteLine("10 / 0 = " + cal.Dividir(10, 0));
Console.WriteLine("Fin del programa");


class Calculadora
{
    public string Dividir(int a, int b)
    {
        try
        {
            int resultado = a / b;
            return resultado.ToString();
        }
        catch (DivideByZeroException)
        {
            return "no se puede dividir por cero";
        }
        finally
        {
            Console.WriteLine("(operacion registrada)");
        }
    }
}


