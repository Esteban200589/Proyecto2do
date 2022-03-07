using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;
public partial class abm_ciudades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Response.Write(sender);

        if (!IsPostBack)
        {
            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtCodigo.Text != "")
            {
                Ciudad ciudad = FabricaLogica.GetLogicaCiudades().BuscarCiudadActiva(txtCodigo.Text);

                txtCodigo.ReadOnly = true;

                if (ciudad == null)
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    lblMsj.Text = "No se encontró la ciudad, puede Crearla";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                else
                {
                    lblMsj.Text = "Ciudad encontrada";
                    lblMsj.ForeColor = Color.Green;

                    txtCodigo.Text = ciudad.Codigo;
                    txtNombre.Text = ciudad.Nombre_ciudad;
                    txtPais.Text = ciudad.Pais;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    Session["Ciudad"] = ciudad;
                }
            }
            else
            {
                lblMsj.Text = "Debe ingresar un código";
                lblMsj.ForeColor = Color.DarkOrange;
            }

        }

        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMsj.Text = ex.Detail.InnerText;
            lblMsj.ForeColor = Color.Red;
        }

        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = (Ciudad)Session["Ciudad"];

            if (ciudad != null)
            {
                ciudad.Nombre_ciudad = txtNombre.Text.Trim();
                ciudad.Pais = txtPais.Text.Trim();

                FabricaLogica.GetLogicaCiudades().ModificarCiudad(ciudad);

                lblMsj.Text = "Ciudad Modificada";
                lblMsj.ForeColor = Color.Green;

                txtCodigo.ReadOnly = false;

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPais.Text = "";

                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                lblMsj.Text = "No hay Ciudad que modificar, busque una";
                lblMsj.ForeColor = Color.DarkOrange;
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = new Ciudad(txtCodigo.Text.Trim(), 
                txtNombre.Text.Trim(), txtNombre.Text.Trim());

            FabricaLogica.GetLogicaCiudades().CrearCiudad(ciudad);

            lblMsj.Text = "Ciudad guardada con exito!";
            lblMsj.ForeColor = Color.Green;

            txtCodigo.ReadOnly = false;

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPais.Text = "";

            btnGuardar.Enabled = false;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad ciudad = null;

            if (Session["Ciudad"] != null)
            {
                ciudad = (Ciudad)Session["Ciudad"];
                FabricaLogica.GetLogicaCiudades().EliminarCiudad(ciudad);

                lblMsj.Text = "Ciudad Eliminada";
                lblMsj.ForeColor = Color.Green;

                txtCodigo.ReadOnly = false;

                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtPais.Text = "";

                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                lblMsj.Text = "Debe elegir una Ciudad";
                lblMsj.ForeColor = Color.DarkOrange;
                return;
            }
        }

        catch (System.Web.Services.Protocols.SoapException ex)
        {
            lblMsj.Text = ex.Detail.InnerText;
            lblMsj.ForeColor = Color.Red;
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtCodigo.ReadOnly = false;
        txtCodigo.Text = "";
        txtNombre.Text = "";
        txtPais.Text = "";
        Session["Ciudad"] = null;
        lblMsj.Text = "";

        btnGuardar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
    }
}