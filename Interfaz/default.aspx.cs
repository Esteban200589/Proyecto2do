using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            cargar_Pronosticos();
    }

    protected void btnLimpiarfiltros_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    protected void cargar_Pronosticos()
    {
        try
        {
            Session["Pronosticos"] = new ServicioClient().ListarPronosticosAnioActual().ToList();
            //this.Response.Write(Session["Pronosticos"]);
            gvPronosticos.DataSource = Session["Pronosticos"];
            gvPronosticos.DataBind();
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }

    }
}