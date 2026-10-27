using System;
//pelea de jugadores

Jugador j1 = new Jugador("Fiorela", 50);
Jugador j2 = new Jugador("Maria", 40);

j1.RecibirAtaque(26);
j2.RecibirAtaque(15);
j1.Mostrar();
j2.Mostrar();
Console.WriteLine("15 minutos de descanzo");
j1.Curar(15);
j2.Curar(5);
j1.Mostrar();
j2.Mostrar();

class Jugador
{
    //atributos
    public string Nombre;
    public int Vida;

    //constructor
    public Jugador (string nombre, int vida)
    {
        Nombre = nombre;
        Vida = vida;
    }
    //metodos
    public void RecibirAtaque(int puntos)
    {
        Vida = Vida - puntos;
    }
    public void Curar(int puntos)
    {
        Vida += puntos;
    }
    public void Mostrar()
    {
        Console.WriteLine($"{Nombre} tiene {Vida} de vida");
    }
}


