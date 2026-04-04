using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
class Program
{
    static List<String> productoSeleccionado = new List<string>();
    static List<int> Cantidad = new List<int>();
    static List<double> Precio = new List<double>();
    static void Main()
    {
        IngresoDatos();
        ImpresionResultados();

    }


    //JEAN

    static void IngresoDatos()
    {
        String nombreCliente = "";
        bool nombreValido = false;
        int seleccionCategoria = 0;
        int seleccionProducto = 0;
        bool productoValido = false;

        Dictionary<int, List<string>> Productos = new Dictionary<int, List<string>>()
        {
            { 1, new List<string> { "Arroz", "Aceite", "Azúcar", "Fideos", "Lentejas" }},
            { 2, new List<string> { "Leche", "Yogurt", "Queso", "Mantequilla", "Crema de leche" }},
            { 3, new List<string> { "Agua mineral", "Gaseosa", "Jugo de fruta", "Cerveza", "Vino" }},
            { 4, new List<string> { "Papas fritas", "Galletas", "Chocolates", "Maní", "Popcorn" }}
        };

        while (!nombreValido)
        {
            /*Solicitud de nombre al usuario, si posiblemente llegara nulo, el valor se asigna por defecto vacío, luego se valida que no esté vacío
             con el fin de evitar una incorrecta inserción de datos*/
            Console.WriteLine("Por favor, escribe tu nombre");
            nombreCliente = Console.ReadLine() ?? "";
            if (nombreCliente == "")
            {
                Console.WriteLine("El nombre no puede estar vacío, por favor ingresa un nombre válido");
            }
            else
            {   //Se valida que el nombre no tenga números, sino, vuelve a solicitar el nombre al usuario
                if (nombreCliente.Any(char.IsDigit))
                {
                    Console.WriteLine("El nombre no puede contener números, por favor ingresa un nombre válido");
                    nombreCliente = "";
                }
                else
                {
                    nombreValido = true;
                }
            }
        }

        while (!productoValido)
        {
            seleccionCategoria = mostrarCategoria();
            seleccionProducto = mostrarProductos(Productos, seleccionCategoria);

            if (seleccionProducto == 0)
            {
                Console.WriteLine("Debe seleccionar un producto válido, por favor intente nuevamente");
            }
            else
            {
                int cantidad = LeerEntero("Ingrese la cantidad del producto: ");
                double precio = LeerDecimal("ingrese el precio del producto: ");


                anadirProducto(Productos, seleccionCategoria, seleccionProducto, cantidad, precio, productoSeleccionado, Cantidad, Precio);
                if (productoSeleccionado.Count == 5)
                {

                    productoValido = true;
                }
            }

        }

    }
    static int mostrarCategoria()
    {
        List<String> categorias = new List<string> { "Abarrotes", "Lacteos", "Bebidas", "Snacks" };
        int categoriaValidar = 0;

        Console.WriteLine("Digíte el número de una de las categorías para acceder a los producto:");
        foreach (string categoria in categorias)
        {
            int numeroCategoria = categorias.IndexOf(categoria) + 1;
            Console.WriteLine($"{numeroCategoria}. {categoria}");
        }
        return categoriaValidar = Int32.Parse(Console.ReadLine());
    }
    static int mostrarProductos(Dictionary<int, List<string>> Productos, int seleccion)
    {
        int productoValidar = 0;

        if (Productos.ContainsKey(seleccion))
        {
            var prod = Productos[seleccion];
            Console.WriteLine("Digite el número de producto:");
            foreach (var producto in prod)
            {
                int numeroProducto = prod.IndexOf(producto) + 1;
                Console.WriteLine($"{numeroProducto}. {producto}");
            }
            return productoValidar = Int32.Parse(Console.ReadLine());
        }
        else
        {
            Console.WriteLine("La categoría seleccionada no es válida");
            return productoValidar;
        }
    }

    //JEAN 

    static int LeerEntero(string mensaje)//se solicita que el usuario ingrese un numero entero valido para la cantidad//
    {
        int valor;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }

            Console.WriteLine("Error:Ingrese un numero valido por favor:");
        }

    }
    static double LeerDecimal(string mensaje) //se solicita que el usuario ingrese un numero valido para el precio://
    {
        double valor;
        while (true)
        {
            Console.Write(mensaje);
            if (double.TryParse(Console.ReadLine(), out valor))
            {
                return valor;
            }

            Console.WriteLine("Error:Ingrese un numero valido por favor:");
        }

    }
    static void anadirProducto(Dictionary<int, List<string>> Productos, int categoria, int producto, int cantidad, double precio, List<string> pSeleccionado, List<int> pCantidad, List<double> pPrecio)
    {
        string nombreArticulo = Productos[categoria][producto - 1];

        pSeleccionado.Add(nombreArticulo);
        pCantidad.Add(cantidad);
        pPrecio.Add(precio);

    }
    
    //calculo del subtotal por producto comprado
    static double CalculoSubtotal(int cantidad, double precio)
    {
        return cantidad*precio;

    }
    //calculo del precio total a pagar por el cliente
    static double CalculoTotal() 
    {
        double total = 0;
        for (int i = 0; i < Cantidad.Count; i++)
        {
            double subtotal = CalculoSubtotal(Cantidad[i], Precio[i]);
            total += subtotal;
        }
        return total;
   
    }
    static void ImpresionResultados()
    {
       ///Tengo tres listas a ser impresas:
       /// ProductoSeleccionado, Cantidad y Precios
       /// Cant.    Descripción   Precio Total
       /// 2         Cerveza        Cantidad*Precio
       /// -            -               -
       /// -            -               -
       /// 
       /// TOTAL                       sumaTotal

        double total = CalculoTotal();
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine($"{"Cantidad",-10}{"Descripción",-20}{"Precio Unitario",-20}{"Precio Total"}");
        Console.WriteLine("-------------------------------------------------------------------");
        for (int i = 0; i < Cantidad.Count; i++)
        {

            double subtotal = CalculoSubtotal(Cantidad[i], Precio[i]);
       
            Console.WriteLine($"{Cantidad[i],-10}{productoSeleccionado[i],-20}{Precio[i],-20}{subtotal}");
        }
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine($"{"TOTAL A PAGAR:",-50} {total}");
    }
}