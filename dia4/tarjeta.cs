using System;

Tarjeta tarjeta = new Tarjeta("Lucia Benitez");
tarjeta.Recargar(20000);
tarjeta.Pagar(3400);
tarjeta.Pagar(3400);
tarjeta.Pagar(20000);

Console.WriteLine("Titular: " + tarjeta.Titular);
Console.WriteLine("Saldo: " + tarjeta.Saldo + " Gs");


class Tarjeta
{
    private int _saldo;
    public string Titular { get; }
    public int Saldo
    {
        get { return _saldo; }
    }
    public Tarjeta(string titular)
    {
        Titular = titular;
        _saldo = 0;
    }
    public void Recargar(int monto)
    {
        if( monto <= 0)
        {
            Console.WriteLine("La recarga debe ser mayor igual a 0.");
            return;
        }
        _saldo += monto;
    }
    public bool Pagar(int monto)
    {
        if (monto > _saldo)
        {
            Console.WriteLine("Saldo insuficiente");
            return false;
        }
        _saldo -= monto;
        return true;
    }
}


