using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Personas
{
    internal class Auto : ICloneable
    {
        public Auto(string Patente, string Marca, string Modelo, string Año, decimal Precio)
        {
            this.Patente = Patente;
            this.Marca = Marca; 
            this.Modelo = Modelo;
            this.Año = Año;
            this.Precio = Precio;
        }

        private Persona? _titular;

        public void AgregarTitular(Persona titular) //TODO : Hay que sacarle lista_autos antes de mandarla aca
        {
            try
            {
                if (titular is not null)
                {
                    this._titular = titular;
                }
                else
                {
                    throw new ArgumentException("El objeto tiene que ser de tipo persona");
                }
            }
            catch (Exception ex) {
                MessageBoxHelper.ShowError(ex);
            }

        }

        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Año { get; set; }
        public decimal Precio { get; set; }

        ~Auto()
        {
            MessageBox.Show($"Patente: {this.Patente}");
        }

        public Persona Dueño()
        {
            if (_titular is not null)
            { 
                return this._titular.CloneTipado();
            }
            else
            {
                return null;
            }
        }

        public void ModificarTitular(Persona persona)
        {
            _titular = persona;
        }

        public Object Clone()
        {
            return this.MemberwiseClone();
        }

        public Auto CloneTipado()
        {
            return (Auto)this.Clone();
        }
    }
}
