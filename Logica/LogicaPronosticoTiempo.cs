using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Persistencia;
using System.Xml;

namespace Logica
{
    internal class LogicaPronosticoTiempo : InterfazLogicaPronosticosTiempo
    {

        private static LogicaPronosticoTiempo instancia = null;
        private LogicaPronosticoTiempo() { }
        public static LogicaPronosticoTiempo GetInstanciaPronosticoTiempo()
        {
            if (instancia == null)
                instancia = new LogicaPronosticoTiempo();

            return instancia;
        }

        static InterfazPersistenciaPronosticosHora FabricaHora = FabricaPersistencia.getPersistenciaPronosticosHora();
        static InterfazPersistenciaPronosticosTiempo FabricaTiempo = FabricaPersistencia.getPersistenciaPronosticosTiempo();

        public void CrearPronosticoTiempo(Pronostico_tiempo pt)
        {
            FabricaTiempo.CrearPronosticoTiempo(pt);
        }

        public List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha)
        {
            return FabricaTiempo.ListarPronosticosFecha(fecha);
        }

        public List<Pronostico_tiempo> ListarPronosticosAnioActual()
        {
            return FabricaTiempo.ListarPronosticosAnioActual();
        }


        public XmlDocument PronosticoTiempoXML(DateTime fecha)
        {
            //obtengo datos
            List<Pronostico_tiempo> listado_pt = FabricaTiempo.ListarPronosticosFecha(fecha);

            //convierto a xml
            XmlDocument documento = new XmlDocument();
            documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
            XmlNode root = documento.DocumentElement;

            //recorro la lista para crear los nodos
            foreach (Pronostico_tiempo pt in listado_pt)
            {
                XmlElement nodo = documento.CreateElement("PronosticoTiempo");

                XmlElement interno = documento.CreateElement("Interno");
                interno.InnerText = pt.Interno.ToString();
                nodo.AppendChild(interno);

                XmlElement fecha_ = documento.CreateElement("Fecha");
                fecha_.InnerText = pt.Fecha.ToString();
                nodo.AppendChild(fecha_);

                XmlElement ciudad = documento.CreateElement("Ciudad");
                ciudad.InnerText = pt.Ciudad.ToString();
                nodo.AppendChild(ciudad);

                XmlElement usuario = documento.CreateElement("Usuario");
                usuario.InnerText = pt.Usuario.ToString();
                nodo.AppendChild(usuario);

                XmlElement ptcos_hora = documento.CreateElement("PtcosHora");
                ptcos_hora.InnerText = pt.LIST_pronosticos_hora.ToString();
                nodo.AppendChild(ptcos_hora);

                root.AppendChild(nodo);

            }

            return documento;
        }


        //public XmlDocument PronosticoHoraXML(int interno)
        //{
        //    //obtengo datos
        //    List<Pronostico_hora> listado_ph = FabricaHora.ListarPronosticosHora(interno);

        //    //convierto a xml
        //    XmlDocument documento = new XmlDocument();
        //    documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
        //    XmlNode root = documento.DocumentElement;

        //    //recorro la lista para crear los nodos
        //    foreach (Pronostico_hora ph in listado_ph)
        //    {
        //        XmlElement nodo = documento.CreateElement("PronosticoHora");

        //        XmlElement hora = documento.CreateElement("Hora");
        //        hora.InnerText = ph.Hora.ToString();
        //        nodo.AppendChild(hora);

        //        XmlElement temp_max = documento.CreateElement("Maxima");
        //        temp_max.InnerText = ph.Temp_max.ToString();
        //        nodo.AppendChild(temp_max);

        //        XmlElement temp_min = documento.CreateElement("Minima");
        //        temp_min.InnerText = ph.Temp_min.ToString("yyyy");
        //        nodo.AppendChild(temp_min);

        //        XmlElement viento = documento.CreateElement("Viento");
        //        viento.InnerText = ph.V_viento.ToString();
        //        nodo.AppendChild(viento);

        //        XmlElement lluvias = documento.CreateElement("Lluvias");
        //        lluvias.InnerText = ph.Prob_lluvias.ToString();
        //        nodo.AppendChild(lluvias);

        //        XmlElement tormenta = documento.CreateElement("Tormenta");
        //        tormenta.InnerText = ph.Prob_tormenta.ToString();
        //        nodo.AppendChild(tormenta);

        //        XmlElement cielo = documento.CreateElement("Cielo");
        //        cielo.InnerText = ph.Tipo_cielo.ToString();
        //        nodo.AppendChild(cielo);

        //        root.AppendChild(nodo);

        //    }

        //    return documento;
        //}

    }
}
