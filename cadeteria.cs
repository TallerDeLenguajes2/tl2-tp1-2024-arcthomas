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
    public void MostrarInforme(List<Cadete> cadetes)
    {
        Console.WriteLine("INFORME DE CADETERÍA.");
        var infoCadetes = from cadete in cadetes
                          let pedidosEnviadosUnitario = cadete.Pedidos.Where(p => p.Estado.EstadoActual == Estado.Estados.Enviado)
                          select new
                          {
                              pedidosEnviadosUnitario,
                              Nombre = cadete.Nombre 
                          };
        foreach (var cadete in infoCadetes)
        {
            Console.WriteLine("Pedidos enviados por el cadete " + cadete.Nombre + ": " + cadete.pedidosEnviadosUnitario.Count());
            Console.WriteLine("Monto ganado para el cadete " + cadete.Nombre + ": $" + cadete.pedidosEnviadosUnitario.Count()*500);
            Console.WriteLine("------------------------------------");
        }
        var pedidosEnviados = from cadete in cadetes
                              from pedido in cadete.Pedidos
                              where pedido.Estado.EstadoActual == Estado.Estados.Enviado
                              select pedido;
        Console.WriteLine("Pedidos enviados totales: " + pedidosEnviados.Count());
        float promedio = (float)pedidosEnviados.Count() / infoCadetes.Count();
        Console.WriteLine("Promedio de envios por cadetes: " + promedio);
    }
}