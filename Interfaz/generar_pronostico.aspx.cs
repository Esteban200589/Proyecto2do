using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using ref_Servicio;

public partial class generar_pronostico : System.Web.UI.Page
{
    static int interno = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        txtInterno.ReadOnly = true;
        txtInterno.Visible = false;
    }

    protected void btnAgregarPronoHora_Click(object sender, EventArgs e)
    {
        //agregar a grilla
        //agregar a session

        try
        {
            //int pHora, int pMax, int pMin, int pVen, int pLluvia, int pTorm, string pCielo
            Pronostico_hora prono_hora = new Pronostico_hora();
            
            //lblMsj.Text = "Ciudad guardada con exito!";
            //lblMsj.ForeColor = Color.Green;



            //txtUsername.Text = "";
            //txtPassword.Text = "";
            //txtNombre.Text = "";
            //txtTelefono.Text = "";
            //txtCorreo.Text = "";

            //btnGuardar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }

    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        //recorrer lista de pronos horas de session

        try
        {
            //Pronostico_tiempo pronostico = new Pronostico_tiempo(Convert.ToInt32(txtInterno.Text), 
            //                                                     Convert.ToDateTime(txtFecha.Text),
            //                                                     ddlCiudades.SelectedItem, 
            //                                                     txtUsuario.Text.Trim(), 
            //                                                     gvPronosticosHora.DataSource);      
            //new ServicioClient().CrearUsuario(usuario);

            //lblMsj.Text = "Ciudad guardada con exito!";
            //lblMsj.ForeColor = Color.Green;

            

            //txtUsername.Text = "";
            //txtPassword.Text = "";
            //txtNombre.Text = "";
            //txtTelefono.Text = "";
            //txtCorreo.Text = "";

            //btnGuardar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblMsj.Text = ex.Message;
            lblMsj.ForeColor = Color.Red;
        }
    }
}