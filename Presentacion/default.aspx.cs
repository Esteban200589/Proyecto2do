using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using Entidades;
using Logica;
public partial class _default : System.Web.UI.Page
{
    static DateTime fecha = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                cargar_Pronosticos(fecha);
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.DarkOrange;
        }  
    }

    protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
    {
        fecha = DateTime.Now;
        Response.Redirect("default.aspx");
    }

    protected void cargar_Pronosticos(DateTime fecha)
    {
        try
        {
            //XmlDocument documento = FabricaLogica.GetLogicaPronosticosTiempo().PronosticosXML(fecha);
            //XElement elemento = XElement.Parse(documento.OuterXml);
            //Session["XML"] = elemento;
            //Xml_Pronosticos.DocumentContent = elemento.ToString();
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    public XmlDocument PronosticosXML(DateTime fecha)
    {
        List<Pronostico_tiempo> lista = FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosPorFecha(fecha);

        XmlDocument documento = new XmlDocument();
        documento.LoadXml("<?xml version='1.0' encoding='utf-8' ?> <Root> </Root>");
        XmlNode root = documento.DocumentElement;

        foreach (Pronostico_tiempo pt in lista)
        {
            XmlElement nodo = documento.CreateElement("Pronostico_Tiempo");

            //XmlElement interno = documento.CreateElement("Interno");
            //interno.InnerText = pt.Interno.ToString();
            //nodo.AppendChild(interno);

            nodo.SetAttribute("ID", pt.Interno.ToString());

            XmlElement pais = documento.CreateElement("Pais");
            pais.InnerText = pt.Ciudad.Pais.ToString();
            nodo.AppendChild(pais);

            XmlElement ciudad = documento.CreateElement("Ciudad");
            ciudad.InnerText = pt.Ciudad.Nombre_ciudad.ToString();
            nodo.AppendChild(ciudad);

            foreach (Pronostico_hora ph in pt.LIST_pronosticos_hora)
            {
                XmlElement nodo_ph = documento.CreateElement("Pronostico_hora");
                //XmlAttribute attr = documento.CreateAttribute("Interno");
                //nodo_ph.SetAttribute("_pt", pt.Interno.ToString());

                //XmlElement interno_ref = documento.CreateElement("Interno");
                //interno_ref.InnerText = pt.Interno.ToString();
                //nodo_ph.AppendChild(interno_ref);

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
                string tipo = ph.Tipo_cielo.ToString();

                switch (tipo)
                {
                    case "nublado":
                        html_tipo = "Nublado";
                        break;
                    case "parcialmente_nuboso":
                        html_tipo = "Parcialmente Nublado";
                        break;
                    case "despejado":
                        html_tipo = "Despejado";
                        break;
                }

                cielo.InnerText = html_tipo;
                nodo_ph.AppendChild(cielo);

                nodo.AppendChild(nodo_ph);
            }

            root.AppendChild(nodo);
        }
        return documento;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if ((calendario.SelectedDate.ToString("yyyyMMdd") == "00010101"))
                lblMsj.Text = "Debe seleccionar una fecha";
            else
            {
                fecha = calendario.SelectedDate;
                cargar_Pronosticos(fecha);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}