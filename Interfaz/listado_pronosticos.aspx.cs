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
        List<Pronostico_tiempo> lista = (List<Pronostico_tiempo>)Session["Pronosticos"];

        try
        {
            string indice = gvListadoPronosticos.SelectedRow.Cells[0].Text;



            //< div id = "my-modal" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true">
            //    <div class="modal-dialog" role="document">
            //        <div class="modal-content"><div id = "p-modal" class="modal-body" style="float:center; padding:2%; font-size:large;"></div></div>
            //        <button style = "float: right" type="button" class="btn btn-default" data-dismiss="modal" id="btnModal";">Aceptar</button>
            //    </div>
            //</div>
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}