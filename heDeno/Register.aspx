<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="heDeno.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-600 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Patient Registration</h2>
            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font">* All fields are required</p>
                </div>
                <asp:TextBox ID="tb_firstName" runat="server" class="standard-inputField" type="text" placeholder="First Name" required></asp:TextBox>
                <asp:TextBox ID="tb_lastName" runat="server" class="standard-inputField" type="text" placeholder="Last Name" required></asp:TextBox>
            </section>
            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Date of Birth</p>
                </div>
                <asp:TextBox ID="tb_dob" runat="server" class="standard-inputField" type="date" placeholder="dd/mm/yyyy" required ></asp:TextBox>
                <div class="rb-container">
                    <label class="custom-rb">
                        <span class="montserrat grey-blue-second medium-font font-size-13">Male</span>
                        <asp:RadioButton ID="rb_male" runat="server" GroupName="radio" Checked="True" value="Male"/>
                        <span class="checkmark"></span>
                    </label>
                    <label class="custom-rb">
                        <span class="montserrat grey-blue-second medium-font font-size-13">Female</span>
                        <asp:RadioButton ID="rb_female" runat="server" GroupName="radio" value="Female"/>
                        <span class="checkmark"></span>
                    </label>
                </div>
                <asp:TextBox ID="tb_phoneNum" runat="server" class="standard-inputField" type="text" placeholder="Phone Number" required ></asp:TextBox>

            </section>
            <section class="layout-inputField input-section-gap">
                <asp:TextBox ID="tb_email" runat="server" class="standard-inputField" placeholder="Email" required></asp:TextBox>
                <asp:TextBox ID="tb_nric" runat="server" class="standard-inputField" type="text" placeholder="NRIC" required></asp:TextBox>
                <asp:TextBox ID="tb_password" runat="server" class="standard-inputField" placeholder="Password" required TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="tb_cfmPassword" runat="server" class="standard-inputField" placeholder="Confirm Password" required TextMode="Password"></asp:TextBox>
            </section>
            <div class="row">
                <div class="col">
                    <asp:Label ID="lbl_forPwdStrength" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
                </div>
            </div>
            <asp:Button ID="btn_register" runat="server" class="montserrat rounded-full standard-btn btn-standard-width y-gap" Text="Register Now" OnClick="btn_register_Click" />
        </div>
    </section>
</asp:Content>
