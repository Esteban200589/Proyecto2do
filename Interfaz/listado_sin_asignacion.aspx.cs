using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class listado_sin_asignacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnListarCiudades_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsj.Text = "";

            int anio;
            if (txtAnio.Text == string.Empty)
                anio = 0;
            else
                anio = Convert.ToInt32(txtAnio.Text);

            Session["Ciudades"] = new ServicioClient().ListarCiudadesSinPronosticos((Usuario)Session["Usuario"], anio);
            gvCiudades.DataSource = Session["Ciudades"];
            gvCiudades.DataBind();

            grillaCiudades.Attributes.CssStyle.Add("display", "block");
            grillaMeteorolos.Attributes.CssStyle.Add("display", "none");

        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
        }
    }

    protected void btnListarMeteorologos_Click(object sender, EventArgs e)
    {
        try
        {
            lblMsj.Text = "";

            int anio;
            if (txtAnio.Text == string.Empty)
                anio = 0;
            else
                anio = Convert.ToInt32(txtAnio.Text);

            Session["Meteorologos"] = new ServicioClient().ListarMeteorologosSinPronosticos((Usuario)Session["Usuario"], anio);
            gvMeteorologos.DataSource = Session["Meteorologos"];
            gvMeteorologos.DataBind();

            grillaCiudades.Attributes.CssStyle.Add("display", "none");
            grillaMeteorolos.Attributes.CssStyle.Add("display", "block");
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
        }
    }

    protected void txtLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            gvCiudades.DataSource = null;
            gvCiudades.DataBind();
            gvMeteorologos.DataSource = null;
            gvMeteorologos.DataBind();

            txtAnio.Text = "";
            lblMsj.Text = "";

            grillaCiudades.Attributes.CssStyle.Add("display", "none");
            grillaMeteorolos.Attributes.CssStyle.Add("display", "none");
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
        }
    }
}