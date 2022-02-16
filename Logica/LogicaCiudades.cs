using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;

namespace Logica
{
    class LogicaCiudades : InterfazLogicaCiudades
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


        public void CrearCiudad(Ciudad c)
        {
            FabricaCiudades.CrearCiudad(c);
        }
        public void ModificarCiudad(Ciudad c)
        {
            FabricaCiudades.ModificarCiudad(c);
        }
        public void EliminarCiudad(Ciudad c)
        {
            FabricaCiudades.EliminarCiudad(c);
        }

        public Ciudad BuscarCiudadActiva(string codigo)
        {
            return FabricaCiudades.BuscarCiudadActiva(codigo);
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
