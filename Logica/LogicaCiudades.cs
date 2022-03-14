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


        public void CrearCiudad(Ciudad c, Usuario user_log)
        {
            FabricaCiudades.CrearCiudad(c, user_log);
        }
        public void ModificarCiudad(Ciudad c, Usuario user_log)
        {
            FabricaCiudades.ModificarCiudad(c, user_log);
        }
        public void EliminarCiudad(Ciudad c, Usuario user_log)
        {
            FabricaCiudades.EliminarCiudad(c, user_log);
        }

        public Ciudad BuscarCiudadActiva(string codigo, Usuario user_log)
        {
            return FabricaCiudades.BuscarCiudadActiva(codigo, user_log);
        }

        public List<Ciudad> ListarCiudades(Usuario user_log)
        {
            return FabricaCiudades.ListarCiudades(user_log);
        }
        public List<Ciudad> ListarCiudadesSinPronosticos(Usuario user_log, int anio)
        {
            return FabricaCiudades.ListarCiudadesSinPronosticos(user_log, anio);
        }
    }
}
