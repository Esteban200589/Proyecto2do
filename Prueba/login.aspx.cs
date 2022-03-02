using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Entidades;
using Logica;
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
            this.Response.Write(txtUser.Text);
            this.Response.Write(txtPass.Text);

            //Usuario user = FabricaLogica.GetLogicaUsuarios().LoginUsuario(txtUser.Text, txtPass.Text);
            Usuario user = new ServicioClient().LoginUsuario(txtUser.Text, txtPass.Text);

            if (user != null)
            {
                Session["Usuario"] = user;
                //Response.Redirect("~/index.aspx");
                this.Response.Write(user.Username);
                this.Response.Write(user.Tipo);
            }
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            txtPass.Text = "";
            txtUser.Text = "";
        }
    }
}