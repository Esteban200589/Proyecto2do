using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static InterfazPersistenciaCiudades getPersistenciaCiudades()
        {
            return PersistenciaCiudades.GetInstanciaCiudades();
        }

        public static InterfazPersistenciaEmpleados getPersistenciaEmpleados()
        {
            return PersistenciaEmpleados.GetInstanciaEmpleados();
        }

        public static InterfazPersistenciaMeteorologos getPersistenciaMeteorologos()
        {
            return PersistenciaMeteorologos.GetInstanciaMeteorologos();
        }

        public static InterfazPersistenciaPronosticosHora getPersistenciaPronosticosHora()
        {
            return PersistenciaPronosticoHora.GetInstanciaPronosticoHora();
        }

        public static InterfazPersistenciaPronosticosTiempo getPersistenciaPronosticosTiempo()
        {
            return PersistenciaPronosticoTiempo.GetInstanciaPronosticoTiempo();
        }
    }
}
