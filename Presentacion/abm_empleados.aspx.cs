using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;
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
        try
        {
            if (txtUsername.Text != "")
            {
                Empleado usuario = (Empleado)FabricaLogica.GetLogicaUsuarios().BuscarUsuario(txtUsername.Text);
             
                txtUsername.ReadOnly = true;

                if (usuario == null)
                {
                    btnGuardar.Enabled = true;
                    btnEliminar.Enabled = false;
                    btnModificar.Enabled = false;

                    txtPassword.ReadOnly = false;

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
                    string horas = usuario.Carga_horaria.ToString();
                    txtHoras.Text = horas;
                    //horas = horas.Substring(0, 2) + ":" + horas.Substring(2, 2);
                    //txtHoras.Text = horas.PadLeft(4,'0');

                    btnGuardar.Enabled = false;
                    btnEliminar.Enabled = true;
                    btnModificar.Enabled = true;

                    Session["Usuario"] = usuario;
                }
            }
            else
            {
                lblMsj.Text = "Debe ingresar el Username";
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
            Empleado usuario = (Empleado)Session["Usuario"];

            if (usuario != null)
            {
                usuario.Username = txtUsername.Text.Trim();
                usuario.Password = txtPassword.Text.Trim();
                usuario.Nombre = txtNombre.Text.Trim();
                usuario.Carga_horaria = Convert.ToInt32(txtHoras.Text);

                FabricaLogica.GetLogicaUsuarios().ModificarUsuario(usuario);

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
            string horas = txtHoras.Text;

            Empleado usuario = new Empleado(Convert.ToInt32(horas.Replace(":", "")), 
                txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtNombre.Text.Trim());
           
            FabricaLogica.GetLogicaUsuarios().CrearUsuario(usuario);

            lblMsj.Text = "Ciudad guardada con exito!";
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
            Empleado usuario = null;

            if (Session["Ciudad"] != null)
            {
                usuario = (Empleado)Session["Usuario"];
                FabricaLogica.GetLogicaUsuarios().EliminarUsuario(usuario);

                lblMsj.Text = "Ciudad Eliminada";
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
        txtHoras.Text = "";
        Session["Ciudad"] = null;
        lblMsj.Text = "";

        btnGuardar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
    }
}