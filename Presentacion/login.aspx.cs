﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                usuarios user = new Servicio().login(txtUser.Text, txtPass.Text);
                if (user != null)
                {
                    Session["Usuario"] = user;
                    Response.Redirect("~/index.aspx");
                }
            }
            catch (System.Web.Services.Protocols.SoapException ex)
            {
                lblMsj.Text = ex.Detail.InnerText;
                txtPass.Text = "";
                txtUser.Text = "";
            }
            catch (Exception ex)
            {
                lblMsj.Text = ex.Message;
                txtPass.Text = "";
                txtUser.Text = "";
            }
        }
    }
}