using System;
class Program
{
   static void Main()
{
    IngresoDatos();

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

static void Calculo()
    {
        
    }
static void ImpresionResultados()
    {
        
    }
}