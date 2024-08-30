namespace espacioCadeteria;

public class Cadeteria
{
    private string nombre;
    private long numero;
    public string Nombre { get => nombre; set => nombre = value;}
    public long Numero { get => numero; set => numero = value;}
    public List<Cadete> lista_cadetes = new List<Cadete>();
    public Cadeteria(Cadete cadete)
    {
        lista_cadetes.Add(cadete);
    }
    public Cadeteria(){}
}

public class Cadete
{
    private int id;
    private string nombre;
    private string dir;
    private long telefono;
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Dir { get; set; }
    public long Numero { get; set; }
    private List<Pedido> pedidos = new List<Pedido>();
    public Cadete(Pedido pedido2)
    {
        pedidos.Add(pedido2);
        Console.WriteLine("asdas");
    }
    public Cadete(){}
}

public class Pedido
{
    private int nroPedido;
    private Cliente cliente;
    private Estado estado;
    public Pedido()
    {
        Cliente cliente = new Cliente();
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
    private enum Estados
    {
        Cancelado,
        Enviado,
        EnPreparacion
    }
}