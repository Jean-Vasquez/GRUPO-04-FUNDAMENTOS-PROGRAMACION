using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // ==========================================
        // PERSONA 1: ENTRADA DE DATOS
        // ==========================================
        Console.WriteLine("--- SISTEMA DE PEDIDOS ---");

        // 1. Pedir nombre del cliente
        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine();

        // Creamos listas para guardar los 5 productos (Cantidades y Precios)
        List<string> nombresProductos = new List<string>();
        List<int> cantidadesProductos = new List<int>();
        List<double> preciosProductos = new List<double>();

        // 2. Pedir exactamente 5 productos (como pide la tarea)
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine($"\n-- Ingresando Producto {i} de 5 --");
            
            // Pedimos el producto
            Console.Write("Nombre del producto: ");
            string producto = Console.ReadLine();
            nombresProductos.Add(producto);

            // Pedimos cantidad (Convertimos texto a número entero)
            Console.Write("Cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            cantidadesProductos.Add(cantidad);

            // Pedir precio (Convertimos texto a número decimal)
            Console.Write("Precio unitario: ");
            double precio = double.Parse(Console.ReadLine());
            preciosProductos.Add(precio);
        }

        // ==========================================
        // PERSONA 2: CÁLCULOS (Subtotales y Total general)
        // ==========================================
        // (Aquí la Persona 2 usará las listas de arriba para hacer las operaciones)
        
        Console.WriteLine("\n[Aquí la Persona 2 hará los cálculos...]");


        // ==========================================
        // PERSONA 3: SALIDA (Resumen final)
        // ==========================================
        // (Aquí la Persona 3 mostrará un resumen final bonito)
        
        Console.WriteLine("[Aquí la Persona 3 mostrará el recibo final...]");
        
        // Pausar para que no se cierre la consola inmediatamente
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}
