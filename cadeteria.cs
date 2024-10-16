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

    public Pedido EncontrarPedidoPorNro(int id)
    {
        return ListaPedidos.FirstOrDefault(p => p.NroPedido == id);
    }

    public Cadete EncontrarCadete(int indice)
    {
        if (indice >= 0 && indice < ListaCadetes.Count)
        {
            return ListaCadetes[indice];
        }
        return null;
    }

    public bool CrearPedido(int numeroPedido, Cliente cliente)
    {
        Estado estado = new Estado { EstadoActual = Estado.Estados.SinAsignar };
        Pedido nuevoPedido = new Pedido(numeroPedido, cliente, estado);
        ListaPedidos.Add(nuevoPedido);
        return true;
    }

    public bool AsignarCadeteAPedido(int idCadete, int numeroPedido)
    {
        var cadete = ListaCadetes.FirstOrDefault(c => c.Id == idCadete);
        var pedido = ListaPedidos.FirstOrDefault(p => p.NroPedido == numeroPedido);
        
        if (cadete != null && pedido != null)
        {
            pedido.Cadete = cadete;
            pedido.Estado.EstadoActual = Estado.Estados.EnPreparacion;
            return true;
        }
        return false;
    }

    public bool ReasignarPedido(int numeroPedido, int idNuevoCadete)
    {
        var pedido = ListaPedidos.FirstOrDefault(p => p.NroPedido == numeroPedido);
        var nuevoCadete = ListaCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
        
        if (pedido != null && nuevoCadete != null)
        {
            pedido.Cadete = nuevoCadete;
            return true;
        }
        return false;
    }

    public bool CambiarEstado(int numeroPedido, int nuevoEstado)
    {
        var pedido = ListaPedidos.FirstOrDefault(p => p.NroPedido == numeroPedido);
        if (pedido != null)
        {
            switch (nuevoEstado)
            {
                case 1:
                    pedido.Estado.EstadoActual = Estado.Estados.EnPreparacion;
                    break;
                case 2:
                    pedido.Estado.EstadoActual = Estado.Estados.Enviado;
                    break;
                default:
                    return false;
            }
            return true;
        }
        return false;
    }

    public string GenerarInforme()
    {
        string informe = "INFORME DE CADETERÍA.\n";
        foreach (var cadete in ListaCadetes)
        {
            var pedidosEnviados = ListaPedidos.Count(p => p.Cadete == cadete && p.Estado.EstadoActual == Estado.Estados.Enviado);
            informe += $"Pedidos enviados por el cadete {cadete.Nombre}: {pedidosEnviados}\n";
            informe += $"Monto ganado para el cadete {cadete.Nombre}: ${pedidosEnviados * 500}\n";
            informe += "------------------------------------\n";
        }
        
        var totalPedidosEnviados = ListaPedidos.Count(p => p.Estado.EstadoActual == Estado.Estados.Enviado);
        informe += $"Pedidos enviados totales: {totalPedidosEnviados}\n";
        
        float promedio = (float)totalPedidosEnviados / ListaCadetes.Count;
        informe += $"Promedio de envíos por cadetes: {promedio}\n";
        
        return informe;
    }

    public string CalcularJornalACobrar(int id)
    {
        var pedidosEnviados = ListaPedidos.Count(p => p.Cadete.Id == id && p.Estado.EstadoActual == Estado.Estados.Enviado);
        var cadete = ListaCadetes.FirstOrDefault(c => c.Id == id);
        
        if (cadete != null)
        {
            return $"El jornal a cobrar del Cadete {cadete.Nombre} es ${pedidosEnviados * 500}";
        }
        else
        {
            return $"No se encontró un cadete con el ID {id}";
        }
    }
}