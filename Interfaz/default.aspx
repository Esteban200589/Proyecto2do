﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<%--<%@ Register src="m.ascx" tagname="mostrar_noticia" tagprefix="uc1" %>--%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina de Inicio</title>
    <link href="style/estilos.css" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="javascript" src="style/bootstrap.min.js"></script>
    <script type="javascript" src="style/popper.js"></script>
    <script type="javascript" src="style/jquery-3.0.0-vsdoc.js"></script>
</head>
<body>
    <form id="form1" runat="server">      
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                        <!-- general form elements disabled -->
                        <div class="card card-warning" style="width:100%;">
                            <div class="card-header" style="background-color: #757578; color: #ffffff;">
                                <h3 class="card-title">PAGINA INICIAL DEFAULT </h3>
                            </div>

                            <div class="col-sm-12">

                                <div class="row" style="margin:2%;">
                                    
                                    <div id="login">
                                        <a href="login.aspx" style="float:right;position:absolute;right:10%;top:-60px;color:white;">LOGIN</a>
                                    </div>

                                    <div class="col-sm-3">
                                        <div class="row" style="padding:1%;margin:2%;">
                                            <label class="col-form-label" for="exampleFormControlInput1">Fecha: </label>
                                            <br />
                                            <asp:Calendar ID="calendario" runat="server" Height="16px" Width="400px"></asp:Calendar>
                                        </div>
                                        <div class="row" style="padding:1%;margin:2%;">
                                            <label class="col-form-label" for="exampleFormControlInput1">Sección: </label>
                                            <asp:DropDownList ID="ddlSecciones" runat="server" Width="150px">
                                                <asp:ListItem></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="row" style="padding:1%;margin:2%;">
                                            <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" Width="150px" />                             
                                            <asp:Button ID="btnLimpiarfiltros" runat="server" Text="Limpiar Filtros"  Width="150px" />
                                        </div>
                                    </div>

                                    <div class="col-sm-5">
                                        <div class="row">
                                            <div id="grilla" style="text-align:center;margin-left:auto;margin-right:auto;margin-top:4%;width:100%;">
                                                <asp:GridView ID="gvNoticias" runat="server" Width="95%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                                                                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" 
                                                                 >
                                                    <Columns>
                                                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" 
                                                                        ItemStyle-HorizontalAlign="Center" >
                                                        <ControlStyle Width="0px" />
                                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" 
                                                                        ItemStyle-HorizontalAlign="Center" >
                                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Titulo" HeaderText="Titulo" HeaderStyle-BackColor="#7ca3c3" ItemStyle-BackColor="White" 
                                                                        ItemStyle-HorizontalAlign="Center">
                                                        <HeaderStyle BackColor="#7ca3c3"></HeaderStyle>

                                                        <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:CommandField ShowSelectButton="True" 
                                                            AccessibleHeaderText="Ver" SelectText="Ver" >
                                                            <ControlStyle BackColor="Transparent" ForeColor="Red" />
                                                            <HeaderStyle BackColor="#7ca3c3" />
                                                            <ItemStyle BackColor="White" HorizontalAlign="Center" />
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
                                    </div>
                                
                                    <div class="col-sm-4">
                                        <div class="row">
                                            <div class="card card-warning" style="width:95%;background-color:darkgray;text-align:left;">
                                                <center>
                                                    <div class="col-12">
                                                        <%--<uc1:mostrar_noticia ID="mostrar_noticia1" runat="server" />--%>
                                                    </div>
                                                </center>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="card-footer"> 
                                        
                                <div class="row">
                                    <div class="col-12" style="text-align:center;">
                                        <label class="col-form-label" for="exampleFormControlInput1">&nbsp;</label>
                                        <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                    </div>
                                </div>
                            
                            </div>
                    
                        </div>
                    </div>
                </div>

                <br />

                <%--<div class="container">
                    <div class="row">
                    
                    </div>
                </div>--%>
        </section>
        

    <script>
        //$("#gvNoticias > tbody > tr:nth-child(1) > th:nth-child(1)").css("display", "none");
        //$("#gvNoticias > tbody > tr > td:nth-child(1)").css("display", "none");
    </script>
        

    </form>

    </body>
</html>