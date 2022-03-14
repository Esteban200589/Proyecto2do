using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Entidades;
using Logica;

namespace PronosticosWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {
        #region ciudades

        void IServicio.CrearCiudad(Ciudad c, Usuario user_log)
        {
            FabricaLogica.GetLogicaCiudades().CrearCiudad(c, user_log);
        }

        void IServicio.ModificarCiudad(Ciudad c, Usuario user_log)
        {
            FabricaLogica.GetLogicaCiudades().ModificarCiudad(c, user_log);
        }

        void IServicio.EliminarCiudad(Ciudad c, Usuario user_log)
        {
            FabricaLogica.GetLogicaCiudades().EliminarCiudad(c, user_log);
        }

        Ciudad IServicio.BuscarCiudadActiva(string codigo, Usuario user_log)
        {
            return FabricaLogica.GetLogicaCiudades().BuscarCiudadActiva(codigo, user_log);
        }

        List<Ciudad> IServicio.ListarCiudades(Usuario user_log)
        {
            return FabricaLogica.GetLogicaCiudades().ListarCiudades(user_log);
        }

        List<Ciudad> IServicio.ListarCiudadesSinPronosticos(Usuario user_log, int anio)
        {
            return FabricaLogica.GetLogicaCiudades().ListarCiudadesSinPronosticos(user_log, anio);
        }

        #endregion

        #region usuarios

        void IServicio.CrearUsuario(Usuario u, Usuario user_log)
        {
            FabricaLogica.GetLogicaUsuarios().CrearUsuario(u, user_log);
        }

        void IServicio.ModificarUsuario(Usuario u, Usuario user_log)
        {
            FabricaLogica.GetLogicaUsuarios().ModificarUsuario(u, user_log);
        }

        void IServicio.EliminarUsuario(Usuario u, Usuario user_log)
        {
            FabricaLogica.GetLogicaUsuarios().EliminarUsuario(u, user_log);
        }

        Usuario IServicio.LoginUsuario(string username, string password, Usuario user_log)
        {
            return FabricaLogica.GetLogicaUsuarios().LoginUsuario(username, password, user_log);
        }

        Empleado IServicio.TraerEmpleado(string username, Usuario user_log)
        {
            return FabricaLogica.GetLogicaUsuarios().TraerEmpleado(username,user_log);
        }
        Meteorologo IServicio.TraerMeteorologo(string username, Usuario user_log)
        {
            return FabricaLogica.GetLogicaUsuarios().TraerMeteorologo(username, user_log);
        }

        List<Meteorologo> IServicio.ListarMeteorologosSinPronosticos(Usuario user_log, int anio)
        {
            return FabricaLogica.GetLogicaUsuarios().ListarMeteorologosSinPronosticos(user_log, anio);
        }

        #endregion

        #region pronosticos

        void IServicio.CrearPronosticoTiempo(Pronostico_tiempo pt, Usuario user_log)
        {
            FabricaLogica.GetLogicaPronosticosTiempo().CrearPronosticoTiempo(pt, user_log);
        }

        List<Pronostico_tiempo> IServicio.ListarPronosticosPorFecha(DateTime fecha, Usuario user_log)
        {
            return FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosPorFecha(fecha, user_log);
        }

        List<Pronostico_tiempo> IServicio.ListarPronosticosAnioActual(Usuario user_log)
        {
            return FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosAnioActual(user_log);
        }

        string IServicio.PronosticosXML(DateTime fecha, Usuario user_log)
        {
            return FabricaLogica.GetLogicaPronosticosTiempo().PronosticosXML(fecha, user_log);
        }

        #endregion
    }
}
