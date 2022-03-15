using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class abm_empleados : System.Web.UI.Page
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
                Empleado usuario = new ServicioClient().TraerEmpleado(txtUsername.Text, (Usuario)base.Session["Usuario"]);

                if (usuario == null)
                {
                    Meteorologo usuario_met = new ServicioClient().TraerMeteorologo(txtUsername.Text, (Usuario)base.Session["Usuario"]);

                    if (usuario_met != null)
                    {
                        throw new Exception("El usuario es un Meteorologo");
                    }
                }

                

                txtUsername.ReadOnly = true;

                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

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
                    txtPassword.Text = usuario.Password;
                    //txtPassword.TextMode = TextBoxMode.Password;

                    Usuario log = (Usuario)base.Session["Usuario"];
                    if (usuario.Username.ToLower() != log.Username.ToLower())
                    {
                        txtPassword.Visible = false;
                        lblPass.Visible = false;
                    }
                    else
                    {
                        txtPassword.Visible = true;
                        lblPass.Visible = true;
                    }
                    //txtPassword.Attributes.CssStyle.Add("background-color", "black");

                    txtNombre.Text = usuario.Nombre;
                    txtHoras.Text = usuario.Carga_horaria.ToString();

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
            Empleado usuario = (Empleado)Session["Usuario_Encontrado"];

            if (usuario != null)
            {
                usuario.Username = txtUsername.Text.Trim();
                usuario.Password = txtPassword.Text.Trim();
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.Carga_horaria = Convert.ToInt32(txtHoras.Text);

                new ServicioClient().ModificarUsuario(usuario, (Usuario)base.Session["Usuario"]);

                lblMsj.Text = "Usuario Modificado";
                lblMsj.ForeColor = Color.Green;

                txtUsername.ReadOnly = false;

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtNombre.Text = "";
                txtHoras.Text = "";

                btnGuardar.Enabled = false;
                btnEliminar.Enabled = false;
                btnModificar.Enabled = false;

                Usuario u = (Usuario)base.Session["Usuario"];
                if (usuario.Username.ToLower() == u.Username.ToLower())
                {
                    System.Threading.Thread.Sleep(2000);
                    Response.Redirect("~/login.aspx");
                }
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
            if (txtHoras.Text == "")
                throw new Exception("Ingrese las horas");
            if (String.IsNullOrEmpty(txtPassword.Text))
                throw new Exception("Por favor, Ingrese la Contraseña");
            if (txtNombre.Text == "")
                throw new Exception("Por favor, Ingrese el Nombre");

            Empleado usuario = new Empleado()
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Carga_horaria = Convert.ToInt32(txtHoras.Text.Trim())
            };

            new ServicioClient().CrearUsuario(usuario, (Usuario)base.Session["Usuario"]);

            lblMsj.Text = "Usuario guardado con exito!";
            lblMsj.ForeColor = Color.Green;

            txtUsername.ReadOnly = false;

            txtUsername.Text = "";
            txtPassword.Text = "";
            txtNombre.Text = "";
            txtHoras.Text = "";

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
            Empleado usuario = (Empleado)Session["Usuario_Encontrado"];

            if (usuario != null)
            {
                new ServicioClient().EliminarUsuario(usuario, (Usuario)Session["Usuario"]);

                lblMsj.Text = "Usuario Eliminado";
                lblMsj.ForeColor = Color.Green;

                txtUsername.ReadOnly = false;

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtNombre.Text = "";
                txtHoras.Text = "";

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
        txtHoras.Text = "";

        Session["Ciudad"] = null;
        lblMsj.Text = "";

        btnGuardar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
    }
}