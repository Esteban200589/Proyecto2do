using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;

namespace Logica
{
    internal class LogicaCiudades : InterfazLogicaCiudades
    {
        private static LogicaCiudades instancia = null;
        private LogicaCiudades() { }
        public static LogicaCiudades GetInstanciaCiudades()
        {
            if (instancia == null)
                instancia = new LogicaCiudades();

            return instancia;
        }

        static InterfazPersistenciaCiudades FabricaCiudades = FabricaPersistencia.getPersistenciaCiudades();


        public void CrearCiudad(Ciudad c, Usuario u)
        {
            FabricaCiudades.CrearCiudad(c,u);
        }
        public void ModificarCiudad(Ciudad c, Usuario u)
        {
            FabricaCiudades.ModificarCiudad(c,u);
        }
        public void EliminarCiudad(Ciudad c, Usuario u)
        {
            FabricaCiudades.EliminarCiudad(c,u);
        }

        public Ciudad BuscarCiudadActiva(string codigo, Usuario u)
        {
            return FabricaCiudades.BuscarCiudadActiva(codigo,u);
        }

        public List<Ciudad> ListarCiudades()
        {
            return FabricaCiudades.ListarCiudades();
        }
        public List<Ciudad> ListarCiudadesSinPronosticos()
        {
            return FabricaCiudades.ListarCiudadesSinPronosticos();
        }
    }
}
