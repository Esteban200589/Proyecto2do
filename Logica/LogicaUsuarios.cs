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

        public void CrearUsuario(Usuario u, Usuario user_log)
        {
            if (user_log.Username != u.Username && user_log.Password != u.Password)
                throw new Exception("Solo el mismo Usuario puede modificar su contraseña.");

            if (u is Empleado)
            {
                FabricaEmpleados.CrearEmpleado((Empleado)u, user_log);
            }
            else
            {
                FabricaMeteorologos.CrearMeteorologo((Meteorologo)u, user_log);
            }
        }
        public void ModificarUsuario(Usuario u, Usuario user_log)
        {
            //if (user_log.Username != u.Username && user_log.Password != u.Password)
            //    throw new Exception("Solo el mismo Usuario puede modificar su contraseña.");

            if (u is Empleado)
            {
                FabricaEmpleados.ModificarEmpleado((Empleado)u, user_log);
            }
            else
            {
                FabricaMeteorologos.ModificarMeteorologo((Meteorologo)u, user_log);
            }
        }
        public void EliminarUsuario(Usuario u, Usuario user_log)
        {
            if (u is Empleado)
            {
                FabricaEmpleados.EliminarEmpleado((Empleado)u, user_log);
            }
            else
            {
                FabricaMeteorologos.EliminarMeteorologo((Meteorologo)u, user_log);
            }
        }

        public List<Meteorologo> ListarMeteorologosSinPronosticos(Usuario user_log, int anio)
        {
            return FabricaMeteorologos.ListarMeteorologosSinPronosticos(user_log, anio);
        }

        public Usuario LoginUsuario(string username, string password, Usuario user_log)
        {
            if (username == "")
                throw new Exception("Datos Incorrectos");
            if (password == "")
                throw new Exception("Datos Incorrectos");

            Usuario user = FabricaEmpleados.LoginEmpleado(username, password, user_log);

            if (user == null)
                user = FabricaMeteorologos.LoginMeteorologo(username, password, user_log);

            if (user == null)
                throw new Exception("Datos Incorrectos");

            return user;
        }
       
        private Usuario BuscarUsuario(string username, Usuario user_log, bool esEmpelado)
        {
            if (esEmpelado)
            {
                return FabricaEmpleados.BuscarEmpleado(username, user_log);
            }
            
            return FabricaMeteorologos.BuscarMeteorologoActivo(username, user_log);
          
        }

        public Empleado TraerEmpleado(string username, Usuario user_log)
        {
            return (Empleado)BuscarUsuario(username,user_log,true);
        }

        public Meteorologo TraerMeteorologo(string username, Usuario user_log)
        {
            return (Meteorologo)BuscarUsuario(username, user_log, false);
        }
    }
}
