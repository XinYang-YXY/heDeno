<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMI.aspx.cs" Inherits="heDeno.ViewMI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<link href="~/Content/nyCss/shared/inputField.css" rel="stylesheet" type="text/css" media="screen" runat="server" />--%>
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Instruction</h2>

            <asp:Panel ID="allRecords" runat="server" class="record-inputField input-section-gap">
                <asp:Label runat="server"  class="record-titles RecordIDTitle" text="Medical Instruction ID:"></asp:Label>
                <asp:Label runat="server"  class="records RecordID" ID="RecordID"></asp:Label>
                <asp:Label runat="server"  class="record-titles RecordIDTitle" text="Doctor Name:"></asp:Label>
                <asp:Label runat="server"  class="records RecordID" ID="DoctorName"></asp:Label>
                <asp:Label runat="server"  class="record-titles RecordDateTitle" text="Date:"></asp:Label>
                <asp:Label runat="server"  class="records RecordDate" ID="RecordDate"></asp:Label>
                <asp:Label runat="server"  class="record-titles RecordIDTitle" text="Clinic Name:"></asp:Label>
                <asp:Label runat="server"  class="records RecordID input-section-gap" ID="ClinicName"></asp:Label>

                <div class="recordinputHeader-row record-titlesnew">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Medical Instruction</p>
                </div>
                <asp:PlaceHolder 
                ID="MIPlaceholder"
                runat="server"
                >
                </asp:PlaceHolder>

            </asp:Panel>

        </div>
    </section>
</asp:Content>
