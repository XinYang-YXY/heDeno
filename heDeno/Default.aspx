<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="heDeno._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-between vertical-center" style="background-color:#EBEBEB;">
        <div class="col-5" style="margin-left: 30px; margin-right: 30px;">
            <asp:DropDownList ID="select_specialty" CssClass="standard-inputField full-width-inputField" ForeColor="#829FD9" runat="server"></asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Button ID="Button1" runat="server" Text="Go" class="montserrat rounded-full standard-btn-secondary btn-standard-width y-gap" OnClick="Button1_Click" />
        </div>
    </div>
    <div class="container mt-4">
        <div class="jumbotron jumbotron-fluid">
            <div class="container">
                <h1 class="display-4">Fluid jumbotron</h1>
                <p class="lead">This is a modified jumbotron that occupies the entire horizontal space of its parent.</p>
            </div>
        </div>

    </div>
</asp:Content>
