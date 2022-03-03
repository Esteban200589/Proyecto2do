using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;

public partial class _default : System.Web.UI.Page
{
    static DateTime fecha = DateTime.Now;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            cargar_Pronosticos(fecha); 
    }

    protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
    {
        fecha = DateTime.Now;
        Response.Redirect("default.aspx");
    }

    protected void cargar_Pronosticos(DateTime fecha)
    {
        if (calendario.SelectedDate.ToString("yyyyMMdd") == "00010101")
            calendario.SelectedDate = fecha;
        else
            fecha = calendario.SelectedDate;

        try
        {
            List<Pronostico_tiempo> list = FabricaLogica.GetLogicaPronosticosTiempo().ListarPronosticosPorFecha(fecha).ToList();
            Session["Pronosticos_" + fecha] = list;
            //this.Response.Write(Session["Pronosticos_" + fecha]);
            gvPronosticos.DataSource = Session["Pronosticos_"+fecha];
            gvPronosticos.DataBind();
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }

    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        fecha = calendario.SelectedDate;
        cargar_Pronosticos(fecha);
    }
}