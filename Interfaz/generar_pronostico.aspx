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

                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6">
                                    <div class="form-group col-12">
                                        <label>NÚMERO INTERNO</label>
                                        <asp:TextBox  ID="txtInterno" class="form-control" runat="server"  Width="20%"  ToolTip=" " ></asp:TextBox>
                                    </div>
                                    
                                    <div class="form-group col-12">
                                        <label>FECHA</label>
                                        <asp:TextBox  ID="txtFecha" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>
                                    </div>
                                  
                                    <div class="form-group col-12">
                                        <label>CIUDAD</label>
                                        <asp:DropDownList ID="ddlCiudades" class="btn btn-default" runat="server" > </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-12">
                                        <label>USUARIO</label>
                                        <asp:TextBox  ID="txtUsuario" class="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                </div>
                                
                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6" style="border:solid;border-color:cornflowerblue;border-radius:5px;">

                                    <div class="card-header" style="text-align:center; background-color: #757578; color: #ffffff;">
                                        <h3 class="card-title">AGREGAR PRONOSTICO HORA</h3>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Hora</label>
                                        <asp:TextBox  ID="txtpsHora" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Temperatura Max.</label>
                                        <asp:TextBox  ID="txtpsMax" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Temperatura Min.</label>
                                        <asp:TextBox  ID="txtpsMin" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Velocidad Viento</label>
                                        <asp:TextBox  ID="txtpsViento" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Lluvias</label>
                                        <asp:TextBox  ID="txtpsLluvias" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Tormentas</label>
                                        <asp:TextBox  ID="txtpsTormentas" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label>Cielo</label>
                                        <asp:TextBox  ID="txtpsCielo" class="form-control" runat="server" Width="40%" ToolTip=" " ></asp:TextBox>
                                    </div>
                                    <div class="form-group col-12">
                                        <label></label>
                                        <asp:Button ID="btnAgregarPronoHora" class="btn btn-secondary" runat="server" Text="Agregar Pronostico Hora" OnClick="btnAgregarPronoHora_Click"/>     
                                    </div>
                                </div>

                                <div class="col-sm-12 col-md-6 col-lg-6 col-xl-6">
                                    <div id="grilla" style="text-align:center;margin-left:auto;margin-right:auto;width:100%;">
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
                                            </Columns>

                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                    </div><br/>
                                </div>   
                            </div>
                        </div>
                        <!-- /.card-footer -->
                        <div class="card-footer"> 
                                        
                            <div class="row">
                                <div class="col-sm-12" style="text-align:center;">
                                    <asp:Button ID="btnGenerar" class="btn btn-secondary" runat="server" Text="Generar" Width="90px" OnClick="btnGenerar_Click" />                       
                                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="90px" />
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