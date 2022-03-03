using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class abm_empleados : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //try
        //{
        //    if (txtCedula.Text != "")
        //    {
        //        periodistas periodista = new Servicio().buscar_periodista(txtCedula.Text);

        //        txtCedula.ReadOnly = true;

        //        if (periodista == null)
        //        {
        //            //txtCedula.Text = "";
        //            txtNombre.Text = "";
        //            txtEmail.Text = "";

        //            btnGuardar.Enabled = true;
        //            btnEliminar.Enabled = false;
        //            btnModificar.Enabled = false;

        //            lblMsj.Text = "No se encontró el periodista, puede Guardarlo";
        //            lblMsj.ForeColor = Color.DarkOrange;
        //        }

        //        else
        //        {
        //            lblMsj.Text = "Periodista encontrado";
        //            lblMsj.ForeColor = Color.Green;

        //            txtCedula.Text = periodista.cedula;
        //            txtNombre.Text = periodista.nombre;
        //            txtEmail.Text = periodista.email;

        //            btnGuardar.Enabled = false;
        //            btnEliminar.Enabled = true;
        //            btnModificar.Enabled = true;

        //            Session["Periodista"] = periodista;
        //        }
        //    }
        //    else
        //    {
        //        lblMsj.Text = "Debe ingresar una cedula";
        //        lblMsj.ForeColor = Color.DarkOrange;
        //    }

        //}

        //catch (System.Web.Services.Protocols.SoapException ex)
        //{
        //    lblMsj.Text = ex.Detail.InnerText;
        //    lblMsj.ForeColor = Color.Red;
        //}

        //catch (Exception ex)
        //{
        //    lblMsj.Text = ex.Message;
        //    lblMsj.ForeColor = Color.Red;
        //}
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {

    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {

    }
}