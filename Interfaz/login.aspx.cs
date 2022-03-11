using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            var usuario = Session["Usuario"] != null ? (Usuario)Session["Usuario"] : null;
            Usuario user = new ServicioClient().LoginUsuario(txtUser.Text, txtPass.Text, usuario);

            //Usuario user = new Usuario
            //{
            //    Username = "Carlos29",
            //    Password = "129carl**"
            //};

            Session["Usuario"] = user;

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