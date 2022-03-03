using System;
using System.Collections.Generic;
//using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Entidades;
using Logica;

[ServiceContract]
public interface IServicio
{
    #region ciudades

    [OperationContract]
    void CrearCiudad(Ciudad c);

    [OperationContract]
    void ModificarCiudad(Ciudad c);

    [OperationContract]
    void EliminarCiudad(Ciudad c);

    [OperationContract]
    Ciudad BuscarCiudadActiva(string codigo);

    [OperationContract]
    List<Ciudad> ListarCiudades();

    [OperationContract]
    List<Ciudad> ListarCiudadesSinPronosticos();

    #endregion

    #region usuarios

    [OperationContract]
    Usuario LoginUsuario(string username, string password);

    [OperationContract]
    Usuario BuscarUsuario(string username);

    #endregion

    #region pronosticos

    [OperationContract]
    void CrearPronosticoTiempo(Pronostico_tiempo pt);

    [OperationContract]
    List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha);

    [OperationContract]
    List<Pronostico_tiempo> ListarPronosticosAnioActual();

    #endregion
}
