using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class listado_pronosticos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                cargar_Ciudades();

                List<Pronostico_tiempo> lista = new ServicioClient().ListarPronosticosAnioActual((Usuario)Session["Usuario"]).ToList();
                Session["Pronosticos"] = lista;
                gvListadoPronosticos.DataSource = lista;
                gvListadoPronosticos.DataBind();

            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;

            }
        }
    }

    protected void btnFiltar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Pronostico_tiempo> source = (List<Pronostico_tiempo>)Session["Pronosticos"];
            List<Pronostico_tiempo> pronos = null;

            if (ddlCiudades.SelectedItem.Value != "AAAAAA")
            {
                pronos = (from p in source
                          where p.Ciudad.Codigo == ddlCiudades.SelectedValue.ToString()
                          select p).ToList<Pronostico_tiempo>();
            }
            else
            {
                pronos = (from p in source
                          select p).ToList<Pronostico_tiempo>();
            }




            gvListadoPronosticos.DataSource = pronos;
            gvListadoPronosticos.DataBind();

        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ddlCiudades.SelectedValue = "AAAAAA";
        //txtFecha.
        txtMeteorologo.Text = "";
    }

    public void cargar_Ciudades()
    {
        try
        {
            ddlCiudades.DataSource = (List<Ciudad>)Session["Ciudades"];
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

    protected void gvListadoPronosticos_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Pronostico_tiempo> lista = (List<Pronostico_tiempo>)Session["Pronosticos"];
        //List<Pronostico_hora> pronoHora = lista[gvpronos.SelectedIndex].Pronoxhora.ToList();

        //gvPronoxHora.DataSource = pronoHora;
        //gvPronoxHora.DataBind();
    }
}