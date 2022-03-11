<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Pagina de Inicio</title>
    <link href="style/estilos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section class="content">
            
            <div class="container-fluid">
                <div class="row">
                    <!-- general form elements disabled -->
                    <div class="card card-warning" style="width: 100%;">
                        <div class="card-header" style="background-color: #757578; color: #ffffff;">
                            <h3 class="card-title">PAGINA PRINCIPAL </h3>
                        </div>

                        <div class="col-sm-12">
                            <div class="row" style="margin: 2%;height:765px;">

                                <div id="login">
                                    <a href="login.aspx" style="float: right; position: absolute; right: 10%; top: -60px; color: white;">LOGIN</a>
                                </div>

                                <div class="col-sm-3" style="padding: 1px;">
                                    <div class="row" style="padding: 1%; margin: 2%;">
                                        <%--<label class="col-form-label" for="exampleFormControlInput1">Fecha: </label>
                                            <br />--%>
                                        <asp:Calendar ID="calendario" runat="server" Height="404px" Width="100%" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" SelectedDate="03/06/2022 15:41:31">
                                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                                            <NextPrevStyle VerticalAlign="Bottom" />
                                            <OtherMonthDayStyle ForeColor="#808080" />
                                            <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                                            <SelectorStyle BackColor="#CCCCCC" />
                                            <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                                            <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                                            <WeekendDayStyle BackColor="#FFFFCC" />
                                        </asp:Calendar>
                                    </div>
                                    <div class="row" style="padding: 1%; margin: 2%;">
                                        <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" Width="49%" Style="margin-right: 3px; height: 40%;" OnClick="btnBuscar_Click" />
                                        <asp:Button ID="btnLimpiarfiltros" runat="server" Text="Limpiar Filtros" Width="49%" OnClick="btnLimpiarfiltros_Click" />
                                    </div>
                                </div>

                                <div class="col-sm-9" style="height: 60%;overflow-y:scroll;">
                                    <div class="row" style=" margin-top: 1px; height: 91%; width: 100%;">
                                        <div id="grilla" style="text-align: center; margin-top: 1%; width: 100%; max-height: 70%;">
                                            <asp:Xml ID="Xml_Pronosticos" runat="server" TransformSource="~/pronos.xslt"></asp:Xml>
                                        </div>
                                        <br />
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="card-footer">

                            <div class="row">
                                <div class="col-12" style="text-align: center;">
                                    <label class="col-form-label" for="exampleFormControlInput1">&nbsp;</label>
                                    <asp:Label ID="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                </div>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </section>
    </form>
        
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="javascript" src="style/bootstrap.min.js"></script>
    <script type="javascript" src="style/popper.js"></script>
    <script type="javascript" src="style/jquery-3.0.0-vsdoc.js"></script>

    </body>
</html>