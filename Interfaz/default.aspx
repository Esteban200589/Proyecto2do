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
                    <div class="card card-warning" style="width:100%;height:80%;">
                            <div class="card-header" style="background-color: #757578; color: #ffffff;">
                                <h3 class="card-title">PAGINA PRINCIPAL </h3>

                                <div id="login">
                                    <a href="login.aspx" class="btn btn-secondary" style="float:right;position:absolute;right:10%;top:15px;color:white;">LOGIN</a>
                                </div>
                            </div>

                            <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                                <div class="row" style="margin: 2%;height:500px;">
                                    
                                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4" style="padding:1px;">
                                        <div class="row" style="padding:1%;margin:2%;">
                                            <%--<label class="col-form-label" for="exampleFormControlInput1">Fecha: </label>
                                            <br />--%>
                                            <asp:Calendar ID="calendario" runat="server" Height="404px" Width="100%" BackColor="White" BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black">
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
                                        <div class="row" style="padding:1%;margin:2%;">
                                            <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Filtrar" Width="45%" style="margin-left:5px;margin-right:5px;height:40%;" OnClick="btnBuscar_Click"/>                             
                                            <asp:Button ID="btnLimpiarfiltros" class="btn btn-secondary" runat="server" Text="Limpiar"  Width="45%" style="margin-left:5px;margin-right:5px;height:40%;" OnClick="btnLimpiarfiltros_Click" />
                                        </div>
                                    </div>

                                    <div class="col-xs-12 col-sm-12 col-md-12 col-lg-8" style="height: 100%;">
                                        <div class="row" style=" margin-top: 1px; height: 91%; width: 100%;">
                                            <div id="grilla" style="text-align: center; margin-top:18px; width: 100%; max-height:99%;background-color:#9b9b9b;">
                                                <div class="row" style="background-color:#9b9b9b;height:56px;width:100%;padding:1px;margin-left:1px;"">
				                                    <div class="col-3 titulo" style="height:46px;text-align:left;padding-top:15px;font-weight:bold;"> Pais </div>
				                                    <div class="col-9 titulo" style="height:46px;text-align:left;padding-top:15px;font-weight:bold;"> Ciudad </div>
			                                    </div>
                                                <asp:Xml ID="Xml_Pronosticos" runat="server" TransformSource="~/pronos.xslt"></asp:Xml>
                                            </div>
                                            <br />
                                        </div>
                                    </div>
                                
                                </div>
                            </div>

                            <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                            
                            <%--<div class="card-footer" style="background-color:#757578;"> 
                                        
                                <div class="row">
                                    <div class="col-12" style="text-align:center;">
                                        <label class="col-form-label" for="exampleFormControlInput1">&nbsp;</label>
                                        <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                    </div>
                                </div>
                            
                            </div>--%>
                    
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