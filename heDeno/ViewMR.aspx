<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMR.aspx.cs" Inherits="heDeno.ViewMR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-950 item-center">
            <h2 class="montserrat grey-blue-second medium-font">Medical Record</h2>

            <asp:Panel ID="allRecords" runat="server" class="record-inputField input-section-gap">
                <asp:Label runat="server"  class="record-titlesnew RecordIDTitle" text="Medical Record ID:"></asp:Label>
                <asp:Label runat="server"  class="records RecordID" ID="RecordID"></asp:Label>
                <asp:Label runat="server"  class="record-titlesnew RecordDateTitle" text="Date:"></asp:Label>
                <asp:Label runat="server"  class="records RecordDate" ID="RecordDate"></asp:Label>
                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Patient Information</p>
                </div>
                <asp:PlaceHolder 
                ID="PlaceHolder1"
                runat="server"
                >
                </asp:PlaceHolder>

                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Allergies</p>
                </div>
                <asp:PlaceHolder 
                ID="PlaceHolder2"
                runat="server"
                >
                </asp:PlaceHolder>

                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Family Medical History</p>
                </div>
                <asp:PlaceHolder 
                ID="PlaceHolder3"
                runat="server"
                >
                </asp:PlaceHolder>

                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Current Medications</p>
                </div>
                <asp:PlaceHolder 
                ID="PlaceHolder4"
                runat="server"
                >
                </asp:PlaceHolder>

                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Diagnosis</p>
                </div>
                <asp:Label runat="server"  class="record-titlesnew">Diagnosis:</asp:Label>
                <asp:Label runat="server"  class="records" ID="Diagnosis"></asp:Label>

                <div class="recordinputHeader-row">
                    <p class="montserrat grey-blue-second bold-font font-size-11">Comments</p>
                </div>
                <asp:PlaceHolder 
                ID="PlaceHolder5"
                runat="server"
                >
                </asp:PlaceHolder>

            </asp:Panel>

        </div>
    </section>
</asp:Content>
