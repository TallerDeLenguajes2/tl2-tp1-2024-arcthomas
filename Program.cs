using espacioCadeteria;
using espacioCadete;
using espacioCliente;
using espacioPedido;


Cadeteria cadeteriaCad = new Cadeteria();
Pedido unPedido = new Pedido();
Cadete cadete1 = new Cadete(unPedido);
Cadete cadete2 = new Cadete
(
    23,
    "Gonzalo",
    "Av. Oeste 122",
    23455345
);
List<Pedido> listaDePedidos = new List<Pedido>();

// Lectura de archivos
string archivo = "cadeteria1.csv";
string archivo2 = "cadetes.csv";
string[] lineas = File.ReadAllLines(archivo);
string[] lineas2 = File.ReadAllLines(archivo2);

// Asignación del nombre de la cadetería a partir del archivo
foreach (var linea in lineas)
{
    var valores = linea.Split(';');
    cadeteriaCad.Nombre = valores[0];
    cadeteriaCad.Numero = Int64.Parse(valores[1]);
}

// Creación y adición de cadetes por agregación a la cadetería
foreach (var linea in lineas2)
{
    int id;
    long num;
    var valores2 = linea.Split(';');
    Cadete cadete = new Cadete();
    Int32.TryParse(valores2[0], out id);
    cadete.Id = id;
    cadete.Nombre = valores2[1];
    cadete.Dir = valores2[2];
    Int64.TryParse(valores2[3], out num);
    cadete.NumeroTel = num;
    cadeteriaCad.ListaCadetes.Add(cadete);
    //Console.WriteLine("test");
}

//Interfaz
int opcion = 0;
Pedido pedidoEncontrado;
while (opcion != 6)
{
    Console.WriteLine("Bienvenido a la interfaz de la cadetería, ingrese una opción:\n1 - Dar de alta un pedido\n2 - Asignar un pedido\n3 - Cambiar de estado un pedido\n4 - Reasignar un pedido a otro cadete\n5 - Mostrar informe\n6 - Salir");
    opcion = int.Parse(Console.ReadLine());
    Console.WriteLine("La opcion es " + opcion);
    switch (opcion)
    {
        case 1:
            cadeteriaCad.CrearPedido(listaDePedidos);
            break;
        case 2:
            if (listaDePedidos.Count() != 0)
            {
                Console.WriteLine("Actualmente hay " + listaDePedidos.Count() + " Pedidos");
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(listaDePedidos);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("¡Pedido encontrado!");
                    Console.WriteLine("Cadetes disponibles: ");
                    cadeteriaCad.AsignarPedido(cadeteriaCad.EncontrarCadete(cadeteriaCad.ListaCadetes), pedidoEncontrado);
                }
                else
                {
                    Console.WriteLine("No se encontró el pedido.");
                }
            }
            else
            {
                Console.WriteLine("No hay pedidos por el momento");
            }
            break;
        case 3:
            if (listaDePedidos.Count() != 0)
            {
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(listaDePedidos);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("¡Pedido encontrado!");
                    cadeteriaCad.CambiarEstado(pedidoEncontrado);
                }
                else
                {
                    Console.WriteLine("No se encontró el pedido.");
                }
            }
            else
            {
                Console.WriteLine("No hay pedidos por el momento");
            }
            break;
        case 4:
            if (listaDePedidos.Count() != 0)
            {
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(listaDePedidos);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("¡Pedido encontrado!");
                    cadeteriaCad.ReasignarPedido(cadeteriaCad.EncontrarCadete(cadeteriaCad.ListaCadetes), cadeteriaCad.EncontrarCadete(cadeteriaCad.ListaCadetes), pedidoEncontrado);
                }
                else
                {
                    Console.WriteLine("No se encontró el pedido.");
                }
            }
            else
            {
                Console.WriteLine("No hay pedidos por el momento");
            }
            break;
        case 5:
            cadeteriaCad.MostrarInforme(cadeteriaCad.ListaCadetes);
            break;
        default:
            break;
    }
}