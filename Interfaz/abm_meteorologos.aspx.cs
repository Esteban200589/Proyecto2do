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

        Usuario user = (Usuario)Session["Usuario"];

        if (user is Meteorologo)
        {
            titulo.InnerText = "Cambiar Contraseña";

            Meteorologo usuario = new ServicioClient().TraerMeteorologo(user.Username, null);
            Session["Usuario_Encontrado"] = usuario;

            txtUsername.Text = user.Username;
            txtUsername.Enabled = false;
            txtUsername.Visible = false;
            lblUser.Visible = false;

            //txtPassword.Text = user.Password;
            
            txtNombre.Text = usuario.Nombre;
            txtNombre.Enabled = false;
            txtNombre.Visible = false;
            lblNom.Visible = false;

            txtTelefono.Text = usuario.Telefono;
            txtTelefono.Enabled = false;
            txtTelefono.Visible = false;
            lblTel.Visible = false;

            txtCorreo.Text = usuario.Correo;
            txtCorreo.Enabled = false;
            txtCorreo.Visible = false;
            lblCorreo.Visible = false;

            btnBuscar.Enabled = false;
            btnGuardar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificar.Enabled = true;
            btnLimpiar.Enabled = false;
        }

        if (user is Empleado)
        {
            txtPassword.Enabled = false;
            txtPassword.Visible = false;
            lblPass.Visible = false;
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtUsername.Text != "")
            {
                Meteorologo usuario = new ServicioClient().TraerMeteorologo(txtUsername.Text, (Usuario)base.Session["Usuario"]);

                if (usuario == null)
                {
                    Empleado usuario_emp = new ServicioClient().TraerEmpleado(txtUsername.Text, (Usuario)base.Session["Usuario"]);

                    if (usuario_emp != null)
                    {
                        throw new Exception("El usuario es un Empleado");
                    }
                }

                txtUsername.ReadOnly = true;

                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    txtPassword.Enabled = true;
                    txtPassword.Visible = true;
                    lblPass.Visible = true;

                    lblMsj.Text = "No se encontró el Usuario, puede Crearlo";
                    lblMsj.ForeColor = Color.DarkOrange;
                }

                else
                {
                    lblMsj.Text = "Usuario encontrado";
                    lblMsj.ForeColor = Color.Green;

                    txtUsername.Text = usuario.Username;

                    txtNombre.Text = usuario.Nombre;
                    txtTelefono.Text = usuario.Telefono;
                    txtCorreo.Text = usuario.Correo;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    Session["Usuario_Encontrado"] = usuario;
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
            Meteorologo usuario = (Meteorologo)Session["Usuario_Encontrado"];

            if (usuario != null)
            {
                if ((Usuario)Session["Usuario"] is Meteorologo)
                {
                    string pass = txtPassword.Text.Trim();
                    usuario.Password = pass;

                    new ServicioClient().ModificarUsuario(usuario, null);

                    txtPassword.Text = "";
                    lblMsj.Text = "Contraseña Modificada";

                    Usuario u = (Usuario)base.Session["Usuario"];
                    if (usuario.Username.ToLower() == u.Username.ToLower())
                    {
                        System.Threading.Thread.Sleep(2000);
                        Response.Redirect("~/login.aspx");
                    }
                }
                else
                {
                    usuario.Username = txtUsername.Text.Trim();
                    usuario.Password = usuario.Password;
                    usuario.Nombre = txtNombre.Text.Trim();
                    usuario.Telefono = txtTelefono.Text.Trim();
                    usuario.Correo = txtCorreo.Text.Trim();

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtNombre.Text = "";
                    txtTelefono.Text = "";
                    txtCorreo.Text = "";

                    txtUsername.ReadOnly = false;

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    new ServicioClient().ModificarUsuario(usuario, (Usuario)Session["Usuario"]);

                    lblMsj.Text = "Usuario Modificado";
                }

                lblMsj.ForeColor = Color.Green;
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
            if (txtNombre.Text == "")
                throw new Exception("Por favor, Ingrese la Contraseña");
            if (txtTelefono.Text == "")
                throw new Exception("Ingrese el Telefono");
            if (txtNombre.Text == "")
                throw new Exception("Por favor, Ingrese el Nombre");
            if (txtCorreo.Text == "")
                throw new Exception("Ingrese el Correo");

            Meteorologo usuario = new Meteorologo()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim()
            };

            new ServicioClient().CrearUsuario(usuario, (Usuario)base.Session["Usuario"]);

            lblMsj.Text = "Usuario guardado con exito!";
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
            Meteorologo usuario = (Meteorologo)Session["Usuario_Encontrado"];

            if (usuario != null)
            { 
                new ServicioClient().EliminarUsuario(usuario, (Usuario)Session["Usuario"]);

                lblMsj.Text = "Usuario Eliminado";
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
                lblMsj.Text = "Debe buscar un Usuario primero";
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

    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {

    }
}