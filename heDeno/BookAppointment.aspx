<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAppointment.aspx.cs" Inherits="heDeno.BookAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <style>
        .a table tbody tr td span{
            margin-right: 10px;
            padding: 6px;
        }
    </style>

    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-900 item-center">
            <h2 class="montserrat grey-blue-second medium-font" style="margin-bottom:20px;">Book Appointment</h2>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-13">Appointment Details</p>
                </div>
                <asp:DropDownList runat="server" ID="select_specialty" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" OnSelectedIndexChanged="select_specialty_SelectedIndexChanged" required/>
                <asp:DropDownList runat="server" ID="select_clinic" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" OnSelectedIndexChanged="select_clinic_SelectedIndexChanged" required/>
                <asp:DropDownList runat="server" ID="select_doctor" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" required OnSelectedIndexChanged="select_doctor_SelectedIndexChanged"/>
            </section>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-13">Appointment Date</p>
                </div>
                <div class="inputHeader-row inputHeader-row-appointment">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Date</p>
                    <asp:Textbox ID="select_date" placeholder="Preferred Date" runat="server" TextMode="Date" CssClass="standard-inputField full-width-inputField" required OnTextChanged="select_date_TextChanged" AutoPostBack="true"/>
                </div>
            </section>
            
            <section class="a montserrat grey-blue-second" style="margin-left: 30px; margin-right: 30px; margin-bottom:60px;">
                <asp:RadioButtonList runat="server" ID="available_timeslots" RepeatDirection="Horizontal">
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator runat="server" ID="rfv1" ControlToValidate="available_timeslots" ErrorMessage="Please select a timeslot"/>
            </section>

            <asp:Label ID="lbl_msg" runat="server" Text="" />
            <br />
            <asp:Button runat="server" Text="Book Appointment" cssClass="montserrat rounded-full standard-btn btn-standard-width y-gap" ID="btn_submit" OnClick="btn_submit_Click"/>
        </div>
    </section>
    
</asp:Content>
