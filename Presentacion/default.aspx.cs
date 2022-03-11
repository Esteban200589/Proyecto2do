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
            string documento = FabricaLogica.GetLogicaPronosticosTiempo().PronosticosXML(fecha, (Usuario)Session["Usuario"]);
            XElement elemento = XElement.Parse(documento);
            Session["XML"] = elemento;
            Xml_Pronosticos.DocumentContent = elemento.ToString();
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
                cargar_Pronosticos(fecha);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}