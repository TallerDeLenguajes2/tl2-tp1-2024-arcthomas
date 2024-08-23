namespace espacioCadeteria;

public class Cadeteria
{
    private string nombre;
    private long numero;
    private List<Cadete> lista_cadetes;
}

public class Cadete
{
    private int id;
    private string nombre;
    private string dir;
    private long telefono;
    private List<Pedido> pedidos;
}

public class Pedido
{
    private Cliente cliente;
    private int nroPedido;
    public Pedido()
    {
        Cliente cliente = new Cliente();
    }
    private Estado estado;
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
    private enum Estados
    {
        Cancelado,
        Enviado,
        EnPreparacion
    }
}