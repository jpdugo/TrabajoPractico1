using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    internal class Persona : ICloneable
    {
        public Persona(string DNI, string Nombre, string Apellido)
        {

            this.DNI = DNI;
            this.Nombre = Nombre;
            this.Apellido = Apellido;

        }

        private List<Auto> lista_autos;

        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        #region "metodos"

        public void AgregarAuto(Auto pAuto)
        {
            lista_autos.Add(pAuto);
        }

        public void BorrarAuto(Auto pAuto)
        {
            Auto auto_a_borrar = lista_autos.Find(a => a.Patente == pAuto.Patente);
            if (auto_a_borrar != null)
            {
                lista_autos.Remove(auto_a_borrar);
            }

        }

        public List<Auto> Lista_de_Autos()
        {
            try
            {
                if (this.Cantidad_de_Autos() > 0)
                {
                    List<Auto> lista_autos_a_retornar = new List<Auto>();
                    foreach (var item in lista_autos)
                    {
                        lista_autos_a_retornar.Add(item.CloneTipado());
                    }

                    return lista_autos_a_retornar;
                }
                else
                {
                    return new List<Auto>();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e}");
                throw;
            }
        }

        public int Cantidad_de_Autos()
        {
            return lista_autos.Count;  
        }

        #endregion

        ~Persona()
        {
            MessageBox.Show($"DNI: {this.DNI}");
        }

        public object Clone()
        {
            var persona_shallow = (Persona)this.MemberwiseClone(); // ojo que se va a romper todo cuando clones dentro de Auto quizas
            persona_shallow.lista_autos = new List<Auto>();

            if (this.lista_autos != null)
            {
                foreach (Auto auto in this.lista_autos)
                {
                    persona_shallow.lista_autos.Add(auto.CloneTipado());
                }
            }

            return persona_shallow;
        }

        public Persona CloneTipado()
        {
            return (Persona)this.MemberwiseClone();
        }

        public Persona CloneSinAutos()
        {
            var persona_clone = this.CloneTipado();
            persona_clone.lista_autos = new List<Auto>();
            return persona_clone;
        }
    }
}
