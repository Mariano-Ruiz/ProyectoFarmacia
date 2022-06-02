using System.Collections;

namespace ProjectoFarmacia
{
    // Creeria que no voy a usar clase Farmacia(Mucho Quilombo[Creo])
    public class Farmacia
    {
        private List<Empleado> empleados;
        private List<Venta> ventas;
        private List<Medicamento> medicamento;
    }

    public class Venta{
        private string obraSocial;
        private int numTicket, codVendedor;
        private Medicamento medicamento;

        public Venta(Medicamento medicamento, string obraSocial, int numTicket, int codVendedor){
            Medicamento = medicamento;
            ObraSocial = obraSocial;
            NumTicket = numTicket;
            CodVendedor = codVendedor;
        }
        public Medicamento Medicamento{
            get; set;
        }
        public string ObraSocial{
            get; set;
        }
        public int NumTicket{
            get; set;
        }
        public int CodVendedor{
            get; set;
        }
    }

    public class Medicamento{
        private string nombre, droga;
        private double precio;

        public Medicamento(string nombre, string droga, int precio){
            Nombre = nombre;
            Droga = droga;
            Precio = precio;
        }
        public string Nombre{
            get; set;
        }
        public string Droga{
            get; set;
        }
        public double Precio{
            get; set;
        }
    }

        public class Empleado{
        private string nombre, dni;
        private int codVendedor;
        private DateTime fechaNacimiento;

        public Empleado(string nombre, string dni, int codVendedor ,DateTime fechaNacimiento){
            Nombre = nombre;
            Dni = dni;
            CodVendedor = codVendedor;
            FechaNacimiento = fechaNacimiento;
        }
        public string Nombre{
            get; set;
        }
        public string Dni{
            get; set;
        }
        public int CodVendedor{
            get; set;
        }
        public DateTime FechaNacimiento{
            get; set;
        }
    }

}