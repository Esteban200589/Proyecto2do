<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                </div>
            </div>
        </div>
        <br />
        <div class="container-fluid">
            <div class="row">
                <div class="col-3" style="background-color:chartreuse"> </div>
                <div class="col-3" style="background-color:aqua"></div>
                <div class="col-3" style="background-color:brown"></div>
                <div class="col-3" style="background-color:blueviolet"></div>
                <div class="col-3" style="background-color:chocolate"></div>
                <div class="col-3" style="background-color:darksalmon"></div>
            </div>
        </div>
    </section>
  
</asp:Content>