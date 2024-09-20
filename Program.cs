using espacioCadeteria;
using espacioCadete;
using espacioCliente;
using espacioPedido;


Cadeteria cadeteriaCad = new Cadeteria();

// Lectura de archivos
int pick = 0;
while (pick != 1 && pick != 2)
{
    Console.WriteLine("Ingrese su preferencia de lectura de archivos:\n1. JSON\n2. CSV");
    pick = int.Parse(Console.ReadLine());
    switch (pick)
    {
        case 1:
            AccesoJSON accesoJson = new AccesoJSON();
            cadeteriaCad = accesoJson.LeerCadeteria("cadeteria");
            cadeteriaCad.ListaCadetes = accesoJson.LeerCadetes("cadetes");
            break;
        case 2:
            AccesoCSV accesoCsv = new AccesoCSV();
            cadeteriaCad = accesoCsv.LeerCadeteria("cadeteria");
            cadeteriaCad.ListaCadetes = accesoCsv.LeerCadetes("cadetes");
            break;
        default:
            break;
    }
}

//Interfaz
int opcion = 0;
Pedido pedidoEncontrado;
while (opcion != 6)
{
    Console.WriteLine("Bienvenido a la interfaz de la cadetería, ingrese una opción:\n1 - Dar de alta un pedido\n2 - Asignar cadete un pedido\n3 - Cambiar de estado un pedido\n4 - Reasignar un pedido a otro cadete\n5 - Mostrar informe\n6 - Salir");
    opcion = int.Parse(Console.ReadLine());
    Console.WriteLine("La opcion es " + opcion);
    switch (opcion)
    {
        case 1:
            cadeteriaCad.CrearPedido(cadeteriaCad.ListaPedidos);
            Console.WriteLine("Test");
            break;
        case 2:
            if (cadeteriaCad.ListaPedidos.Count() != 0)
            {
                Console.WriteLine("Actualmente hay " + cadeteriaCad.ListaPedidos.Count() + " Pedidos");
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(cadeteriaCad.ListaPedidos);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("¡Pedido encontrado!");
                    Console.WriteLine("Cadetes disponibles: ");
                    cadeteriaCad.AsignarCadeteAPedido(cadeteriaCad.EncontrarCadete(cadeteriaCad.ListaCadetes), pedidoEncontrado);
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
            if (cadeteriaCad.ListaPedidos.Count() != 0)
            {
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(cadeteriaCad.ListaPedidos);
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
            if (cadeteriaCad.ListaPedidos.Count() != 0)
            {
                pedidoEncontrado = cadeteriaCad.EncontrarPedidoPorNro(cadeteriaCad.ListaPedidos);
                if (pedidoEncontrado != null)
                {
                    Console.WriteLine("¡Pedido encontrado!");
                    cadeteriaCad.ReasignarPedido(pedidoEncontrado, cadeteriaCad.EncontrarCadete(cadeteriaCad.ListaCadetes));
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
            cadeteriaCad.MostrarInforme();
            break;
        case 7:
            cadeteriaCad.JornarACobrar(2);
            break;
        default:
            break;
    }
}