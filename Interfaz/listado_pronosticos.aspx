<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="listado_pronosticos.aspx.cs" Inherits="listado_pronosticos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            -ms-flex: 0 0 100%;
            flex: 0 0 100%;
            max-width: 100%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
            <section class="content">
            
                <div class="container-fluid">
                    <div class="row">
                        <!-- general form elements disabled -->
                        <div class="card card-warning" style="width:100%;">
                            <div class="card-header" style="background-color: #7ca3c3; color: #ffffff;">
                                <h3 class="card-title">BIENVENIDO</h3>
                            </div>
                            <br />
                            <br />
                            <div class="auto-style1" style="padding:1px;">
                                <div class="row" style="padding:1%;margin:2%;">
                                    <div class="col-2">
                                        <label>Fecha: </label>
                                        <asp:TextBox ID="txtFecha" class="form-control" runat="server" TextMode="Date" ></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label>Ciudad: </label>
                                        <asp:DropDownList ID="ddlCiudades" class="form-control" runat="server" ></asp:DropDownList>
                                    </div>
                                    <div class="col-2">
                                        <label>Meteorologo: </label>
                                        <asp:TextBox ID="txtMeteorologo" class="form-control" runat="server" ></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label>&nbsp;</label>
                                        <asp:Button ID="btnFiltar" class="btn btn-secondary" runat="server" Text="Filtrar" OnClick="btnFiltar_Click" style="margin-top:1px;width:100%;" />                             
                                    </div>
                                    <div class="col-2">
                                        <label>&nbsp;</label>
                                        <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" style="margin-top:1px;width:100%;" />
                                    </div>
                                   
                                </div>

                                <div class="row col-12" style="margin-top:2%;">
                                    <div id="grilla" style="text-align:center;margin-left:auto;margin-right:auto;width:100%;">
                                        <asp:GridView ID="gvListadoPronosticos" runat="server" Width="95%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" class="table"
                                                      BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gvListadoPronosticos_SelectedIndexChanged" >
                                            <Columns>
                                                <asp:BoundField DataField="Interno" HeaderText="Nro Interno" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                                <ControlStyle Width="0px" />
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                                </asp:BoundField>
                                            
                                                <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Usuario.Username" HeaderText="Usuario" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Ciudad.Nombre_ciudad" HeaderText="Ciudad" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                                <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                </asp:BoundField>

                                                <asp:CommandField ShowSelectButton="True" >
                                                <HeaderStyle BackColor="#7CA3C3" />
                                                </asp:CommandField>

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

                                <script>
                                    $('#ContentPlaceHolder1_ddlCiudades > option[value="AAAAAA"]').text('Todas');

                                    var fechas = $("#ContentPlaceHolder1_gvListadoPronosticos > tbody > tr > td:nth-child(2)");
                                    $.each(fechas, function (i, v) {
                                        //console.log(v);
                                        var log = $(v).text().replace(" 0:00:00", "");
                                        //console.log(log);
                                        $(v).text(log);
                                    });
                                </script>
                            </div>
                              
                            <div class="col-form-label">
                                <asp:Label runat="server" ID="lblMsj"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
           
            </section>
     
</asp:Content>