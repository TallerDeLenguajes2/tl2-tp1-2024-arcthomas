using espacioCadeteria;
using espacioCliente;
using espacioPedido;

namespace espacioCadete;

public class Cadete
{
    private int id;
    private string nombre;
    private string dir;
    private long numeroTel;
    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Dir { get => dir; set => dir = value; }
    public long NumeroTel { get => numeroTel; set => numeroTel = value; }
    public Cadete(int id, string nombre, string dir, long numerotel)
    {
        Id = id;
        Nombre = nombre;
        Dir = dir;
        NumeroTel = numeroTel;
    }
    public Cadete() { }
}