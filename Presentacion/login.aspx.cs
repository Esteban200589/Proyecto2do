using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario_Logueado"] = null;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            //Usuario user = FabricaLogica.GetLogicaUsuarios().LoginUsuario(txtUser.Text, txtPass.Text);
            
            //if (user != null)
            //{
            //    Session["Usuario_Logueado"] = user;
            //    Response.Redirect("~/index.aspx");
            //}
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;

            txtPass.Text = "";
            txtUser.Text = "";
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}