using System.Globalization;
using Microsoft.VisualBasic;

namespace Alumnos
{
    public partial class Form1 : Form
    {
        Facultad facultad = new Facultad();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void AgregarAlumnoBoton_Click(object sender, EventArgs e)
        {
            try
            {
                // Capturar datos del usuario usando Interaction.InputBox
                string nombre = Interaction.InputBox("Ingrese el nombre del alumno:", "Agregar Alumno", "");
                if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede estar vacío.");

                string apellido = Interaction.InputBox("Ingrese el apellido del alumno:", "Agregar Alumno", "");
                if (string.IsNullOrWhiteSpace(apellido)) throw new Exception("El apellido no puede estar vacío.");

                string fechaNacimiento = Interaction.InputBox("Ingrese la fecha de nacimiento (dd/MM/yyyy):", "Agregar Alumno", "");
                if (!DateTime.TryParseExact(fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha1)) throw new Exception($"La fecha '{fechaNacimiento}' no tiene un formato válido. Use el formato dd/MM/yyyy.");

                string fechaIngreso = Interaction.InputBox("Ingrese la fecha de ingreso (dd/MM/yyyy):", "Agregar Alumno", ""); 
                if (!DateTime.TryParseExact(fechaIngreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha2)) throw new Exception($"La fecha '{fechaIngreso}' no tiene un formato válido. Use el formato dd/MM/yyyy.");

                string activoInput = Interaction.InputBox("¿Está activo? (true/false):", "Agregar Alumno", "true");
                if (!bool.TryParse(activoInput, out bool activo)) throw new Exception("El valor de activo no es válido.");

                string materiasAprobadasInput = Interaction.InputBox("Ingrese la cantidad de materias aprobadas:", "Agregar Alumno", "0");
                if (!int.TryParse(materiasAprobadasInput, out int cantMateriasAprobadas) || cantMateriasAprobadas < 0)
                    throw new Exception("La cantidad de materias aprobadas no es válida.");

                Alumno nuevoAlumno = new(nombre, apellido, fecha1, fecha2, activo, cantMateriasAprobadas);

                facultad.AgregarAlumno(nuevoAlumno);

                Mostrar();

                MessageBox.Show("Alumno agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mostrar()
        {
            dataGridView1.DataSource = null; dataGridView1.DataSource = facultad.alumnos;
        }

        private void BorrarAlumnoBoton_Click(object sender, EventArgs e)
        {

        }

        private void ModificarAlumnoBoton_Click(object sender, EventArgs e)
        {

        }
    }
}
