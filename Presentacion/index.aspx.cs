﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using Entidades;
using Logica;
public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Response.Write(Session["Usuario_Logueado"]);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}