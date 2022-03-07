using System;
using System.Collections.Generic;

using Entidades;
using System.Xml;

namespace Logica
{
    public interface InterfazLogicaCiudades
    {
        void CrearCiudad(Ciudad c);
        void ModificarCiudad(Ciudad c);
        void EliminarCiudad(Ciudad c);

        Ciudad BuscarCiudadActiva(string codigo);

        List<Ciudad> ListarCiudades();
        List<Ciudad> ListarCiudadesSinPronosticos();
    }

    public interface InterfazLogicaUsuarios
    {
        void CrearUsuario(Usuario u);
        void ModificarUsuario(Usuario u);
        void EliminarUsuario(Usuario u);

        Usuario LoginUsuario(string username, string password);
        Usuario BuscarUsuario(string username);
    }

    public interface InterfazLogicaPronosticosTiempo
    {
        void CrearPronosticoTiempo(Pronostico_tiempo pt);

        List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha);
        List<Pronostico_tiempo> ListarPronosticosAnioActual();

        XmlDocument PronosticosXML(DateTime fecha);
    }
}

// XmlDocument ListadoNoticiasXML();}