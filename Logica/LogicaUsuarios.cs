using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;

namespace Logica
{
    internal class LogicaUsuarios : InterfazLogicaUsuarios
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

        public void CrearUsuario(Usuario u)
        {
            if (u is Empleado)
            {
                FabricaEmpleados.CrearEmpleado((Empleado)u);
            }
            else
            {
                FabricaMeteorologos.CrearMeteorologo((Meteorologo)u);
            }
        }
        public void ModificarUsuario(Usuario u)
        {
            if (u is Empleado)
            {
                FabricaEmpleados.ModificarEmpleado((Empleado)u);
            }
            else
            {
                FabricaMeteorologos.ModificarMeteorologo((Meteorologo)u);
            }
        }
        public void EliminarUsuario(Usuario u)
        {
            if (u is Empleado)
            {
                FabricaEmpleados.EliminarEmpleado((Empleado)u);
            }
            else
            {
                FabricaMeteorologos.EliminarMeteorologo((Meteorologo)u);
            }
        }

        public Usuario LoginUsuario(string username, string password)
        {
            Usuario user = FabricaEmpleados.LoginEmpleado(username, password);

            if (user == null)
                user = FabricaMeteorologos.LoginMeteorologo(username, password);
            
            return user;
        }
        public Usuario BuscarUsuario(string username)
        {
            Usuario user = FabricaEmpleados.BuscarEmpleado(username);

            if (user == null)
                user = FabricaMeteorologos.BuscarMeteorologoActivo(username);

            return user;
        }
    }
}
