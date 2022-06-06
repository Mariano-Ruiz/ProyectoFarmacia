using System;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectoFarmacia
{
    class Program{
        public static void Main(string[] args){
            // List<Empleado> empleados = new List<Empleado>();
            string empleadosJsonDes = File.ReadAllText("empleados.txt");
            List<Empleado> empleados = JsonSerializer.Deserialize<List<Empleado>>(empleadosJsonDes);
            int cantEmpleados = 1;

            List<Venta> ventas = new List<Venta>();
            // string ventasJsonDes = File.ReadAllText("ventas.txt");
            // ventas = JsonSerializer.Deserialize<List<Venta>>(ventasJsonDes);
            int cantVentas = 1;

            for ( ; ; ){
                imprimirMenu();
                Console.WriteLine("Que Desea Realizar?");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                    // DateTime fechaYHora = DateTime.Now;
                    // Console.WriteLine(fechaYHora.ToString());

                    break;
                    case "5":
                    empleados.Add(agregarEmpleado(cantEmpleados));
                    cantEmpleados ++;
                    break;
                    case "6": //borrar empleado con dni
                    Console.WriteLine("Ingrese el DNI del empleado a eliminar(sin puntos)");
                    string dni = Console.ReadLine();
                    eliminarEmpleado(dni, empleados);
                    break;
                    case "7":
                    listarEmpleados(empleados);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    case "9":
                    guardarJson(empleados, cantEmpleados, ventas);
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                    default:
                    //Cuando ingreso un valor incorrecto se termina el programa ARREGLAR.
                    Console.WriteLine("Opción incorrecta.");
                    break;
                }
                // Thread.Sleep(1000); //Espera el tiempo definido
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
//--------------------------------------------------Funciones Ventas-----------------------------------------------------

public static void agregarVenta(int cantVent){
    Console.WriteLine("Ingrese Obra Social(Si no tiene deje en blanco).");
    string obraSocial = Console.ReadLine();
    if(obraSocial == "")
        obraSocial = "particular";
    Console.WriteLine("Ingrese Codigo de Vendedor: ");
    int codVendedor = int.Parse(Console.ReadLine());
    DateTime fechaYHora = DateTime.Now;
    // Console.WriteLine(cantVent);
    // Console.WriteLine("");
    // Venta v1 = new Venta(Medicamento medicamento, obraSocial, numTicket, codVendedor, fechaYHora)
}

public static void eliminarVenta(List<Venta> ventas, int numTick){
    int posicion = ventas.FindIndex((Venta => Venta.NumTicket == numTick));
    if(posicion != -1){
        ventas.RemoveAt(posicion);
        return;
    }
    Console.WriteLine("No se encontro");
}

public static void porcentajeVentas(List<Venta> ventas){
    int ventasQuicena = 0;
    int ventasObraSocial = 0;
    DateTime date = DateTime.Now;
    var diaUno = new DateTime(date.Year, date.Month, 1);
    var diaQuince = new DateTime(date.Year, date.Month, 15);
    foreach (var venta in ventas)
    {
        if(!(venta.FechaYHora >= diaUno && venta.FechaYHora <= diaQuince))
            continue;
        ventasQuicena ++;
        if(!(venta.ObraSocial == "obra social"))
            continue;
        ventasObraSocial ++;
    }
    double porcentaje = (ventasObraSocial / ventasQuicena) * 100;
    Console.WriteLine("El porcentaje de ventas realizadas por obra social en la ultima quincena es de {0}%", porcentaje);
}









//---------------------------------------------------Funciones Empleado-------------------------------------------------------
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
                Console.WriteLine("Nombre: {0}\nDNI: {1}\nCodigo Vendedor: {2}\nFecha de Nacimiento: {3}\n", item.Nombre, item.Dni, item.CodVendedor, item.FechaNacimiento.ToString("dd/MM/yyyy"));
            }
        }

        public static void eliminarEmpleado(string dni, List<Empleado> emple){
            int posicion = emple.FindIndex((Empleado => Empleado.Dni == dni));
            if(posicion == -1)
                Console.WriteLine("No se encontro");
            emple.RemoveAt(posicion);
        }

        public static void guardarJson(List<Empleado> empleados, int cantEmple, List<Venta> ventas){
            string listaEmpleadosJson = JsonSerializer.Serialize(empleados);
            // string cantEmpleadosJson = JsonSerializer.Serialize(cantEmple);
            File.WriteAllText("empleados.txt", listaEmpleadosJson);
            string listaVentasJson = JsonSerializer.Serialize(ventas);
            File.WriteAllText("ventas.txt", listaVentasJson);
        }
    }
}