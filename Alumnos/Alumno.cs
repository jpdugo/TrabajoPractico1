namespace Alumnos
{
    internal class Alumno
    {
        private const int MAX_MATERIAS = 36;
        private static int ultimoLegajo = 0;

        #region "propiedades"

        public int Legajo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }

        private DateTime fecha_nacimiento;

        private DateTime fecha_ingreso;
        public int Edad { get; private set; }
        public Boolean Activo { get; set; }

        private int cant_materia_aprobadas;

        public DateTime Fecha_Nacimiento
        {
            set { fecha_nacimiento = value; }
        }

        public DateTime Fecha_Ingreso
        {
            set { fecha_ingreso = value; }
        }

        public int Cant_Materia_Aprobadas
        {
            get { return cant_materia_aprobadas; }
            set {
                if (cant_materia_aprobadas < 37)
                {
                    cant_materia_aprobadas = value;
                }
            }
        }

        #endregion
        #region "constructores"
        public Alumno() {

            Legajo = ++ultimoLegajo;
        }
        public Alumno(
            string nombre,
            string apellido,
            DateTime fecha_nacimiento,
            DateTime fecha_ingreso,
            Boolean activo,
            int cant_materia_aprobadas
        ) : this()
        {
            Nombre = nombre;
            Apellido = apellido;
            Fecha_Nacimiento = fecha_nacimiento;
            Fecha_Ingreso = fecha_ingreso;
            Activo = activo;
            Cant_Materia_Aprobadas = cant_materia_aprobadas;
            CalcularEdad(fecha_nacimiento);
        }

        public int CalcularEdad(DateTime fechaNacimiento) 
        {
            var todayDate = DateTime.Today;
            int edad = todayDate.Year - fechaNacimiento.Year;

            if (todayDate.Month < fechaNacimiento.Month || (todayDate.Month == fechaNacimiento.Month && todayDate.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            this.Edad = edad;
            return edad;
        }

        #endregion

        #region "finalizadores"
        ~Alumno()
        {
            Console.WriteLine($"El alumno con Legajo: {Legajo}, Nombre: {Nombre}, Apellido: {Apellido} fue eliminado.");
        }
        #endregion

        #region "metodos"
        public int Antiguedad(Unidades unidad)
        {
            DateTime fecha_actual = DateTime.Now;
            int antiguedadAños = fecha_actual.Year - fecha_ingreso.Year;
            int antiguedadMeses = fecha_actual.Month - fecha_ingreso.Month;

            if (antiguedadMeses < 0)
            {
                antiguedadAños--;
            }

            string unidadDescription = unidad.GetDescription();

            switch (unidadDescription)
            {
                case "Años":
                    return antiguedadAños;
                case "Meses":
                    return (antiguedadAños * 12) + fecha_actual.Month;
                case "Dias":
                    return ((antiguedadAños * 365) + fecha_actual.Day); 
                default:
                    return -1;
            }
        }

        public int Materias_No_Aprobadas()
        {
            return MAX_MATERIAS - Cant_Materia_Aprobadas; 
        }

        public int Edad_De_Ingreso()
        {
            int edad = fecha_ingreso.Year - fecha_nacimiento.Year;

            // Si todavía no cumplió años ese año, restamos 1
            if (fecha_ingreso.Month < fecha_nacimiento.Month || (fecha_ingreso.Month == fecha_nacimiento.Month && fecha_ingreso.Day < fecha_nacimiento.Day))
            {
                edad--;
            }

            return edad;
        }
        #endregion
    }
}
