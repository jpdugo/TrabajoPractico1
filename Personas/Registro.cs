using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Personas
{
    internal class Registro
    {

        private readonly List<Persona> _personas;
        private readonly List<Auto> _autos;
        public Registro()
        {

            _personas = new List<Persona>();
            _autos = new List<Auto>();
        }

        public void AgregarAuto(Auto pAuto)
        {
            _autos.Add(pAuto.CloneTipado());
            OnAutosModificados();
        }

        public List<Auto> ObtenerAutos()
        {
            var autos_obtenidos = new List<Auto>();
            foreach (Auto pAuto in _autos)
            {
                autos_obtenidos.Add(pAuto.CloneTipado()); // TODO: Esto esta rompiendo el encapsulamiento
            }
            return autos_obtenidos;
        }

        public void BorrarAuto(Auto pAuto)
        {
            // aca hay que borrar no solo el auto seleccionado, pero borrar el titular del auto tambien, esto se puede hacer facil si rompo el encapsulamiento pero no es nada recomendable.
            var auto = _autos.Find(a => a.Patente == pAuto.Patente);
            if (auto != null)
            {
                if (auto.Dueño() != null)
                {
                    Persona persona_dueña = _personas.Find(p => p.DNI == auto.Dueño().DNI);
                    persona_dueña.BorrarAuto(auto.CloneTipado());
                }
                _autos.Remove(auto);
            }

            OnAutosModificados(); // Notificar que la lista cambió
        }



        //public void BorrarPersona

        public void AgregarPersona(Persona persona)
        {
            _personas.Add(persona);
            OnPersonasModificadas();
        }

        public void BorrarPersona(Persona persona)
        {
            var persona_encontrada = _personas.Find(p => p.DNI.Equals(persona.DNI));

            if (persona_encontrada != null)
            {
                foreach (Auto auto in persona_encontrada.Lista_de_Autos())
                {
                   var auto_encontrado = _autos.Find(a => a.Patente == auto.Patente);
                   _autos.Remove(auto);
                }
                _personas.Remove(persona_encontrada);
                OnPersonasModificadas();
            }
        }

        public List<Object> ObtenerPersonas()
        {
            var datos = from persona in _personas
                   select new {DNI = persona.DNI, Nombre = persona.Nombre, persona.Apellido};
            return datos.ToList<Object>();
        }

        public void AsignarAutoPersona(Persona persona, Auto auto)
        {
            var auto_encontrado = _autos.Find(a => a.Patente == auto.Patente);
            var persona_encontrado = _personas.Find(p => p.DNI.Equals(persona.DNI));

            if (auto_encontrado != null && persona_encontrado != null)
            {
                persona_encontrado.AgregarAuto(auto.CloneTipado());
                auto_encontrado.AgregarTitular(persona_encontrado.CloneSinAutos());
                
            }
            OnPersonasModificadas();
        }

        public List<Auto> ObtenerAutoConDNI(string dni)
        {
           var resultado = _personas.Find(p => p.DNI.Equals(dni));
            if (resultado != null)
            {
                return resultado.Lista_de_Autos();
            }
            else { return new List<Auto>(); }
        }

        #region "eventos"
        public event EventHandler? AutosModificados;
        public event EventHandler? PersonasModificadas;

        protected virtual void OnAutosModificados()
        {
            AutosModificados?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnPersonasModificadas()
        {
            PersonasModificadas?.Invoke(this, EventArgs.Empty);
        }
        #endregion



        public void ModificarPersonas(Persona persona)
        {
            var persona_encontrada = _personas.Find(p => p.DNI == persona.DNI);

            if (persona_encontrada != null)
            {
                persona_encontrada.Nombre = persona.Nombre;
                persona_encontrada.Apellido = persona.Apellido;

                foreach (Auto auto in _autos)
                {
                    //TODO : si el dueño es null me rompe por todas partes
                    if(auto.Dueño().DNI == persona.DNI)
                    {
                        auto.ModificarTitular(new Persona(persona.DNI, persona_encontrada.Nombre, persona_encontrada.Apellido));
                    }

                }
                OnPersonasModificadas();
            }

            

        }
    }
}
