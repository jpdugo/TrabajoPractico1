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
                if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede estar vac�o.");

                string apellido = Interaction.InputBox("Ingrese el apellido del alumno:", "Agregar Alumno", "");
                if (string.IsNullOrWhiteSpace(apellido)) throw new Exception("El apellido no puede estar vac�o.");

                string fechaNacimiento = Interaction.InputBox("Ingrese la fecha de nacimiento (dd/MM/yyyy):", "Agregar Alumno", "");
                if (!DateTime.TryParseExact(fechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha1)) throw new Exception($"La fecha '{fechaNacimiento}' no tiene un formato v�lido. Use el formato dd/MM/yyyy.");

                string fechaIngreso = Interaction.InputBox("Ingrese la fecha de ingreso (dd/MM/yyyy):", "Agregar Alumno", "");
                if (!DateTime.TryParseExact(fechaIngreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha2)) throw new Exception($"La fecha '{fechaIngreso}' no tiene un formato v�lido. Use el formato dd/MM/yyyy.");

                string activoInput = Interaction.InputBox("�Est� activo? (true/false):", "Agregar Alumno", "true");
                if (!bool.TryParse(activoInput, out bool activo)) throw new Exception("El valor de activo no es v�lido.");

                string materiasAprobadasInput = Interaction.InputBox("Ingrese la cantidad de materias aprobadas:", "Agregar Alumno", "0");
                if (!int.TryParse(materiasAprobadasInput, out int cantMateriasAprobadas) || cantMateriasAprobadas < 0)
                    throw new Exception("La cantidad de materias aprobadas no es v�lida.");

                Alumno nuevoAlumno = new(nombre, apellido, fecha1, fecha2, activo, cantMateriasAprobadas);

                facultad.AgregarAlumno(nuevoAlumno);

                Mostrar();

                MessageBox.Show("Alumno agregado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            try
            {
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un alumno para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (row.DataBoundItem is Alumno alumnoSeleccionado)
                    {
                        bool eliminado = facultad.EliminarAlumno(alumnoSeleccionado.Legajo);
                        if (!eliminado)
                        {
                            MessageBox.Show($"No se pudo eliminar al alumno con Legajo: {alumnoSeleccionado.Legajo}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                Mostrar();
                MessageBox.Show("Alumno(s) eliminado(s) correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarAlumnoBoton_Click(object sender, EventArgs e)
        {
            try
            {

                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione un alumno para modificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.DataBoundItem is not Alumno alumnoSeleccionado)
                {
                    MessageBox.Show("Error al obtener el alumno seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Capturar datos del usuario usando Interaction.InputBox
                string nuevoNombre = Interaction.InputBox($"Nombre actual: {alumnoSeleccionado.Nombre}\nIngrese el nuevo nombre (o deje vac�o para no modificar):", "Modificar Alumno", alumnoSeleccionado.Nombre);

                string nuevoApellido = Interaction.InputBox($"Apellido actual: {alumnoSeleccionado.Apellido}\nIngrese el nuevo apellido (o deje vac�o para no modificar):", "Modificar Alumno", alumnoSeleccionado.Apellido);

                string nuevaFechaNacimiento = Interaction.InputBox("Ingrese la fecha de nacimiento (dd/MM/yyyy) (o deje vac�o para no modificar):", "Modificar Alumno", "");
                // Obtener el valor actual de fecha_nacimiento usando reflexi�n
                var fieldInfo = typeof(Alumno).GetField("fecha_nacimiento", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (fieldInfo == null)
                {
                    throw new Exception("El campo 'fecha_nacimiento' no se encontr� en la clase Alumno.");
                }

                DateTime fecha1 = (DateTime)(fieldInfo.GetValue(alumnoSeleccionado) ?? throw new Exception("El valor de 'fecha_nacimiento' es nulo."));

                // Validar y actualizar la fecha si el usuario ingresa un nuevo valor
                if (!string.IsNullOrWhiteSpace(nuevaFechaNacimiento))
                {
                    if (!DateTime.TryParseExact(nuevaFechaNacimiento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha1))
                    {
                        throw new Exception($"La fecha '{nuevaFechaNacimiento}' no tiene un formato v�lido. Use el formato dd/MM/yyyy.");
                    }
                }

                string nuevaFechaIngreso = Interaction.InputBox("Ingrese la fecha de ingreso (dd/MM/yyyy) (o deje vac�o para no modificar):", "Modificar Alumno", "");
                //if (!DateTime.TryParseExact(nuevaFechaIngreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha2)) throw new Exception($"La fecha '{nuevaFechaIngreso}' no tiene un formato v�lido. Use el formato dd/MM/yyyy.");
                // Obtener el valor actual de fecha_ingreso usando reflexi�n
                var fieldInfoIngreso = typeof(Alumno).GetField("fecha_ingreso", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                if (fieldInfoIngreso == null)
                {
                    throw new Exception("El campo 'fecha_ingreso' no se encontr� en la clase Alumno.");
                }

                DateTime fecha2 = (DateTime)(fieldInfoIngreso.GetValue(alumnoSeleccionado) ?? throw new Exception("El valor de 'fecha_ingreso' es nulo."));

                // Validar y actualizar la fecha si el usuario ingresa un nuevo valor
                if (!string.IsNullOrWhiteSpace(nuevaFechaIngreso))
                {
                    if (!DateTime.TryParseExact(nuevaFechaIngreso, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha2))
                    {
                        throw new Exception($"La fecha '{nuevaFechaIngreso}' no tiene un formato v�lido. Use el formato dd/MM/yyyy.");
                    }
                }

                string nuevoActivo = Interaction.InputBox($"Estado actual (Activo): {alumnoSeleccionado.Activo}\nIngrese el nuevo estado (true/false) (o deje el valor actual para no modificar):", "Modificar Alumno", alumnoSeleccionado.Activo.ToString());
                bool newActivo = alumnoSeleccionado.Activo;
                if (!string.IsNullOrWhiteSpace(nuevoActivo))
                {
                    if (!bool.TryParse(nuevoActivo, out newActivo))
                    {
                        throw new Exception("El valor de activo no es v�lido.");
                    }
                }

                string nuevasMateriasAprobadas = Interaction.InputBox($"Materias aprobadas actuales: {alumnoSeleccionado.Cant_Materia_Aprobadas}\nIngrese la nueva cantidad de materias aprobadas (o deje vac�o para no modificar):", "Modificar Alumno", alumnoSeleccionado.Cant_Materia_Aprobadas.ToString());
                int cantMateriasAprobadas = alumnoSeleccionado.Cant_Materia_Aprobadas;
                if (!string.IsNullOrWhiteSpace(nuevasMateriasAprobadas))
                {
                    if (!int.TryParse(nuevasMateriasAprobadas, out cantMateriasAprobadas) || cantMateriasAprobadas < 0)
                    {
                        throw new Exception("La cantidad de materias aprobadas no es v�lida.");
                    }
                }

                facultad.ModificarAlumno(alumnoSeleccionado.Legajo, string.IsNullOrWhiteSpace(nuevoNombre) ? alumnoSeleccionado.Nombre : nuevoNombre,
                     string.IsNullOrWhiteSpace(nuevoApellido) ? alumnoSeleccionado.Apellido : nuevoApellido, fecha1, fecha2, newActivo, cantMateriasAprobadas);

                Mostrar();

                MessageBox.Show("Alumno modificado correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
