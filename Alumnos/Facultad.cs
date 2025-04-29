namespace Alumnos
{
    internal class Facultad
    {
        public List<Alumno> alumnos; // viola el encapsulamiento

        public Facultad()
        {
           alumnos = new List<Alumno>();
        }

        public void AgregarAlumno(Alumno alumno_a_agregar)
        {
            alumnos.Add(alumno_a_agregar);
        }

        public bool EliminarAlumno(int legajo)
        {
            if (alumnos == null || !alumnos.Any())
                return false;

            var alumno = alumnos.FirstOrDefault(a => a.Legajo == legajo);
            if (alumno != null)
            {
                alumnos.Remove(alumno);
                return true;
            }

            return false;
        }

        public bool ModificarAlumno(int legajo, string nombre, string apellido, DateTime fecha_nacimiento, 
            DateTime fecha_ingreso, Boolean activo, int cant_materia_aprobadas)
        {
            if (alumnos == null || !alumnos.Any())
                return false;

            var alumno = alumnos.FirstOrDefault(a => a.Legajo == legajo);
            if (alumno != null)
            {
                alumno.Nombre = nombre;
                alumno.Apellido = apellido;
                alumno.Activo = activo;
                alumno.Fecha_Nacimiento = fecha_nacimiento;
                alumno.Fecha_Ingreso = fecha_ingreso;
                alumno.Cant_Materia_Aprobadas = cant_materia_aprobadas;
                alumno.CalcularEdad(fecha_nacimiento);
                return true;
            }

            return false;
        }


    }
}
