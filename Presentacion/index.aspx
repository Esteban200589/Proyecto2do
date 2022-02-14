<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentacion.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
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
                        <div class="row">
                            <div id="grilla" style="text-align:center;margin-left:auto;margin-right:auto;width:100%;">
                                <asp:GridView ID="gvNoticiasInicio" runat="server" Width="95%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                        <ControlStyle Width="0px" />
                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                        </asp:BoundField>
                                            
                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" >
                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Importancia" HeaderText="Importancia" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="codigo_secc" HeaderText="Sección" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                        </asp:BoundField>

                                        <asp:BoundField DataField="username" HeaderText="Usuario" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center">
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
            </div>
            <br />
            <div class="container-fluid">
                <div class="row">
                </div>
            </div>
        </section>
    </body>
</html>
</asp:Content>
