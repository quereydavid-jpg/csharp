using System;

//primer codigo principal

Cliente cliente = new Cliente("Lucia Benitez", "0981 123 456");
cliente.Presentarse();
Console.WriteLine("Telefono: " + cliente.Telefono);

//segundo codigo principal

Producto gaseosa = new Producto("Gaseosa 500ml", 6000);
PedidoDetalle linea = new PedidoDetalle(gaseosa, 3);

Console.WriteLine(linea.Cantidad + " x " + linea.Producto.Nombre + " = " + linea.Subtotal().ToString("N0") + " Gs");
Console.WriteLine("El producto existe por si solo: " + gaseosa.Nombre);

//tercer codigo principal
  // el codigo del cliente y el producto ya estan el 1 y el 2

  //Cliente cliente = new Cliente("Lucia Benitez", "0981 123 456");
  //Producto gaseosa = new Producto("Gaseosa 500ml", 6000);
Producto alfajor = new Producto("Alfajor", 3500);

Pedido pedido = new Pedido(cliente);
pedido.Agregar(gaseosa, 3);
pedido.Agregar(alfajor, 2);

pedido.Mostrar();

public class Persona
{
    public string Nombre { get; }
    public Persona(string nombre)
    {
        Nombre = nombre;
    }
    public void Presentarse()
    {
        Console.WriteLine("Hola, soy " + Nombre + ".");
    }
}

//cliente hereda de persona

public class Cliente : Persona
{
    public string Telefono { get; }
    public Cliente(string nombre, string telefono) : base(nombre)
    {
        Telefono = telefono;
    }
}

public class Producto
{
    public string Nombre { get; }
    public double Precio { get; }

    public Producto (string nombre, double precio)
    {
        Nombre = nombre;
        Precio = precio;
    }
}

public class PedidoDetalle
{
    public Producto Producto { get; }
    public int Cantidad { get; }

    public PedidoDetalle(Producto producto, int cantidad)
    {
        Producto = producto;
        Cantidad = cantidad;
    }

    public double Subtotal()
    {
        return Producto.Precio * Cantidad;
    }
}

public class Pedido
{
    private List<PedidoDetalle> _detalles = new List<PedidoDetalle>();
    public Cliente Cliente { get; }
    public Pedido(Cliente cliente)
    {
        Cliente = cliente;
    }

    public void Agregar(Producto producto, int cantidad)
    {
        _detalles.Add(new PedidoDetalle(producto, cantidad));
    } 
    public double Total()
    {
        return _detalles.Sum(d => d.Subtotal());
    }

    public void Mostrar()
    {
        Console.WriteLine("Pedido de " + Cliente.Nombre + " (" + Cliente.Telefono + ")");
        foreach (PedidoDetalle d  in _detalles)
        {
            Console.WriteLine(" " + d.Cantidad + " x " + d.Producto.Nombre + " = " + d.Subtotal().ToString("N0") + " Gs");
        }
        Console.WriteLine("Total: " + Total().ToString("N0") + " Gs");
    }
}



