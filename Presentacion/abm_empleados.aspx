<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abm_empleados.aspx.cs" Inherits="Presentacion.abm_empleados" %>
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
                                            <asp:TextBox  ID="txtCodigo" class="form-control" runat="server" Width="200px" ToolTip="Introduzca el código de la noticia" ></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-sm-6">
                                        <div class="form-group">
                                            <label>FECHA</label>
                                            <asp:TextBox ID="txtfecha" class="form-control" runat="server" Width="200px" TextMode="Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>TITULO</label>
                                                <asp:TextBox ID="txtTitulo" class="form-control" runat="server" Width="200px" ToolTip="Introduzca el titulo de la noticia" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>SECCIÓN</label><br />
                                                <asp:DropDownList ID="ddlSecciones" class="btn btn-default" runat="server" Width="200px" style="text-align:left;"> </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>USUARIO</label>
                                                <asp:TextBox ID="txtUsuario" class="form-control" runat="server" Width="200px" style="text-align:left;" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>IMPORTANCIA</label><br />
                                                <asp:DropDownList ID="ddlImportancia" class="btn btn-default" runat="server" Width="120px">
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                    <asp:ListItem Value="5">5</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <div class="form-group">
                                                <label>CUERPO</label>
                                                <asp:TextBox ID="txtCuerpo" class="form-control" runat="server" Width="350px" Height="140px" TextMode="MultiLine" 
                                                    ToolTip="Introduzca el cuerpo de la noticia"/>
                                            </div>
                                        </div>
                                        <div class="col-sm-6">
                                            <label>PERIODISTAS</label>
                                            <div class="form-group">
                                                <div class="col-12">
                                                    <asp:DropDownList ID="ddlPeriodistas" class="btn btn-default" runat="server" Width="250px" style="text-align:left;"> 
                                                        <asp:ListItem Value="ninguno" Selected="True"> </asp:ListItem>
                                                    </asp:DropDownList>&nbsp;
                                                    <asp:Button ID="btnAgregar" class="btn btn-secondary" runat="server" Text="+" Width="30px" Height="30px"/>&nbsp;
                                                    <asp:Button ID="btnQuitar" class="btn btn-secondary" runat="server" Text="-" Width="30px" Height="30px"/>
                                                </div>
                                                <asp:ListBox ID="lbPeriodistasNoticia" class="form-control" runat="server"  Width="350px"> </asp:ListBox>
                                            </div>
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
