<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="generar_pronostico.aspx.cs" Inherits="generar_pronostico" %>

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
                            <h3 class="card-title">PRONOSTICO DE TIEMPO</h3>
                        </div>
                        <!-- /.card-body -->
                        <div class="card-body">
                            <div class="row">

                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-3">
                                    <%--<div class="form-group col-12">
                                        <label>NÚMERO INTERNO</label>
                                        <asp:TextBox  ID="txtInterno" class="form-control" runat="server"  Width="20%"  ToolTip=" " ></asp:TextBox>
                                    </div>--%>
                                    
                                    <div class="form-group col-12">
                                        <label>FECHA</label>
                                        <asp:TextBox  ID="txtFecha" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group col-12">
                                        <label>CIUDAD</label>
                                        <asp:DropDownList ID="ddlCiudades" class="btn btn-default" runat="server" style="background-color:#999999;text-align:left;"> </asp:DropDownList>
                                    </div>

                                    <%--<div class="form-group col-12">
                                        <label>USUARIO</label>
                                        <asp:TextBox  ID="txtUsuario" class="form-control" runat="server" ></asp:TextBox>
                                    </div>--%>
                                </div>
                                
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-9" style="border:solid;border-color:#757578;padding:0px;margin:0px;">

                                    <div class="card-header" style="text-align:center; background-color: #757578; color: #ffffff;width:100%;padding:0px;">
                                        <h3 class="card-title">AGREGAR PRONOSTICO HORA</h3>
                                    </div>

                                    <div class="row" style="margin-left:1%;margin-right:1%;">
                                        <div class="form-group col-3">
                                            
                                            <label>Hora</label>
                                            <div class="row col-12" style="margin:0px;padding:0px;">
                                                <div class="col-5" style="padding:0px;margin-right:10px;">
                                                    <asp:TextBox  ID="txtpsHora" class="form-control" runat="server" ToolTip="Horas"></asp:TextBox>
                                                </div>
                                                <span style="font-size:20px;font-weight:bold;margin:1px;margin-right:10px;">:</span>
                                                <div class="col-5" style="padding:0px;">
                                                    <asp:TextBox  ID="txtpsMin" class="form-control" runat="server" ToolTip="Minutos"></asp:TextBox>
                                                </div>
                                            </div>
                                            
                                        </div>
                                        <div class="form-group col-3">
                                            <label>Temperatura Max.</label>
                                            <asp:TextBox  ID="txtpsTmax" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-3">
                                            <label>Temperatura Min.</label>
                                            <asp:TextBox  ID="txtpsTmin" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-3">
                                        <label>Velocidad Viento</label>
                                            <asp:TextBox  ID="txtpsViento" class="form-control" runat="server" ></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row" style="margin-left:1%;margin-right:1%;">
                                        
                                        <div class="form-group col-3">
                                            <label>Lluvias</label>
                                            <asp:TextBox  ID="txtpsLluvias" class="form-control" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="form-group col-3">
                                            <label>Tormentas</label>
                                            <asp:TextBox  ID="txtpsTormentas" class="form-control" runat="server"></asp:TextBox>              
                                        </div>
                                        <div class="form-group col-4">
                                        <label>Cielo</label>
                                            <%--<asp:TextBox  ID="txtpsCielo" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>--%>
                                            <asp:DropDownList ID="ddlCielo" class="form-control" runat="server">
                                                <asp:ListItem Value="nuboso" Text="Nuboso"></asp:ListItem>
                                                <asp:ListItem Value="parcialmente_nuboso" Text="Parcialmente Nuboso"></asp:ListItem>
                                                <asp:ListItem Value="despejado" Text="Despejado"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="form-group col-6">
                                            <label></label>
                                        </div>
                                        <div class="form-group col-6" style="float:right;">
                                            <label></label>
                                            <asp:Button ID="btnAgregarPronoHora" class="btn btn-secondary" runat="server" Text="Agregar Pronostico Hora" style="float:right;margin-right:10px;" OnClick="btnAgregarPronoHora_Click"/>     
                                        </div>
                                    </div>
                                    
                                </div>

                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-12">
                                    <div id="grilla" style="text-align:center;margin:2%;width:100%;">
                                        <asp:GridView ID="gvPronosticosHora" runat="server" Width="95%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                                                      BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
                                            <Columns>
                                                <asp:BoundField DataField="Hora" HeaderText="Hora" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                                <ControlStyle Width="0px" />
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                                </asp:BoundField>
                                            
                                                <asp:BoundField DataField="Temp_max" HeaderText="Temperatura Max." HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Temp_min" HeaderText="Temperatura Max." HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="V_viento" HeaderText="Viento (m/s^2)" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Prob_lluvias" HeaderText="Lluvias (%)" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Prob_tormenta" HeaderText="Tormenta (%)" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Tipo_cielo" HeaderText="Cielo" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>
                                                <asp:ButtonField Text="Quitar" />
                                            </Columns>

                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <HeaderStyle BackColor="#7ca3c3" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                    </div><br/>


                                    <script>
                                        $.each($("#ContentPlaceHolder1_gvPronosticosHora > tbody > tr > td:nth-child(1)"), function (i, v) {
                                            var horas = $(v).text().substring(0,2);
                                            var minutos = $(v).text().substring(2,4);
                                            $(v).text(horas + ':' + minutos);
                                        });

                                        let tipo_cielo = {
                                            'nuboso': 'Nuboso',
                                            'parcialmente_nuboso': 'Parcialmente Nuboso',
                                            'despejado': 'Despejado',
                                        };

                                        $.each($("#ContentPlaceHolder1_gvPronosticosHora > tbody > tr > td:nth-child(7)"), function (i, v) {
                                            var tipo = $(v).text();
                                            $(v).text(tipo_cielo[tipo]);
                                        });
                                    </script>
                                </div>   
                            </div>
                        </div>
                        <!-- /.card-footer -->
                        <div class="card-footer"> 
                                        
                            <div class="row">
                                <div class="col-sm-12" style="text-align:center;">
                                    <asp:Button ID="btnGenerar" class="btn btn-secondary" runat="server" Text="Generar" Width="90px" OnClick="btnGenerar_Click" />                       
                                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="90px" OnClick="btnLimpiar_Click" />
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