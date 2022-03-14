using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.Xml.Linq;
using System.Drawing;
using ref_Servicio;

public partial class _default : System.Web.UI.Page
{
    static DateTime fecha = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            fecha = DateTime.Now;
            Session["Usuario"] = null;

            if (!IsPostBack)
            {
                cargar_Ciudades();
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

    protected void cargar_Pronosticos(DateTime fecha, string ciudad = "", int indice = 0)
    {
        try
        {
            string documento = new ServicioClient().PronosticosXML(fecha, (Usuario)Session["Usuario"]);
            XElement elemento = XElement.Parse(documento);
            Session["XML"] = elemento;

            if (ciudad != "")
            {
                var query = (from pronostico in elemento.Elements("Pronostico_Tiempo")
                             where pronostico.Element("Ciudad").Value == ciudad
                             select new
                             {
                                 Interno = pronostico.Element("Interno").Value,
                                 Pais = pronostico.Element("Pais").Value,
                                 Ciudad = pronostico.Element("Ciudad").Value

                             }).ToList();

                gvPronosticos.DataSource = query;
                gvPronosticos.DataBind();
            }
            else
            {
                var query = (from pronostico in elemento.Elements("Pronostico_Tiempo")
                             select new
                             {
                                 Interno = pronostico.Element("Interno").Value,
                                 Pais = pronostico.Element("Pais").Value,
                                 Ciudad = pronostico.Element("Ciudad").Value,

                             }).ToList();

                gvPronosticos.DataSource = query;
                gvPronosticos.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void cargar_Ciudades()
    {
        try
        {
            List<Ciudad> lista_ciudades = new ServicioClient().ListarCiudades((Usuario)Session["Usuario"]).ToList();
            Session["Ciudades"] = lista_ciudades;
            ddlCiudades.DataSource = lista_ciudades;
            ddlCiudades.DataTextField = "nombre_ciudad";
            ddlCiudades.DataValueField = "codigo";
            ddlCiudades.DataBind();
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
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

                if (ddlCiudades.SelectedItem.Value != "AAAAAA")
                    cargar_Pronosticos(fecha, ddlCiudades.SelectedItem.Text);
                else
                    cargar_Pronosticos(fecha);         
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }

    }



    protected void gvPronosticos_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string indice = gvPronosticos.SelectedRow.Cells[0].Text;

            XElement docu = (XElement)Session["XML"];

            var resultado = (from pt in docu.Elements("Pronostico_Tiempo")
                             where pt.Element("Interno").Value == indice
                             from ph in pt.Elements("Pronostico_hora")
                             select ph);

            string result = "<Raiz>";
            foreach (var nodo in resultado)
            {
                result += nodo.ToString();
            }
            result += "</Raiz>";

            Xml_Pronosticos.DocumentContent = result.ToString();
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }
}