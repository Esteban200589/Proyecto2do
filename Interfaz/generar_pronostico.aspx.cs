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
        if (!IsPostBack)
        {
            cargar_ciudades();
        }
    }

    protected void btnAgregarPronoHora_Click(object sender, EventArgs e)
    {
        try
        {
            int horas = Convert.ToInt32(txtpsHora.Text.Trim());
            int minutos = Convert.ToInt32(txtpsHora.Text.Trim());
           
            if ((horas < 0 || horas > 23))
                throw new Exception("Hora Incorrecta");   
            
            if (minutos < 0 || minutos > 59)
                throw new Exception("Minutos Incorrectos");

            string hora = txtpsHora.Text.Trim() + txtpsMin.Text.Trim(); 

            Pronostico_hora ph = new Pronostico_hora()
            {
                Hora = Convert.ToInt32(hora),
                Temp_max = Convert.ToInt32(txtpsTmax.Text.Trim()),
                Temp_min = Convert.ToInt32(txtpsTmin.Text.Trim()),
                Prob_lluvias = Convert.ToInt32(txtpsLluvias.Text.Trim()),
                Prob_tormenta = Convert.ToInt32(txtpsTormentas.Text.Trim()),
                V_viento = Convert.ToInt32(txtpsTormentas.Text.Trim()),
                Tipo_cielo = ddlCielo.SelectedValue
            };


            var pronosticosGrilla = (List<Pronostico_hora>)ViewState["PronosticosGrilla"];
            if (pronosticosGrilla == null)
                pronosticosGrilla = new List<Pronostico_hora>();

            int hora_value = Convert.ToInt32(hora);
            bool repetido = pronosticosGrilla.Where(p => p.Hora == hora_value).Any();
            if (repetido)
            {
                lblMsj.Text = "Ya existe un pronostico con la misma hora";
                return;
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
            var pronosticosGrilla = (List<Pronostico_hora>)ViewState["PronosticosGrilla"];
            var codigo_ciudad = ddlCiudades.SelectedValue;

            if(pronosticosGrilla == null)
                throw new Exception("No agregó ningun pronóstico por hora");
            if (codigo_ciudad == "AAAAAA")
                throw new Exception("Debe elegir una Ciudad");



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

            lblMsj.Text = "Se creo exitosamente el Pronostico de Tiempo";
            lblMsj.ForeColor = Color.Green;

        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    private void cargar_ciudades()
    {
        List<Ciudad> lista_ciudades = (List<Ciudad>)Session["Ciudades"];
        ddlCiudades.DataSource = lista_ciudades;
        ddlCiudades.DataTextField = "nombre_ciudad";
        ddlCiudades.DataValueField = "codigo";
        ddlCiudades.DataBind();
    }



    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }
}