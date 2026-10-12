Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Bienvenidos a Panaderia la Espiga");
Console.Write("¿Como se llama? ");
string cliente = Console.ReadLine();
Console.WriteLine("Hola, " + cliente + ". ¿Que le sirvo hoy?");
Console.Write("¿Que producto desea? ");
string producto = Console.ReadLine();
Console.WriteLine("Anotado: " + producto + " para " + cliente + ".");


