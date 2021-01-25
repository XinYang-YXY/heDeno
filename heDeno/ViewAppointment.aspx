<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="heDeno.ViewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-900 item-center">
            <h2 class="montserrat grey-blue-second medium-font" style="margin-bottom:20px;">Your Appointments</h2>
            <asp:Repeater ID="appointment_repeater" runat="server" OnItemCommand="appointment_repeater_ItemCommand">
                <ItemTemplate>
                    <div class="card" style="background-color:rgba(130, 159, 217, 0.15); margin-top: 10px; margin-bottom: 10px; text-align:left;">
                        <div class="card-body" style="padding-bottom: 5px !important;">
                            <div class="row">                                
                                <div class="col-lg-12 col-12">
                                    <p>Clinic Name: <b><%#Eval("clinicName")%></b></p> 
                                    <p>Doctor: <b><%#Eval("firstName")%></b> <b><%#Eval("lastName")%></b></p>
                                    <p>Specialty: <b><%#Eval("clinicType")%></b></p>
                                    <p>Appointment Time: <b><%#Eval("startDateTime")%></b><b> - </b><b><%#Eval("endDateTime")%></b></p>    
                                    <asp:HiddenField runat="server" ID="hidden_id" Value='<%#Eval("id")%>' />
                                </div>
                                
                                <div class="col-12 d-flex flex-row-reverse" style="margin-top:10px;">
                                    <asp:LinkButton runat="server" ID="linkbtn" CommandName="UpdateAppointment" CssClass="montserrat rounded-full standard-btn btn-standard-width y-gap item-center" Text="Change"/>                       
\                                </div>
                            </div>                    
                        </div>
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </section>
</asp:Content>
