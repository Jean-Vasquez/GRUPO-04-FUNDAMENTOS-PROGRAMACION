using System;
class Program
{
    static void Main()
    {
        IngresoDatos();
        Calculo();

    }


    //JEAN

    static void IngresoDatos()
    {
        String nombreCliente = "";
        bool nombreValido = false;
        int seleccionCategoria = 0;
        int seleccionProducto = 0;
        bool productoValido = false;
        List<String> productoSeleccionado = new List<string>();
        List<int> Cantidad = new List<int>();
        List<double> Precio = new List<double>();
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
                    Console.WriteLine("El nombre no puede contenedor números, por favor ingresa un nombre válido");
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
                Console.Write("Ingrese la cantidad del producto: ");
                int cantidad = Int32.Parse(Console.ReadLine());

                Console.Write("Ingrese el precio del producto: ");
                double precio = double.Parse(Console.ReadLine());

                anadirProducto(Productos, seleccionCategoria, seleccionProducto, cantidad, precio, productoSeleccionado, Cantidad, Precio);
                if (productoSeleccionado.Count == 5)
                {

                    productoValido = true;
                }
            }

        }

    }

    static int mostrarProductos(Dictionary<int, List<string>> Productos, int seleccion)
    {
        int productoValidar = 0;

        if (Productos.ContainsKey(seleccion))
        {
            var prod = Productos[seleccion];
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

    static void anadirProducto(Dictionary<int, List<string>> Productos, int categoria, int producto, int cantidad, double precio, List<string> pSeleccionado, List<int> pCantidad, List<double> pPrecio)
    {
        string nombreArticulo = Productos[categoria][producto - 1];

        pSeleccionado.Add(nombreArticulo);
        pCantidad.Add(cantidad);
        pPrecio.Add(precio);

    }

    //JEAN 


    static void Calculo() //se realisa el calculo de los productos//
    {
        double total = 0;
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Producto " + (i + 1));
            int cantidad = LeerEntero("Ingrese la cantidad del producto:");
            double precio = LeerDecimal("Ingrese el precio del producto");
            double subtotal = cantidad * precio;
            total += subtotal;
            Console.WriteLine("Subtotal:" + subtotal);
        }
        Console.WriteLine("Total:" + total);
    }
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

            Console.WriteLine("Error:Ingrese un numero validopor favor:");
        }

    }
    static void ImpresionResultados()
    {

    }
}