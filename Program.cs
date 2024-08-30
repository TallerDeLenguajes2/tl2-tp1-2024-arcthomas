using espacioCadeteria;

Cadeteria cadeteriaCad = new Cadeteria();
Pedido unPedido = new Pedido();
Cadete cadete1 = new Cadete(unPedido);

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
    cadeteriaCad.Numero = valores[1];
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
    cadete.Numero = num;
    cadeteriaCad.lista_cadetes.Add(cadete);
}

//Interfaz
Console.WriteLine("Bienvenido a la interfaz de la cadetería, ingrese una opción:\n1 - Dar de alta un pedido\n2 -  Asignar un pedido\n3 - Cambiar de estado un pedido\n4 - Reasignar un pedido a otro cadete");
int opcion = int.Parse(Console.ReadLine());
Console.WriteLine("La opcion es "+ opcion);
switch (opcion)
{
    case 1:
        Console.WriteLine("A continuación ingrese info del pedido");
        break;
    default:
    break;
}