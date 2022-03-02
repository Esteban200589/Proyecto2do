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

                if (user.Tipo == "Empleado")
                {
                    menuNav1.Attributes.Add("style", "display:block;");
                    menuNav2.Attributes.Add("style", "display:none;");
                }

                if (user.Tipo == "Meteorologo")
                {
                    menuNav1.Attributes.Add("style", "display:none;");
                    menuNav2.Attributes.Add("style", "display:block;");
                }

                lblUsername.Text = user.Username;
                lblUsername.ForeColor = Color.Blue;
                lblTipoUser.Text = user.Tipo;
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