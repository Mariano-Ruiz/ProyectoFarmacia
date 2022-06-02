using System;
using System.Collections;

namespace ProjectoFarmacia
{
    class Program{
        public static void Main(string[] args){
            List<Empleado> empleados = new List<Empleado>();
            int cantEmpleados = 0;

            for ( ; ; ){
                imprimirMenu();
                Console.WriteLine("Que Desea Realizar?");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "5":
                    empleados.Add(agregarEmpleado(cantEmpleados));
                    cantEmpleados ++;
                    break;
                    case "6": //borrar empleado con dni
                    if(eliminarEmpleado("44394618", empleados))
                        cantEmpleados --;
                    
                    break;
                    case "7":
                    listarEmpleados(empleados);
                    break;
                    case "9":
                    Environment.Exit(0);
                    break;
                    default:
                    Console.WriteLine("Opción incorrecta.");
                    break;
                }
                Thread.Sleep(1000); //Espera el tiempo definido
            }
            
        }
//-----------------------------------------------------Funciones-----------------------------------------------------
        public static void imprimirMenu(){
            String opciones =  @"
Programa Farmacia
-----------------
1. Agregar una venta de medicamento.
2. Eliminar venta de medicamento.
3. Porcentaje de ventas realizadas en la primer quincena por obra social.
4. Lista de Ventas por Cada Vendedor.
5. Agregar empleado.
6. Borrar empleado.
7. Listado de empleados.
8. Listado de medicamentos vendidos sin repeticiones.
9. Salir.
-----------------";
            Console.WriteLine(opciones);
        }


        public static Empleado agregarEmpleado(int codVendedor){
            // Empleado e1 = new Empleado("Mariano", "44394618", 1234, DateTime.Parse("02/05/2002"));
            Console.WriteLine("Nombre:");
            string nombre = Console.ReadLine();
            Console.WriteLine("DNI: ");
            string dni = Console.ReadLine();
            Console.WriteLine("Fecha de Nacimiento. Ejemplo dd/mm/aaaa: " );
            DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());
            Empleado e1 = new Empleado(nombre, dni, codVendedor , fechaNacimiento);
            return e1;
        }


        public static void listarEmpleados(List<Empleado> emple){
            foreach (var item in emple)
            {
                Console.WriteLine(item.Nombre + ", " +  item.Dni + ", " + item.CodVendedor + ", " + item.FechaNacimiento.ToString("dd/MM/yyyy"));
            }
        }

        public static bool eliminarEmpleado(string dni, List<Empleado> emple){
            foreach (Empleado item in emple)
            {
                if(item.Dni == dni){
                    emple.Remove(item);
                    return true;
                }
            }
            Console.WriteLine("No se encuentra al empleado");
            return false;
        }
    }
}