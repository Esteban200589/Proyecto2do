<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="listado_sin_asignacion.aspx.cs" Inherits="listado_sin_asignacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <section class="content">
            
        <div class="container-fluid">
            <div class="row">
                <!-- general form elements disabled -->
                <div class="card card-warning" style="width:100%;">
                    <div class="card-header" style="background-color: #7ca3c3; color: #ffffff;">
                        <h3 class="card-title">LISTADO SIN ASIGNACIÓN</h3>
                    </div>
                    <br />
                    <br />
                    <div class="col-12" style="padding:1px;">                   
                        <div class="row" style="padding:1%;margin:2%;text-align:center;">
                                    
                            <div class="col-3">
                                <asp:Button  ID="btnListarCiudades" class="btn btn-secondary" runat="server" Text="Listar Ciudades Sin Pronosticos"  OnClick="btnListarCiudades_Click"/>                             
                            </div>
                                        
                            <div class="col-3">
                                <asp:Button  ID="btnListarMeteorologos" class="btn btn-secondary" runat="server" Text="Listar Meteorologos Sin Pronosticos"  OnClick="btnListarMeteorologos_Click" />
                            </div>
                                    
                            <div  class="col-4 row">
                                <div class="col-4 col-form-label">
                                    Año:
                                </div>
                                <div  class="col-5">
                                    <asp:TextBox ID="txtAnio" class="form-control" runat="server" TextMode="SingleLine">  </asp:TextBox>
                                </div>
                            </div>
                            
                                    
                            <div  class="col-2">
                                <asp:Button ID="txtLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" OnClick="txtLimpiar_Click" >  </asp:Button>
                            </div>

                            <div class="row col-12" style="margin-top:2%;">
                                <div id="grillaCiudades" runat="server" style="text-align:center;margin-left:auto;margin-right:auto;width:100%;">
                                    <asp:GridView ID="gvCiudades" runat="server" Width="95%" HorizontalAlign="Center" 
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
                                        <Columns>
                                            <asp:BoundField DataField="Codigo"          HeaderText="Codigo" />
                                            <asp:BoundField DataField="Pais"            HeaderText="Pais" />
                                            <asp:BoundField DataField="Nombre_ciudad"   HeaderText="Ciudad" />
                                        </Columns>
                                    </asp:GridView>
                                </div><br/>
                                <div id="grillaMeteorolos" runat="server" style="text-align:center;margin-left:auto;margin-right:auto;width:100%;">
                                    <asp:GridView ID="gvMeteorologos" runat="server" Width="95%" HorizontalAlign="Center" 
                                                    BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                                                    CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
                                        <Columns>
                                            <asp:BoundField DataField="Username"        HeaderText="Username" />
                                            <asp:BoundField DataField="Nombre"          HeaderText="Nombre" />
                                            <asp:BoundField DataField="Telefono"        HeaderText="Telefono" />
                                            <asp:BoundField DataField="Correo"          HeaderText="Correo" />
                                        </Columns>
                                    </asp:GridView>
                                </div><br/>

                                <div class="col-form-label">
                                    <asp:Label runat="server" ID="lblMsj"></asp:Label>
                                </div>
                            </div> 

                        </div>
                    </div>
                         
                    <script>

                        // $('#ContentPlaceHolder1_gvCiudades > tbody > tr > td').text().split(" ")

                        $.each($('#ContentPlaceHolder1_gvCiudades > tbody > tr > td').text().split(" "), function (i, v) {
                            if (v == 'AAAAAA') {
                                //#ContentPlaceHolder1_gvCiudades > tbody > tr: nth - child(2)
                                $('#ContentPlaceHolder1_gvCiudades > tbody > tr:nth-child(2)').css('display', 'none');
                            }
                        });

                    </script>

                </div>
            </div>
        </div>
           
    </section>
    
</asp:Content>