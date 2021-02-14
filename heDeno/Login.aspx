<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="heDeno.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-400 item-center">
            <section class="align-vertical">
                <h2 class="montserrat grey-blue-second medium-font">Patient Login</h2>
                <asp:Label ID="lbl_error" runat="server" ForeColor="#FF3300"></asp:Label>
                <div class="row m-3">
                    <div class="col">
                        <asp:TextBox ID="tb_email" runat="server" class="standard-inputField w-100" placeholder="Email" required></asp:TextBox>
                    </div>
                </div>
                <div class="row m-3">
                    <div class="col">
                        <asp:TextBox ID="tb_password" runat="server" class="standard-inputField w-100" placeholder="Password" required TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <asp:Button ID="btn_login" runat="server" Text="Login" class="montserrat rounded-full standard-btn w-80 y-gap" OnClick="btn_login_Click"/>
                <a class="nav-link grey-blue navigation-opacity montserrat small-text mb-5" runat="server" href="~/">
                    Forgot your Email or Password?
                </a>
                <a class="nav-link grey-blue navigation-opacity montserrat medium-text" runat="server" href="~/Register">
                    Register an account
                </a>
            </section>
        </div>
    </section>
</asp:Content>
