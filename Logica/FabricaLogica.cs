using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class FabricaLogica
    {
        public static InterfazLogicaCiudades GetLogicaCiudades()
        {
            return LogicaCiudades.GetInstanciaCiudades();
        }

        public static InterfazLogicaUsuarios GetLogicaUsuarios()
        {
            return LogicaUsuarios.GetInstanciaUsuarios();
        }

        public static InterfazLogicaPronosticosTiempo GetLogicaPronosticosTiempo()
        {
            return LogicaPronosticoTiempo.GetInstanciaPronosticoTiempo();
        }
    }
}
