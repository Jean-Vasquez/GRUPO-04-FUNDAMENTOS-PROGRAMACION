using System;
class Program
{
    static void Main()
    {
        IngresoDatos();
        Calculo();

    }


    static void IngresoDatos()
    {
        String nombreCliente = "";
        bool nombreValido = false;

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
    }

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