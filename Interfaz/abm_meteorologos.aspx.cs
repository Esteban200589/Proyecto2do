using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class abm_meteorologos : System.Web.UI.Page
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
            if (txtUsername.Text != "")
            {
                Meteorologo usuario = (Meteorologo)new ServicioClient().BuscarUsuario(txtUsername.Text, (Usuario)base.Session["Usuario"]);

                txtUsername.ReadOnly = true;

                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    lblMsj.Text = "No se encontró el Usuario, puede Crearlo";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                else
                {
                    lblMsj.Text = "Usuario encontrado";
                    lblMsj.ForeColor = Color.Green;

                    txtUsername.Text = usuario.Username;
                    txtPassword.Text = usuario.Password;
                    txtPassword.TextMode = TextBoxMode.Password;
                    txtNombre.Text = usuario.Nombre;
                    txtTelefono.Text = usuario.Telefono;
                    txtCorreo.Text = usuario.Correo;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    Session["Usuario"] = usuario;
                }
            }
            else
            {
                lblMsj.Text = "Debe ingresar un código";
                lblMsj.ForeColor = Color.DarkOrange;
            }

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
            Meteorologo usuario = (Meteorologo)Session["Usuario"];

            if (usuario != null)
            {
                usuario.Username = txtUsername.Text.Trim();
                usuario.Password = txtPassword.Text.Trim();
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.Telefono = txtTelefono.Text.Trim();
                usuario.Correo = txtCorreo.Text.Trim();

                new ServicioClient().ModificarUsuario(usuario, (Usuario)Session["Usuario"]);

                lblMsj.Text = "Usuario Modificado";
                lblMsj.ForeColor = Color.Green;

                txtUsername.ReadOnly = false;

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";

                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;
            }
            else
            {
                lblMsj.Text = "No hay Usuario que modificar, busque uno";
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
            Meteorologo usuario = new Meteorologo()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            new ServicioClient().CrearUsuario(usuario, (Usuario)base.Session["Usuario"]);

            lblMsj.Text = "Ciudad guardada con exito!";
            lblMsj.ForeColor = Color.Green;

            txtUsername.ReadOnly = false;

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";

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
            Meteorologo usuario = null;

            if (Session["Ciudad"] != null)
            {
                usuario = (Meteorologo)Session["Usuario"];
                new ServicioClient().EliminarUsuario(usuario, (Usuario)Session["Usuario"]);

                lblMsj.Text = "Ciudad Eliminada";
                lblMsj.ForeColor = Color.Green;

                txtUsername.ReadOnly = false;

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";

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
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtUsername.ReadOnly = false;

        txtUsername.Text = "";
        txtPassword.Text = "";
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtCorreo.Text = "";

        Session["Ciudad"] = null;
        lblMsj.Text = "";

        btnGuardar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
    }
}