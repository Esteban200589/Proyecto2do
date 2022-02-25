using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuarios
    {
        private static LogicaUsuarios instancia = null;
        private LogicaUsuarios() { }
        public static LogicaUsuarios GetInstanciaUsuarios()
        {
            if (instancia == null)
                instancia = new LogicaUsuarios();

            return instancia;
        }

        static InterfazPersistenciaEmpleados FabricaEmpleados = FabricaPersistencia.getPersistenciaEmpleados();
        static InterfazPersistenciaMeteorologos FabricaMeteorologos = FabricaPersistencia.getPersistenciaMeteorologos();

        public void LoginEmpleado(string username, string password)
        {
            FabricaEmpleados.LoginEmpleado(username, password);
        }

        public void BuscarEmpleado(string username)
        {
            FabricaEmpleados.BuscarEmpleado(username);
        }

        public void LoginMeteorologo(string username, string password)
        {
            FabricaMeteorologos.LoginMeteorologo(username, password);
        }

        public void BuscarMeteorologo(string username)
        {
            FabricaMeteorologos.BuscarMeteorologoActivo(username);
        }
    }
}
