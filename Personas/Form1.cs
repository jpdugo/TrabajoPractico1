using System.ComponentModel;
using System.Net;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Personas
{
    public partial class Form1 : Form
    {

        Registro registro;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            dataGridView4 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label1 = new Label();
            ModificarPersona = new Button();
            button6 = new Button();
            button7 = new Button();
            ((ISupportInitialize)dataGridView1).BeginInit();
            ((ISupportInitialize)dataGridView2).BeginInit();
            ((ISupportInitialize)dataGridView3).BeginInit();
            ((ISupportInitialize)dataGridView4).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 117);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(515, 245);
            dataGridView1.TabIndex = 0;
            dataGridView1.RowEnter += dataGridView1_RowEnter;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 380);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(515, 287);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(608, 117);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(545, 245);
            dataGridView3.TabIndex = 2;
            // 
            // dataGridView4
            // 
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(608, 380);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.RowHeadersWidth = 51;
            dataGridView4.Size = new Size(545, 287);
            dataGridView4.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(21, 16);
            button1.Name = "button1";
            button1.Size = new Size(161, 29);
            button1.TabIndex = 4;
            button1.Text = "Agregar Persona";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(533, 16);
            button2.Name = "button2";
            button2.Size = new Size(119, 29);
            button2.TabIndex = 5;
            button2.Text = "Agregar Autos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(188, 16);
            button3.Name = "button3";
            button3.Size = new Size(137, 29);
            button3.TabIndex = 6;
            button3.Text = "Borrar Persona";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(658, 16);
            button4.Name = "button4";
            button4.Size = new Size(120, 29);
            button4.TabIndex = 7;
            button4.Text = "Borrar Auto";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1089, 25);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 8;
            label1.Text = "label1";
            // 
            // ModificarPersona
            // 
            ModificarPersona.Location = new Point(331, 16);
            ModificarPersona.Name = "ModificarPersona";
            ModificarPersona.Size = new Size(153, 29);
            ModificarPersona.TabIndex = 9;
            ModificarPersona.Text = "Modificar Persona";
            ModificarPersona.UseVisualStyleBackColor = true;
            ModificarPersona.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(784, 16);
            button6.Name = "button6";
            button6.Size = new Size(129, 29);
            button6.TabIndex = 10;
            button6.Text = "Modificar Auto";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(518, 69);
            button7.Name = "button7";
            button7.Size = new Size(109, 29);
            button7.TabIndex = 11;
            button7.Text = "Asignar";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1208, 679);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(ModificarPersona);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView4);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Load += Form1_Load;
            ((ISupportInitialize)dataGridView1).EndInit();
            ((ISupportInitialize)dataGridView2).EndInit();
            ((ISupportInitialize)dataGridView3).EndInit();
            ((ISupportInitialize)dataGridView4).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridView dataGridView4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button ModificarPersona;
        private Button button6;
        private Button button7;
        private Label label1;

        private void Form1_Load(object sender, EventArgs e)
        {

            this.registro = new Registro();
            registro.AutosModificados += Registro_AutosModificados;
            registro.PersonasModificadas += Registro_PersonasModificadas;

            foreach (Control control in Controls)
            {
                if (control is DataGridView)
                {
                    ((DataGridView)control).MultiSelect = false;
                    ((DataGridView)control).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Solicitar los datos al usuario
                string patente = Interaction.InputBox("Ingrese la patente del auto:", "Patente", "ABC");
                if (string.IsNullOrWhiteSpace(patente)) throw new ArgumentException("La patente no puede estar vacía.");

                string marca = Interaction.InputBox("Ingrese la marca del auto:", "Marca", "Toyota");
                if (string.IsNullOrWhiteSpace(marca)) throw new ArgumentException("La marca no puede estar vacía.");

                string modelo = Interaction.InputBox("Ingrese el modelo del auto:", "Modelo", "Etios");
                if (string.IsNullOrWhiteSpace(modelo)) throw new ArgumentException("El modelo no puede estar vacío.");

                string año = Interaction.InputBox("Ingrese el año del auto:", "Año", "2015");
                if (!int.TryParse(año, out int añoParsed) || añoParsed <= 0) throw new ArgumentException("El año debe ser un número válido.");

                string precio = Interaction.InputBox("Ingrese el precio del auto:", "Precio", "123");
                if (!decimal.TryParse(precio, out decimal precioParsed) || precioParsed <= 0) throw new ArgumentException("El precio debe ser un número válido.");

                // Crear el objeto Auto
                Auto nuevoAuto = new Auto(patente, marca, modelo, añoParsed.ToString(), precioParsed);

                registro.AgregarAuto(nuevoAuto);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowError(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Rows.Count > 0)
            {
                var auto_seleccion = dataGridView3.SelectedRows[0].DataBoundItem as Auto;
                registro.BorrarAuto(auto_seleccion);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dni = Interaction.InputBox("Agregue DNI", "DNI", "38888840");
            string nombre = Interaction.InputBox("Agregue Nombre", "Nombre", "Juan");
            string apellido = Interaction.InputBox("Apellido", "Apellido", "Dugo");

            Persona persona = new Persona(dni, nombre, apellido);

            registro.AgregarPersona(persona.CloneSinAutos());
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    var o = dataGridView1.SelectedRows[0].DataBoundItem;
                    var tipo = o.GetType();
                    var properties = tipo.GetProperties();
                    var dni = (string)properties[0].GetValue(o);

                    var auto_para_mostrar = registro.ObtenerAutoConDNI(dni);

                    dataGridView2.DataSource = null; dataGridView2.DataSource = auto_para_mostrar;

                }
            }
            catch (Exception)
            {
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0 && dataGridView3.Rows.Count > 0)
            {
                string? dni, nombre, apellido;

                ExtraerPersonaGridView1(out dni, out nombre, out apellido);

                Persona persona_rearmada = new Persona(dni, nombre, apellido);
                Auto auto_seleccionado = (Auto)dataGridView3.SelectedRows[0].DataBoundItem;
                registro.AsignarAutoPersona(persona_rearmada, auto_seleccionado);

            }
        }

        private void ExtraerPersonaGridView1(out string? dni, out string? nombre, out string? apellido)
        {
            var o = dataGridView1.SelectedRows[0].DataBoundItem;
            var tipo = o.GetType();
            var properties = tipo.GetProperties();
            dni = (string)properties[0].GetValue(o);
            nombre = (string)properties[1].GetValue(o);
            apellido = (string)properties[2].GetValue(o);
        }

        private void Registro_AutosModificados(object sender, EventArgs e)
        {
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = registro.ObtenerAutos();

            registro.ObtenerAutosConDueño();
        }

        private void Registro_PersonasModificadas(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = registro.ObtenerPersonas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string? dni, nombre, apellido;
            ExtraerPersonaGridView1(out dni, out nombre, out apellido);
            registro.BorrarPersona(new Persona(dni, nombre, apellido));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string? dni, nombre, apellido;
            ExtraerPersonaGridView1(out dni, out nombre, out apellido);

            // TODO : Hay que actualizar el dueño en los autos tambien!
            //var dni_nuevo = Interaction.InputBox("DNI Nuevo", "DNI", dni);
            var nombre_nuevo = Interaction.InputBox("Nombre Nuevo", "Nombre", nombre);
            var apellido_nuevo = Interaction.InputBox("Apellido Nuevo", "Apellido", apellido);

            registro.ModificarPersonas(new Persona(dni, nombre_nuevo, apellido_nuevo));



        }
    }
}
