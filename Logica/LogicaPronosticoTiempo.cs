using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;

namespace Logica
{
    internal class LogicaPronosticoTiempo : InterfazLogicaPronosticosTiempo
    {

        private static LogicaPronosticoTiempo instancia = null;
        private LogicaPronosticoTiempo() { }
        public static LogicaPronosticoTiempo GetInstanciaPronosticoTiempo()
        {
            if (instancia == null)
                instancia = new LogicaPronosticoTiempo();

            return instancia;
        }

        static InterfazPersistenciaPronosticosTiempo FabricaTiempo = FabricaPersistencia.getPersistenciaPronosticosTiempo();

        public void CrearPronosticoTiempo(Pronostico_tiempo pt)
        {
            FabricaTiempo.CrearPronosticoTiempo(pt);
        }

        public List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha)
        {
            return FabricaTiempo.ListarPronosticosFecha(fecha);
        }

        public List<Pronostico_tiempo> ListarPronosticosAnioActual()
        {
            return FabricaTiempo.ListarPronosticosAnioActual();
        }
    }
}
