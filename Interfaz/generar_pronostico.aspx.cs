using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class generar_pronostico : System.Web.UI.Page
{
    ServicioClient service = new ServicioClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        txtInterno.ReadOnly = true;
        txtInterno.Visible = false;

        if (!IsPostBack)
        {
            cargar_ciudades();
        }
    }

    protected void btnAgregarPronoHora_Click(object sender, EventArgs e)
    {
        //agregar a grilla
        //agregar a session

        try
        {
            Pronostico_hora ph = new Pronostico_hora()
            {
                Hora = Convert.ToInt32(txtpsHora.Text.Trim()),
                Temp_max = Convert.ToInt32(txtpsMax.Text.Trim()),
                Temp_min = Convert.ToInt32(txtpsMin.Text.Trim()),
                Prob_lluvias = Convert.ToInt32(txtpsLluvias.Text.Trim()),
                Prob_tormenta = Convert.ToInt32(txtpsTormentas.Text.Trim()),
                V_viento = Convert.ToInt32(txtpsTormentas.Text.Trim()),
                Tipo_cielo = ddlCielo.SelectedValue
            };


            var pronosticosGrilla = (List<Pronostico_hora>)ViewState["PronosticosGrilla"];
            if (pronosticosGrilla == null)
            {
                pronosticosGrilla = new List<Pronostico_hora>();
            }

            pronosticosGrilla.Add(ph);
            ViewState["PronosticosGrilla"] = pronosticosGrilla;
            this.gvPronosticosHora.DataSource = pronosticosGrilla;
            this.gvPronosticosHora.DataBind();

        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        try
        {
            var pronosticosGrilla = (List<Pronostico_hora>)this.gvPronosticosHora.DataSource;
            var codigo_ciudad = ddlCiudades.SelectedValue;

            Ciudad ciudad = new ServicioClient().BuscarCiudadActiva(codigo_ciudad, (Usuario)Session["Usuario"]);
            Usuario usuario = (Usuario)Session["Usuario"];

            Pronostico_tiempo pt = new Pronostico_tiempo()
            {
                Interno = 1,
                Fecha = Convert.ToDateTime(txtFecha.Text),
                Ciudad = ciudad,
                Usuario = usuario,
                LIST_pronosticos_hora = pronosticosGrilla.ToArray()
            };


            service.CrearPronosticoTiempo(pt, (Usuario)Session["Usuario"]);

        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    private void cargar_ciudades()
    {
        Ciudad[] ciudades = service.ListarCiudades((Usuario)Session["Usuario"]);
        this.ddlCiudades.DataSource = ciudades;
        //this.
        this.ddlCiudades.DataBind();
    }
}