using System;

namespace Taller_Mecanico_7_carros
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Este es un taller mecanico en el cual arreglamos tu auto" +
                "¡Vamos dejalo aqui!");
            Console.ForegroundColor = ConsoleColor.White;
            Taller taller = new Taller(7);// SE INSTANCIA CON 7 QUE ES LA MAX. CAPACIDAD DE AUTOS
            Console.WriteLine(taller.EspacioDisponible());
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Estos son los espacios disponible");
            Console.WriteLine("Si ingresa 'S' el programa cerrara");
            char ans;
            char salir = 'f';
            while (salir != 'S')
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("¿Que deseas hacer?");
                Console.WriteLine("A)Meter\nB)sacar\n");
                Console.WriteLine("Seleccione su inciso: ");
                ans = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                switch (ans)
                {
                    case 'A':
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ha seleccionado meter");
                            Console.Write("Ingrese su placa: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string placa = Convert.ToString(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Ingrese su nombre: ");
                            Console.ForegroundColor = ConsoleColor.White;
                            string nombre = Convert.ToString(Console.ReadLine());
                            if (taller.Meter(placa, nombre) == false)
                            {
                                Console.WriteLine("Error tabla llena");
                                Console.ReadKey();
                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Clear();
                            Console.WriteLine("Se ha actualizado la tabla");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(taller.EspacioDisponible());
                            Console.ReadKey();
                            break;
                        }
                    case 'B':
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Ha seleccionado sacar");
                            if (taller.Sacar() == false)
                            {
                                Console.WriteLine("Error tabla vacia");
                                Console.ReadKey();
                            }
                            Console.WriteLine("Se ha actualizado la tabla");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(taller.EspacioDisponible());
                            Console.ReadKey();
                            break;
                        }
                }
                Console.Clear();
                Console.WriteLine("¿Desea salir? presione S o presione cualquier tecla para continuar");
                salir = char.ToUpper(Convert.ToChar(Console.ReadLine()));
                Console.Clear();
            }
        }
    }
}
