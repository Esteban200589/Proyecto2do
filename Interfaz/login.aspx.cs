using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ref_Servicio;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario user = new ServicioClient().LoginUsuario(txtUser.Text, txtPass.Text);
            if (user != null)
            {
                Session["Usuario"] = user;
                Response.Redirect("~/index.aspx");
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            txtPass.Text = "";
            txtUser.Text = "";
        }
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/default.aspx");
    }
}