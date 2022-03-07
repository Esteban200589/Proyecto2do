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

            if (!IsPostBack)
            {
                //XmlDocument documento = new ServicioClient().PronosticosXML(fecha);
                //XElement elemento = XElement.Parse(documento.OuterXml);
                //Session["XML"] = elemento;
                //Xml_Pronosticos.DocumentContent = elemento.ToString();
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

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if ((calendario.SelectedDate.ToString("yyyyMMdd") == "00010101"))
                lblMsj.Text = "Debe seleccionar una fecha";
            else
            {
                fecha = calendario.SelectedDate;
                Xml_Pronosticos.DocumentContent = Session["XML"].ToString();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}