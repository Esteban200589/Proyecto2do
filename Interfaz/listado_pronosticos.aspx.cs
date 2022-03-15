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

                this.popup.Visible = false;
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

            DateTime fecha_date = new DateTime();
            string fecha_str = "";
            string meteorologo = "";

            if (txtFecha.Text != "")
            {
                fecha_date = Convert.ToDateTime(txtFecha.Text);
                fecha_str = fecha_date.ToString();
            }

            if (txtMeteorologo.Text != "")
            {
                meteorologo = txtMeteorologo.Text;
            }

            if (fecha_str == "1/1/0001 0:00:00")
                throw new Exception("Seleccione una fecha!");


            if (ddlCiudades.SelectedItem.Value != "AAAAAA" && meteorologo == "")
            {
                pronos = (from p in source
                            where p.Ciudad.Codigo == ddlCiudades.SelectedValue.ToString() 
                                && p.Fecha == fecha_date
                            select p).ToList<Pronostico_tiempo>();
            }
            else if (ddlCiudades.SelectedItem.Value != "AAAAAA" && meteorologo != "")
            {
                pronos = (from p in source
                          where p.Ciudad.Codigo == ddlCiudades.SelectedValue.ToString()
                              && p.Fecha == fecha_date
                              && p.Usuario.Username == meteorologo
                          select p).ToList<Pronostico_tiempo>();
            }
            else if (ddlCiudades.SelectedItem.Value == "AAAAAA" && meteorologo != "")
            {
                pronos = (from p in source
                          where p.Usuario.Username == meteorologo
                            && p.Fecha == fecha_date
                          select p).ToList<Pronostico_tiempo>();
            }
            else
            {
                if (fecha_str != "")
                {
                    pronos = (from p in source
                              where p.Fecha == fecha_date
                              select p).ToList<Pronostico_tiempo>();
                }
                else
                {
                    pronos = (from p in source
                              select p).ToList<Pronostico_tiempo>();
                }
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
        Response.Redirect("listado_pronosticos.aspx");
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
        List<Pronostico_tiempo> source = (List<Pronostico_tiempo>)Session["Pronosticos"];

        try
        {
            int indice = Convert.ToInt32(gvListadoPronosticos.SelectedRow.Cells[0].Text);

            foreach (var item in source)
            {
                if (item.Interno == indice)
                {
                    foreach (var ph in item.LIST_pronosticos_hora)
                    {
                        this.popup.InnerHtml = 
                            "<div class='row col-6'>" +
                                "<div id='my-modal' role='dialog' aria-hidden='true'>" +
                                    "<div id='my-modal' class='row col-12' role='dialog' aria-hidden='true'>" +
                                        "<div class='modal-dialog' role='document'>" +
                                            "<div class='modal-content'>" +
                                                "<div class='row col-6'><span>hora</span><input type='text' value='" + ph.Hora + "'></div>" +
                                                "<div class='row col-6'><span>max</span><input type='text' value='" + ph.Temp_max + "'></div>" +
                                                "<div class='row col-6'><span>min</span><input type='text' value='" + ph.Temp_min + "'></div>" +
                                                "<div class='row col-6'><span>lluvias</span><input type='text' value='" + ph.Prob_lluvias + "'></div>" +
                                                "<div class='row col-6'><span>tormenta</span><input type='text' value='" + ph.Prob_tormenta + "'></div>" +
                                                "<div class='row col-6'><span>viento</span><input type='text' value='" + ph.V_viento + "'></div>" +
                                                "<div class='row col-6'><span>cielo</span><input type='text' value='" + ph.Tipo_cielo + "'></div>" +
                                            "</div>" +
                                        "</div>" +
                                    "</div>" +
                                    "<a class='nav-link' style='z-index:10;' href='listado_pronosticos.aspx'>Volver</a>" +
                                "</div>" +
                            "</div>";

                        this.grilla.Visible = false;
                        this.popup.Visible = true;
                    }
                }
            }

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}