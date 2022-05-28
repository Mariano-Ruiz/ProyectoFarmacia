namespace ProjectoFarmacia
{
    public class Farmacia
    {
        
    }

    public class Venta{

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
        private string nombre;
        private string dni;
        private DateTime fechaNacimiento;

        public Empleado(string nombre, string dni, DateTime fechaNacimiento){
            Nombre = nombre;
            Dni = dni;
            FechaNacimiento = fechaNacimiento;
        }
        public string Nombre{
            get; set;
        }
        public string Dni{
            get; set;
        }
        public DateTime FechaNacimiento{
            get; set;
        }
    }

}