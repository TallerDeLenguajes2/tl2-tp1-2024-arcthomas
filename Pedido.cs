using espacioCadete;
using espacioCadeteria;
using espacioCliente;

namespace espacioPedido;
public class Pedido
{
    private int nroPedido;
    private Cliente cliente;
    private Estado estado;
    private Cadete cadete;
    public int NroPedido { get => nroPedido; set => nroPedido = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Cadete Cadete { get => cadete; set => cadete = value; }
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