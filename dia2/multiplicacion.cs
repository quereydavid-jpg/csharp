using System;

Console.WriteLine("TABLA DE MULTIPLICAR");
Console.WriteLine("Insertar numero: ");
int n = Convert.ToInt32(Console.ReadLine());

for(int i = 1; i <= 10; i++)
{
    Console.WriteLine($" {n} x {i} = {n * i}");
}
