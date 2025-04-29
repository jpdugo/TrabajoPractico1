namespace Alumnos
{
    internal class Alumno
    {
        #region "propiedades"

        private static int ultimoLegajo = 0;

        public int Legajo { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        private DateTime fecha_nacimiento;
        private DateTime fecha_ingreso;
        public int Edad { get; private set; }
        public Boolean Activo { get; set; }
        private int cant_materia_aprobadas;

        DateTime fecha_actual = DateTime.Now;

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
            Fecha_Nacimiento = fecha_nacimiento; // validar bien
            Fecha_Ingreso = fecha_ingreso; // validar bien
            Activo = activo;
            Cant_Materia_Aprobadas = cant_materia_aprobadas;

            // calculo la edad de manera dinamica
            Edad = fecha_actual.Year - fecha_nacimiento.Year;
        }

        #endregion
        #region "metodos"
        public int Antiguedad(Unidades unidad)
        {
            
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
            // esto puede romper si en el constructor se pasa un valor raro
            return 36 - Cant_Materia_Aprobadas; 
        }

        public int Edad_De_Ingreso()
        {
            int edadIngeso = fecha_ingreso.Year - fecha_nacimiento.Year;
            int edadIngresoMeses = fecha_ingreso.Month - fecha_ingreso.Month;

            if (edadIngresoMeses < 0)
            {
                edadIngeso--;
            }

            return edadIngeso;
        }
        #endregion


    }
}
