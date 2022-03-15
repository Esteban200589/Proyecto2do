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
                            <div class="row col-12">
                                <div class="col-8">
                                    <h1 id="titulo" class="card-title">PAGINA PRINCIPAL </h1>
                                </div>
                                <div class="col-4">
                                    <a id="login" href="login.aspx" class="btn btn-secondary">LOGIN</a>
                                </div>
                            </div>
                            
                        </div>

                        <div class="col-xs-12 col-sm-12 col-md-12 col-lg-12">
                            <div class="row" style="margin: 2%;height:500px;">
                                    
                                <div class="row col-12 ciudad">
                                    <div id="lblCiudad" class="col-form-label">Ciudad: </div>
                                    <div>
                                        <asp:DropDownList ID="ddlCiudades" class="btn btn-default" runat="server"> </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-xs-12 col-sm-12 col-md-12 col-lg-4" style="padding:1px;">
                                    <div class="row" style="padding:1%;margin:2%;">    
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
                                            
                                        <%--<div id="grilla1" runat="server" style="text-align: center; margin-top:1.55%; width: 100%; max-height:99%;background-color:#9b9b9b;"> 
                                            <div class="row" style="background-color:#9b9b9b;height:56px;width:100%;padding:1px;margin-left:1px;"">
				                                <div class="col-3 titulo" style="height:46px;text-align:left;padding-top:15px;font-weight:bold;"> Pais </div>
				                                <div class="col-9 titulo" style="height:46px;text-align:left;padding-top:15px;font-weight:bold;"> Ciudad </div>
			                                </div>
                                            <asp:Xml ID="Xml_Pronosticos" runat="server" TransformSource="~/pronos.xslt"></asp:Xml>
                                        </div>--%>

                                        <div id="grilla2" class="col-5" runat="server" style="text-align: center; margin-top:1.55%; width: 100%; max-height:99%;background-color:#9b9b9b;"> 
                                            <asp:GridView ID="gvPronosticos" runat="server" Width="95%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" CellPadding="4"
                                                          BorderStyle="None" BorderWidth="1px"  ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPronosticos_SelectedIndexChanged" >
                                                <Columns>
                                                    <asp:BoundField DataField="Interno"  HeaderStyle-BackColor="#9b9b9b" >
                                                    <ControlStyle BackColor="#FFFFCC" />
                                                    <HeaderStyle BackColor="#9b9b9b"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" BackColor="#FFFFCC"></ItemStyle>                      
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Pais" HeaderText="Pais" HeaderStyle-BackColor="#9b9b9b" >
                                                    <HeaderStyle BackColor="#9b9b9b"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>                      
                                                    </asp:BoundField>

                                                    <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" HeaderStyle-BackColor="#9b9b9b" >
                                                    <HeaderStyle BackColor="#9b9b9b"></HeaderStyle>
                                                    <ItemStyle HorizontalAlign="Center" BackColor="White"></ItemStyle>
                                                    </asp:BoundField>

                                                    <asp:CommandField ShowSelectButton="True">
                                                    <HeaderStyle BackColor="#9B9B9B" />
                                                    </asp:CommandField>

                                                </Columns>

                                            </asp:GridView>
                                        </div>

                                        <div id="prono_hora" class="col-7" runat="server" style="text-align: center; margin-top:1.55%; width: 100%; max-height:99%;background-color:#9b9b9b;">
                                            <asp:Xml ID="Xml_Pronosticos" runat="server" TransformSource="~/pronos.xslt"></asp:Xml>
                                        </div>

                                        <br />

                                    </div>
                                </div>

                                <div class="col-12" style="text-align:center;">
                                    <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                </div>
                                
                            </div>
                        </div>

                        <%--<div class="card-footer" style="background-color:#757578;"> 
                                        
                            <div class="row">
                                <div class="col-12" style="text-align:center;">
                                    <label class="col-form-label" for="exampleFormControlInput1">&nbsp;</label>
                                    <asp:Label id="lblMsj" class="col-form-label" for="exampleFormControlInput1" runat="server"></asp:Label>
                                </div>
                            </div>
                            
                        </div>--%>
                    
                        <style>
                            #_ph_{
                                border-width: 1px;
                                border-color: black;
                                border-style: solid;
                                border-top:thin black;
                                border-collapse:separate; 
                                border-spacing:0px;
                            }
                            
                        </style>
                    </div>   
                </div>

            </div>
        </section>
    </form>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="javascript" src="style/bootstrap.min.js"></script>
    <script type="javascript" src="style/popper.js"></script>
    <script type="javascript" src="style/jquery-3.0.0-vsdoc.js"></script>

    <script>

        //var links = $('#gvPronosticos > tbody > tr > td:nth-child(4)').parent();
        
        //$.each(links, function (i, v) {        
        //    $(v).attr('onclick', 'linkear(' + (i+1) + ')');
        //    $(v).attr('id', 'line_' + (i+1));
        //});

        //$('#gvPronosticos > tbody > tr').hover(
        //    function () {
        //        $(this).css('background-color', '#FFFFCC');
        //    }, function () {
        //        $(this).css('background-color', 'white');
        //    }
        //);

        //var internos = $("#_ph_ > div:nth-child(1)").text().split('');

        //var phs = $("#_ph_ > div:nth-child(1)").parent();

        //$.each(phs, function (i, v) { 
        //    $(v).attr('id', 'pt_'+internos[i]);
        //});

        //function linkear(key) {
            
        //    $.each($("div[id*='pt_']"), function (i, v) {
        //        var interno = v.id.replace('pt_', '');
        //        console.log($('#' + v.id + ':nth-child(0)'));
        //        $('#' + v.id + 'div:nth-child(0)').css('display', 'none');
        //        if (interno == key) {
        //            $(v).css('display', 'block');
                    
        //        }
        //    });

        //}
        

        //$("#  > tbody > tr:nth-child(1) > th:nth-child(1)").css("display", "none");
        //$("#  > tbody > tr > td:nth-child(1)").css("display", "none");

        //$("#  > tbody > tr").each(
        //    function (indice, elemento) {
        //        var fecha = elemento.cell;
        //        console.log(elemento);
        //        console.log(fecha);
        //    }
        //);

    </script>
    
    </body>
</html>