<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMedicalRecords.aspx.cs" Inherits="heDeno.ViewMedicalRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Records</h2>
            <asp:Panel ID="allMRs" runat="server" Enabled="true" AutoPostBack="true" class="long-layout-inputField input-section-gap">
            </asp:Panel>
        </div>
    </section>
</asp:Content>
