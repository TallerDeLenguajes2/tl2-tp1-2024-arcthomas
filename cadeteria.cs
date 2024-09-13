using System.ComponentModel.DataAnnotations;

namespace espacioCadeteria;

public class Cadeteria
{
    private string nombre;
    private long numero;
    private List<Cadete> listacadetes = new List<Cadete>();
    public string Nombre { get => nombre; set => nombre = value; }
    public long Numero { get => numero; set => numero = value; }
    public List<Cadete> ListaCadetes { get => listacadetes; set => listacadetes = value; }
    public Cadeteria(Cadete cadete)
    {
        ListaCadetes.Add(cadete);
    }
    public Cadeteria() { }

    public Pedido EncontrarPedidoPorNro(List<Pedido> listaDePedidos)
    {
        Console.WriteLine("Ingrese un numero de pedido para buscarlo en la lista:");
        int id = int.Parse(Console.ReadLine());
        foreach (var pedido in listaDePedidos)
        {
            if (id == pedido.NroPedido)
            {
                return pedido;
                break;
            }
        }
        return null;
    }
    public Cadete EncontrarCadete(List<Cadete> listacadetes)
    {
        int i = 1;
        foreach (var cadete in listacadetes)
        {
            Console.WriteLine(i + ". Cadete " + cadete.Nombre);
            i++;
        }
        Console.WriteLine("Seleccione su cadete: ");
        i = int.Parse(Console.ReadLine());
        return listacadetes[(i - 1)];
    }
    public void CrearPedido(List<Pedido> listaDePedidos)
    {
        int numeroPedido;
        Cliente cliente = new Cliente();
        Estado estado = new Estado();
        estado.EstadoActual = Estado.Estados.SinAsignar;

        Console.WriteLine("Ingrese número de pedido:");
        numeroPedido = int.Parse(Console.ReadLine());

        Pedido nuevoPedido = new Pedido(numeroPedido, cliente, estado);
        listaDePedidos.Add(nuevoPedido);
        Console.WriteLine("Pedido dado de alta con éxito.");
    }
    public void AsignarPedido(Cadete cadete, Pedido pedido)
    {
        cadete.Pedidos.Add(pedido);
        pedido.Estado.EstadoActual = Estado.Estados.EnPreparacion;
    }
    public void ReasignarPedido(Cadete cadete1, Cadete cadete2, Pedido pedido)
    {
        cadete1.Pedidos.Remove(pedido);
        cadete2.Pedidos.Add(pedido);
    }
    public void CambiarEstado(Pedido pedido)
    {
        Console.WriteLine("Cambiar el estado del pedido\n1. En proceso\n2. Enviado");
        int sel;
        sel = int.Parse(Console.ReadLine());
        switch (sel)
        {
            case 1:
                pedido.Estado.EstadoActual = Estado.Estados.EnPreparacion;
                break;
            case 2:
                pedido.Estado.EstadoActual = Estado.Estados.Enviado;
                break;
            default:
                break;
        }
    }
}

public class Cadete
{
    private int id;
    private string nombre;
    private string dir;
    private long numeroTel;
    private List<Pedido> pedidos = new List<Pedido>();

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Dir { get => dir; set => dir = value; }
    public long NumeroTel { get => numeroTel; set => numeroTel = value; }
    public List<Pedido> Pedidos { get => pedidos; set => pedidos = value; }
    public Cadete(Pedido pedido2)
    {
        pedidos.Add(pedido2);
        Console.WriteLine("asdas");
    }
    public Cadete(int id, string nombre, string dir, long numerotel)
    {
        Id = id;
        Nombre = nombre;
        Dir = dir;
        NumeroTel = numeroTel;
    }
    public Cadete() { }
}

public class Pedido
{
    private int nroPedido;
    private Cliente cliente;
    private Estado estado;
    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Pedido()
    {
        Cliente cliente = new Cliente();
        Cliente = cliente;
    }
    public Pedido(int nroPedido, Cliente cliente, Estado estado)
    {
        NroPedido = nroPedido;
        Cliente = cliente;
        Estado = estado;
    }
}

public class Cliente
{
    private string nombre;
    private string dir;
    private long telefono;
    private string ref_dir;
}

public class Estado
{
    public enum Estados
    {
        SinAsignar,
        EnPreparacion,
        Enviado
    }
    public Estados EstadoActual { get; set; }
}