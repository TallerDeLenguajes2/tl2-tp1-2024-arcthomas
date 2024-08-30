# Trabajo Práctico Nro. 1 - Taller de Lenguajes II

## ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?

`Pedido` contiene por composición a `Cliente` de la forma:
> Pedido <- Cliente
> 
No se especifica que los cadetes desaparezcan al borrar una `Cadetería`.
Por lo tanto `Cadetería`, `Cadete` y `Pedido` son relaciones por agregación.

## ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?


La clase `Cadetería` debería tener al menos tres métodos:
```js
GenerarInforme();
AsignarPedido(Cadete cadete, Pedido pedido);
ReasignarPedido(Cadete cadete, Pedido pedido);
```

Ya que `Cadetería` puede acceder facilmente a sus cadetes, es más fácil asignar o reasignar pedidos desde su clase.

La clase `Cadete` debería tener al menos otros tres métodos:
```js
MostrarPedidos();
AgregarPedido(Pedido pedido);
EliminarPedido(Pedido pedido);
```

## Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.

Todas las clases en el programa deberían tener campos privados y propiedades publicas `get` y `set`.

Los métodos deberían ser públicos.

## ¿Cómo diseñaría los constructores de cada una de las clases?

Tanto `Cadetería`-`Cadete` y `Cadete`-`Pedido` tienen relación por agregación, una clase no depende de la otra

Podemos sobercargar el constructor para estas clases para considerar crear la clase con un objeto o sin el objeto de la forma:
```php
class Cadeteria
{
    private string nombre;
    private long numero;

    public string Nombre { get => nombre; set => nombre = value;}
    public long Numero { get => numero; set => numero = value;}
    public List<Cadete> lista_cadetes = new List<Cadete>();

    // Sobrecarga 1: Instanciar con un cadete
    public Cadeteria(Cadete cadete)
    {
        lista_cadetes.Add(cadete);
    }
    // Sobrecarga 2: Instanciar una cadetería vacía
    public Cadeteria(){}
}
```

Podemos copiar la misma estructura de sobrecarga la para la clase `Cadete`.

Para la clase `Pedido` necesitamos incoporar un cliente por composición, para hacerlo instanciamos un objeto `Cliente` dentro del constructor de la forma:
```php
class Pedido
{
    private Cliente cliente;
    private int nroPedido;
    private Estado estado;

    // Por supuesto hay que cargarle información
    public Pedido()
    {
        Cliente cliente = new Cliente();
    }
    
}
```

## ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?
---