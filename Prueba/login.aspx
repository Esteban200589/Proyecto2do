<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="style/estilos.css" rel="stylesheet"/>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script type="javascript" src="style/bootstrap.min.js"></script>
    <script type="javascript" src="style/popper.js"></script>
    <script type="javascript" src="style/jquery-3.0.0-vsdoc.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="text-align:center; width:50%;max-width:60%; opacity:75; padding:1%;">
            <div class="row">
                <div class="col-md-6 mx-auto">
                    <div class="card">
                         <div class="card-body">
                            <div class="row">
                                <div class="col">
                                    <%--<center>
                                        <h3>Login</h3>
                                    </center>--%>
                                </div>
                            </div>
                            <div class="row">
                                <asp:TextBox runat="server" id="txtUser" class="form-control" placeholder="Username" ToolTip="Username"></asp:TextBox>
                            </div><br />
                            <div class="row">
                                <asp:TextBox runat="server" id="txtPass" class="form-control" placeholder="Password" TextMode="Password" ToolTip="Password"></asp:TextBox>
                            </div><br /><br />
                            <div class="row">
                                <div style="text-align:center; margin:auto;">
                                    <asp:Button runat="server" id="btnLogin" type="submit" class="btn btn-secondary" text="Login" 
                                        style="margin-left:auto; margin-right:auto;" OnClick="btnLogin_Click"  />
                                    <asp:Button runat="server" id="btnVolver" type="submit" class="btn btn-secondary" text="Volver" 
                                        style="margin-left:auto; margin-right:auto;"/>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        <div>                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
        </div><br/>
    </div>
    </form>
</body>
</html>