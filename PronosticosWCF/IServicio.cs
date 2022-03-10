using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using System.Xml;
using Entidades;
using Logica;

namespace PronosticosWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        #region ciudades

        [OperationContract]
        void CrearCiudad(Ciudad c, Usuario user_log);

        [OperationContract]
        void ModificarCiudad(Ciudad c, Usuario user_log);

        [OperationContract]
        void EliminarCiudad(Ciudad c, Usuario user_log);

        [OperationContract]
        Ciudad BuscarCiudadActiva(string codigo, Usuario user_log);

        [OperationContract]
        List<Ciudad> ListarCiudades();

        [OperationContract]
        List<Ciudad> ListarCiudadesSinPronosticos();

        #endregion

        #region usuarios

        [OperationContract]
        void CrearUsuario(Usuario u);

        [OperationContract]
        void ModificarUsuario(Usuario u);

        [OperationContract]
        void EliminarUsuario(Usuario u);

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

        [OperationContract]
        string PronosticosXML(DateTime fecha);
        #endregion
    }
}
