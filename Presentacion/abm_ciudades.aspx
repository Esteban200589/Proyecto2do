<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abm_ciudades.aspx.cs" Inherits="Presentacion.abm_ciudades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <body>
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-3"></div>
                    <!-- right column -->
                    <div class="col-md-6">
                        <!-- general form elements disabled -->
                        <div class="card card-warning">
                            <div class="card-header" style="background-color: #757578; color: #ffffff;">
                                <h3 class="card-title">AM NOTICIAS</h3>
                            </div>

                            <!-- /.card-header -->
                            <div role="form" id="frm">
                                <div class="card-body">

                                    <div class="row">
                                        <div class="col-sm-6">
                                    
                                        <div class="form-group">
                                            <label>CÓDIGO</label>
                                            <asp:TextBox  ID="txtCodigo" class="form-control" runat="server" Width="200px" ToolTip=" " ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label>NOMBRE</label>
                                            <asp:TextBox ID="txtNombre" class="form-control" runat="server" Width="200px" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>PAIS</label>
                                                <asp:TextBox ID="txtPais" class="form-control" runat="server" Width="200px" ToolTip=" " ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            
                                        </div>
                                    </div>

                                </div>

                                <div class="card-footer"> 
                                        
                                    <div class="row">
                                        <div class="col-sm-12" style="text-align:center;">
                                            <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" Width="90px"/>                       
                                            <asp:Button ID="btnModificar" class="btn btn-secondary" runat="server" Text="Modificar" Width="90px"/>                       
                                            <asp:Button ID="btnGuardar" class="btn btn-secondary" runat="server" Text="Guardar" Width="90px" />                        
                                            <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="90px"/>  
                                        </div>
                                    </div>
                                        
                                    <div class="row">
                                        <div class="col-12" style="text-align:center;">
                                            <label class="col-form-label" for="exampleFormControlInput1">&nbsp;</label>
                                            <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-12" style="text-align:center;">
                                            <a href="index.aspx">Volver</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </body>
    </html>
    <style>
        label{
            font-weight:bold;
        }
    </style>
    <script>
        //$("#ContentPlaceHolder1_ddlPeriodistas").append($("<option>ninguno</option>").val(0).html("Ninguno"));
        //$("#ContentPlaceHolder1_ddlPeriodistas option[value='0']").attr("selected", true);
        //$("#ContentPlaceHolder1_btnAgregar").click(function () {
        //    if ($("#ContentPlaceHolder1_ddlPeriodistas") == 0) {
        //        $("#ContentPlaceHolder1_lblMsj").text("Seleccione un Periodista");
        //    }
        //});
    </script>
</asp:Content>
