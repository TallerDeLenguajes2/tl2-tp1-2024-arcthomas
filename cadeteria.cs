using System.ComponentModel.DataAnnotations;
using espacioCadete;
using espacioCliente;
using espacioPedido;

namespace espacioCadeteria;

public class Cadeteria
{
    private string nombre;
    private long numero;
    private List<Cadete> listacadetes = new List<Cadete>();
    private List<Pedido> listapedidos = new List<Pedido>();
    public string Nombre { get => nombre; set => nombre = value; }
    public long Numero { get => numero; set => numero = value; }
    public List<Cadete> ListaCadetes { get => listacadetes; set => listacadetes = value; }
    public List<Pedido> ListaPedidos { get => listapedidos; set => listapedidos = value; }
    public Cadeteria(string nombre, long numero)
    {
        Nombre = nombre;
        Numero = numero;
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
        return listacadetes[i - 1];
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
    public void AsignarCadeteAPedido(Cadete cadete, Pedido pedido)
    {
        pedido.Cadete = cadete;
        pedido.Estado.EstadoActual = Estado.Estados.EnPreparacion;
    }
    public void ReasignarPedido(Pedido pedido, Cadete cadeteExchange)
    {
        pedido.Cadete = cadeteExchange;
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
    public void MostrarInforme()
    {
        Console.WriteLine("INFORME DE CADETERÍA.");
        foreach (var cadete in ListaCadetes)
        {
            var PedidosUnitarios = from pedido in ListaPedidos
                                   where pedido.Cadete == cadete && pedido.Estado.EstadoActual == Estado.Estados.Enviado
                                   select pedido;
            Console.WriteLine("Pedidos enviados por el cadete " + cadete.Nombre + ": " + PedidosUnitarios.Count());
            Console.WriteLine("Monto ganado para el cadete " + cadete.Nombre + ": $" + PedidosUnitarios.Count() * 500);
            Console.WriteLine("------------------------------------");
        }
        var pedidosEnviados = from pedido in ListaPedidos
                              where pedido.Estado.EstadoActual == Estado.Estados.Enviado
                              select pedido;
        Console.WriteLine("Pedidos enviados totales: " + pedidosEnviados.Count());
        float promedio = (float)pedidosEnviados.Count() / ListaCadetes.Count();
        Console.WriteLine("Promedio de envios por cadetes: " + promedio);
    }

    public void JornarACobrar(int id)
    {
        var pedidos = from pedido in ListaPedidos
                      where pedido.Cadete.Id == id && pedido.Estado.EstadoActual == Estado.Estados.Enviado
                      select new
                      {
                          Nombre = pedido.Cadete.Nombre,
                          pedido
                      };
        var primerPedido = pedidos.FirstOrDefault();
        if (primerPedido != null)
        {
            Console.WriteLine("El jornal a cobrar del Cadete " + primerPedido.Nombre + "es $" + pedidos.Count() * 500);
        }
        else
        {
            Console.WriteLine("No se encontraron pedidos enviados para el cadete " + ListaCadetes[id-1].Nombre);
        }
    }
}