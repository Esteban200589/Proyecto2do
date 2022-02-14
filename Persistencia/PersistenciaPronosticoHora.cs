using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaPronosticoHora
    {
        private static PersistenciaPronosticoHora instancia = null;
        private PersistenciaPronosticoHora() { }
        public static PersistenciaPronosticoHora GetInstanciaPronosticoHora()
        {
            if (instancia == null)
                instancia = new PersistenciaPronosticoHora();

            return instancia;
        }


    }
}
