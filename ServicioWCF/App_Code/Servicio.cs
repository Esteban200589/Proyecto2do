using System;
using System.Collections.Generic;
//using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Entidades;
using Logica;

// NOTA: puede usar el comando "Cambiar nombre" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
public class Servicio : IServicio
{
    #region ciudades

    void IServicio.CrearCiudad(Ciudad c)
    {
        FabricaLogica.GetLogicaCiudades().CrearCiudad(c);
    }

    void IServicio.ModificarCiudad(Ciudad c)
    {
        FabricaLogica.GetLogicaCiudades().ModificarCiudad(c);
    }

    void IServicio.EliminarCiudad(Ciudad c)
    {
        FabricaLogica.GetLogicaCiudades().EliminarCiudad(c);
    }

    Ciudad IServicio.BuscarCiudadActiva(string codigo)
    {
        return FabricaLogica.GetLogicaCiudades().BuscarCiudadActiva(codigo);
    }

    List<Ciudad> IServicio.ListarCiudades()
    {
        return FabricaLogica.GetLogicaCiudades().ListarCiudades();
    }

    List<Ciudad> IServicio.ListarCiudadesSinPronosticos()
    {
        return FabricaLogica.GetLogicaCiudades().ListarCiudadesSinPronosticos();
    }

    #endregion

    #region usuarios

    Usuario IServicio.LoginUsuario(string username, string password)
    {
        return FabricaLogica.GetLogicaUsuarios().LoginUsuario(username, password);
    }

    Usuario IServicio.BuscarUsuario(string username)
    {
        return FabricaLogica.GetLogicaUsuarios().BuscarUsuario(username);
    }

    #endregion

    #region pronosticos

    void IServicio.CrearPronosticoTiempo(Pronostico_tiempo pt)
    {
        FabricaLogica.GetLogicaPronosticosTiempo().CrearPronosticoTiempo(pt);
    }

    List<Pronostico_tiempo> IServicio.ListarPronosticosPorFecha(DateTime fecha)
    {
        return FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosPorFecha(fecha);
    }

    List<Pronostico_tiempo> IServicio.ListarPronosticosAnioActual()
    {
        return FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosAnioActual();
    }

    #endregion
}