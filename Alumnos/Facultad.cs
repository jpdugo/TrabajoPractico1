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

        public bool ModificarAlumno(int legajo, Alumno alumno_modificado)
        {
            if (alumnos == null || !alumnos.Any())
                return false;

            var alumno = alumnos.FirstOrDefault(a => a.Legajo == legajo);
            if (alumno != null)
            {
                alumno.Nombre = alumno_modificado.Nombre;
                alumno.Apellido = alumno_modificado.Apellido;
                alumno.Activo = alumno_modificado.Activo;
                alumno.Cant_Materia_Aprobadas = alumno_modificado.Cant_Materia_Aprobadas;
                return true;
            }

            return false;
        }


    }
}
