using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;

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
                    lblTipoUser.Text = "Empleado";
                else // is Meteorologo
                    lblTipoUser.Text = "Meteorologo";

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