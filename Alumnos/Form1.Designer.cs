﻿namespace Alumnos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            AgregarAlumnoBoton = new Button();
            BorrarAlumnoBoton = new Button();
            ModificarAlumnoBoton = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(134, 62);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(692, 141);
            dataGridView1.TabIndex = 0;
            // 
            // AgregarAlumnoBoton
            // 
            AgregarAlumnoBoton.Location = new Point(840, 62);
            AgregarAlumnoBoton.Margin = new Padding(3, 2, 3, 2);
            AgregarAlumnoBoton.Name = "AgregarAlumnoBoton";
            AgregarAlumnoBoton.Size = new Size(134, 22);
            AgregarAlumnoBoton.TabIndex = 1;
            AgregarAlumnoBoton.Text = "Agregar Alumno";
            AgregarAlumnoBoton.UseVisualStyleBackColor = true;
            AgregarAlumnoBoton.Click += AgregarAlumnoBoton_Click;
            // 
            // BorrarAlumnoBoton
            // 
            BorrarAlumnoBoton.Location = new Point(840, 121);
            BorrarAlumnoBoton.Margin = new Padding(3, 2, 3, 2);
            BorrarAlumnoBoton.Name = "BorrarAlumnoBoton";
            BorrarAlumnoBoton.Size = new Size(134, 22);
            BorrarAlumnoBoton.TabIndex = 2;
            BorrarAlumnoBoton.Text = "Borrar Alumno";
            BorrarAlumnoBoton.UseVisualStyleBackColor = true;
            BorrarAlumnoBoton.Click += BorrarAlumnoBoton_Click;
            // 
            // ModificarAlumnoBoton
            // 
            ModificarAlumnoBoton.Location = new Point(840, 182);
            ModificarAlumnoBoton.Margin = new Padding(3, 2, 3, 2);
            ModificarAlumnoBoton.Name = "ModificarAlumnoBoton";
            ModificarAlumnoBoton.Size = new Size(134, 22);
            ModificarAlumnoBoton.TabIndex = 3;
            ModificarAlumnoBoton.Text = "Modificar Alumno";
            ModificarAlumnoBoton.UseVisualStyleBackColor = true;
            ModificarAlumnoBoton.Click += ModificarAlumnoBoton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(134, 232);
            richTextBox1.Margin = new Padding(3, 2, 3, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(426, 91);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1317, 542);
            Controls.Add(richTextBox1);
            Controls.Add(ModificarAlumnoBoton);
            Controls.Add(BorrarAlumnoBoton);
            Controls.Add(AgregarAlumnoBoton);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button AgregarAlumnoBoton;
        private Button BorrarAlumnoBoton;
        private Button ModificarAlumnoBoton;
        private RichTextBox richTextBox1;
    }
}
