<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="abm_meteorologos.aspx.cs" Inherits="abm_meteorologos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <!-- Main content -->
    <section class="content">
        <div class="container-fluid">
            <div class="row">          
                <!-- general form elements disabled -->
                <div class="card card-warning" style="width:60%;margin:18%;margin-top:0px;background-color:aliceblue;">
                        
                    <div role="form" id="frm" >
                        <!-- /.card-header -->
                        <div class="card-header" style="text-align:center; background-color: #757578; color: #ffffff;">
                            <h3 class="card-title">METEOROLOGOS</h3>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-body">
                            <div class="row">
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6">
                                    <div class="form-group col-12">
                                        <label ID="lblUser" runat="server" >USUARIO</label>
                                        <asp:TextBox  ID="txtUsername" class="form-control" runat="server"  ToolTip=" " ></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group col-12">
                                        <label  ID="lblPass" runat="server" >CONTRASEÑA</label>
                                        <asp:TextBox  ID="txtPassword" class="form-control" runat="server"  ToolTip=" " OnTextChanged="txtPassword_TextChanged" ></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group col-12">
                                        <label ID="lblNom" runat="server" >NOMBRE COMPLETO</label>
                                        <asp:TextBox  ID="txtNombre" class="form-control" runat="server"  ToolTip=" " ></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6">
                                    <div class="form-group col-12">
                                        <label ID="lblTel" runat="server" >TELEFONO</label>
                                        <asp:TextBox  ID="txtTelefono" class="form-control" runat="server" Width="70%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group col-12">
                                        <label ID="lblCorreo" runat="server" >CORREO</label>
                                        <asp:TextBox  ID="txtCorreo" class="form-control" runat="server" Width="70%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group col-12">
                                        <label> </label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.card-footer -->
                        <div class="card-footer"> 
                                        
                            <div class="row">
                                <div class="col-sm-12" style="text-align:center;">
                                    <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" Width="90px" OnClick="btnBuscar_Click"/>                       
                                    <asp:Button ID="btnModificar" class="btn btn-secondary" runat="server" Text="Modificar" Width="90px" OnClick="btnModificar_Click"/>                       
                                    <asp:Button ID="btnGuardar" class="btn btn-secondary" runat="server" Text="Guardar" Width="90px" OnClick="btnGuardar_Click" />   
                                    <asp:Button ID="btnEliminar" class="btn btn-secondary" runat="server" Text="Eliminar" Width="90px" OnClick="btnEliminar_Click"/>
                                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="90px" OnClick="btnLimpiar_Click"/>  
                                </div>

                                <%--<script>
                                    $("#ContentPlaceHolder1_btnModificar").click(function() {
                                        var pass = $("#ContentPlaceHolder1_txtPassword").text();
                                        console.log(pass);
                                    });
                                </script>--%>
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
    </section>
   
    <style>
        label{
            font-weight:bold;
        }
        .btn{
            margin:3px;
        }
    </style>

    

</asp:Content>