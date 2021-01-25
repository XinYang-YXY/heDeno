<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateAppointment.aspx.cs" Inherits="heDeno.UpdateAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <section class="vertical-middle-landing">
        <div class="box-style box-desktop-900 item-center">
            <h2 class="montserrat grey-blue-second medium-font" style="margin-bottom:20px;">Update Appointment</h2>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-13">Appointment Details</p>
                </div>
                <asp:DropDownList runat="server" ID="select_specialty" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" required OnSelectedIndexChanged="select_specialty_SelectedIndexChanged"/>
                <asp:DropDownList runat="server" ID="select_clinic" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" required OnSelectedIndexChanged="select_clinic_SelectedIndexChanged"/>
                <asp:DropDownList runat="server" ID="select_doctor" AutoPostBack="true" CssClass="standard-inputField full-width-inputField" required/>
            </section>

            <section class="layout-inputField input-section-gap">
                <div class="inputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-13">Appointment Timings</p>
                </div>
                <div class="inputHeader-row inputHeader-row-appointment">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Preferred Date</p>
                    <asp:Textbox ID="select_date" placeholder="Preferred Date" runat="server" TextMode="Date" CssClass="standard-inputField full-width-inputField" required/>
                </div>
                <div class="inputHeader-row inputHeader-row-appointment">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Preferred Start time</p>
                    <asp:Textbox ID="select_start_time" placeholder="Preferred Start Time" runat="server" TextMode="Time" CssClass="standard-inputField full-width-inputField" Text="Preferred Start Time" required/>
                </div>
                <div class="inputHeader-row inputHeader-row-appointment">
                    <p class="montserrat grey-blue-second medium-font font-size-13">Preferred End Time</p>
                    <asp:Textbox ID="select_end_time" placeholder="Preferred End Time" runat="server" TextMode="Time" CssClass="standard-inputField full-width-inputField" required/>
                </div>
            </section>
            <asp:Label ID="lbl_msg" runat="server" Text="" />
            <br />
            <asp:Button runat="server" Text="Change Appointment" cssClass="montserrat rounded-full standard-btn btn-standard-width y-gap" ID="btn_submit" OnClick="btn_submit_Click"/>
        </div>
    </section>
</asp:Content>
