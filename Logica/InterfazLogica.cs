using System;
using System.Collections.Generic;

using Entidades;
using System.Xml;

namespace Logica
{
    public interface InterfazLogicaCiudades
    {
        void CrearCiudad(Ciudad c, Usuario user_log);
        void ModificarCiudad(Ciudad c, Usuario user_log);
        void EliminarCiudad(Ciudad c, Usuario user_log);

        Ciudad BuscarCiudadActiva(string codigo, Usuario user_log);

        List<Ciudad> ListarCiudades(Usuario user_log);
        List<Ciudad> ListarCiudadesSinPronosticos(Usuario user_log, int anio);
    }

    public interface InterfazLogicaUsuarios
    {
        void CrearUsuario(Usuario u, Usuario user_log);
        void ModificarUsuario(Usuario u, Usuario user_log);
        void EliminarUsuario(Usuario u, Usuario user_log);

        Usuario LoginUsuario(string username, string password, Usuario user_log);
        Empleado TraerEmpleado(string username, Usuario user_log);
        Meteorologo TraerMeteorologo(string username, Usuario user_log);

        List<Meteorologo> ListarMeteorologosSinPronosticos(Usuario user_log, int anio);
    }

    public interface InterfazLogicaPronosticosTiempo
    {
        void CrearPronosticoTiempo(Pronostico_tiempo pt, Usuario user_log);

        List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha, Usuario user_log);
        List<Pronostico_tiempo> ListarPronosticosAnioActual(Usuario user_log);

        string PronosticosXML(DateTime fecha, Usuario user_log);
    }
}