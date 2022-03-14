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

        //static InterfazPersistenciaPronosticosHora FabricaHora = FabricaPersistencia.getPersistenciaPronosticosHora();
        static InterfazPersistenciaPronosticosTiempo FabricaTiempo = FabricaPersistencia.getPersistenciaPronosticosTiempo();

        public void CrearPronosticoTiempo(Pronostico_tiempo pt, Usuario user_log)
        {
            FabricaTiempo.CrearPronosticoTiempo(pt, user_log);
        }

        public List<Pronostico_tiempo> ListarPronosticosPorFecha(DateTime fecha, Usuario user_log)
        {
            return FabricaTiempo.ListarPronosticosFecha(fecha, user_log);
        }

        public List<Pronostico_tiempo> ListarPronosticosAnioActual(Usuario user_log)
        {
            return FabricaTiempo.ListarPronosticosAnioActual(user_log);
        }

        public string PronosticosXML(DateTime fecha, Usuario user_log)
        {
            List<Pronostico_tiempo> lista = FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosPorFecha(fecha, user_log);

            XmlDocument documento = new XmlDocument();
            documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
            //XmlNode root = documento.DocumentElement;

            foreach (Pronostico_tiempo pt in lista)
            {
                XmlNode nodo = documento.CreateNode(XmlNodeType.Element, "Pronostico_Tiempo", "");
                //XmlElement nodo = documento.CreateElement("Pronostico_Tiempo");

                XmlElement interno = documento.CreateElement("Interno");
                interno.InnerText = pt.Interno.ToString();
                nodo.AppendChild(interno);

                XmlElement pais = documento.CreateElement("Pais");
                pais.InnerText = pt.Ciudad.Pais.ToString();
                nodo.AppendChild(pais);

                XmlElement ciudad = documento.CreateElement("Ciudad");
                ciudad.InnerText = pt.Ciudad.Nombre_ciudad.ToString();
                nodo.AppendChild(ciudad);

                //XmlElement prono_hora = documento.CreateElement("Pronosticos_hora");            
                //nodo.AppendChild(prono_hora);

                int cnt = 0;   
                foreach (Pronostico_hora ph in pt.LIST_pronosticos_hora)
                {
                    XmlElement nodo_ph = documento.CreateElement("Pronostico_hora");
                    //XmlAttribute attr = documento.CreateAttribute("Interno");
                    //nodo_ph.SetAttribute("ID", cnt.ToString());

                    XmlElement id = documento.CreateElement("ID");
                    id.InnerText = pt.Interno.ToString();
                    nodo_ph.AppendChild(id);

                    XmlElement hora = documento.CreateElement("Hora");

                    string str_hora = ph.Hora.ToString();
                    string str_pad_hora = str_hora.PadLeft(4, '0');
                    str_hora = str_pad_hora.Substring(0, 2) + ":" + str_pad_hora.Substring(2, 2);
                    hora.InnerText = str_hora + " hrs";

                    // hora.InnerText = ph.Hora.ToString();
                    nodo_ph.AppendChild(hora);

                    XmlElement max = documento.CreateElement("Temp_Max");
                    max.InnerText = ph.Temp_max.ToString() + " °C";
                    nodo_ph.AppendChild(max);

                    XmlElement min = documento.CreateElement("Temp_Min");
                    min.InnerText = ph.Temp_min.ToString() + " °C";
                    nodo_ph.AppendChild(min);

                    XmlElement lluvia = documento.CreateElement("Prob_Lluvias");
                    lluvia.InnerText = ph.Prob_lluvias.ToString() + " %";
                    nodo_ph.AppendChild(lluvia);

                    XmlElement tormenta = documento.CreateElement("Prob_Tormenta");
                    tormenta.InnerText = ph.Prob_tormenta.ToString() + " %";
                    nodo_ph.AppendChild(tormenta);

                    XmlElement viento = documento.CreateElement("Velo_Viento");
                    viento.InnerText = ph.V_viento.ToString() + " m/s²";
                    nodo_ph.AppendChild(viento);

                    XmlElement cielo = documento.CreateElement("Tipo_Cielo");

                    string html_tipo = "";
                    string html_color = "";
                    string tipo = ph.Tipo_cielo.ToString();

                    switch (tipo)
                    {
                        case "nuboso":
                            html_tipo = "Nuboso";
                            html_color = "background-color:#f3aa56;";
                            break;
                        case "parcialmente_nuboso":
                            html_tipo = "Parcialmente Nuboso";
                            html_color = "background-color:#abf356;";
                            break;
                        case "despejado":
                            html_tipo = "Despejado";
                            html_color = "background-color:#56aaf3;";
                            break;
                    }
                    cielo.InnerText = html_tipo;
                    nodo_ph.AppendChild(cielo);

                    XmlElement color = documento.CreateElement("Color");
                    color.InnerText = html_color.ToString();
                    nodo_ph.AppendChild(color);

                    nodo.AppendChild(nodo_ph);
                    cnt++;
                }
                //nodo.AppendChild(prono_hora);

                documento.DocumentElement.AppendChild(nodo);
            }
            return documento.OuterXml;
        }
    }
}
