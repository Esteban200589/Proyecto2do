using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class main : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

        try
        {
            if (Session["Usuario"] == null)
                Response.Redirect("login.aspx");
            else
            {
                Usuario user = (Usuario)Session["Usuario"];

                if (user is Empleado)
                {
                    this.menuNav1.InnerHtml = "<ul class='navbar-nav ms-6'>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='index.aspx'>Inicio</a></li>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='abm_ciudades.aspx'>Ciudades</a></li>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='abm_empleados.aspx'>Empleados</a></li>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='abm_meteorologos.aspx'>Meteorologos</a></li>";
                    this.menuNav1.InnerHtml += "</ul>";

                    lblTipoUser.Text = "Empleado";
                }
                else {
                    this.menuNav1.InnerHtml = "<ul class='navbar-nav ms-6'>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='index.aspx'>Inicio</a></li>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='generar_pronostico.aspx'>Generar Pronosticos</a></li>";
                    this.menuNav1.InnerHtml += "<li class='nav-item'><a class='nav-link' href='listado_pronosticos.aspx'>Listar Pronosticos</a></li>";
                    this.menuNav1.InnerHtml += "</ul>";

                    lblTipoUser.Text = "Meteorologo";
                }
                
                lblUsername.Text = user.Username;
                lblUsername.ForeColor = Color.Green;
                lblTipoUser.ForeColor = Color.Green;
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }


    protected void logout_Click(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
        Response.Redirect("default.aspx");
    }
}