<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewMC.aspx.cs" Inherits="heDeno.ViewMC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-900 item-center">
            <h2 class="montserrat grey-blue-second medium-font" style="margin-bottom:35px;">Your MC's</h2>
                   <asp:Repeater ID="mc_repeater" runat="server" OnItemCommand="mc_repeater_ItemCommand">
                       <ItemTemplate>
                           <div class="card" style="background-color:rgba(130, 159, 217, 0.15); margin-top: 10px; margin-bottom: 10px; text-align:left;">
                               <div class="card-body" style="padding-bottom: 5px !important;">
                                   <div class="row">                                
                                       <div class="col-lg-12 col-12 montserrat">
                                           <p>Medical Certificate ID: <b><%#Eval("id")%></b></p> 
                                           <p>Appointment Date: <b><%#DateTime.Parse(Eval("appointmentDate").ToString()).ToString("dd/MM/yyyy")%></b></p> 
                                           <asp:HiddenField runat="server" ID="hidden_id" Value='<%#Eval("id")%>' />
                                       </div>
                                
                                       <div class="col-12 d-flex flex-row-reverse" style="margin-top:10px;">
                                           <a href="/PatientMC/?mc=<%#Eval("id")%>"<button class="montserrat rounded-full standard-btn btn-standard-width y-gap item-center btn_cancel view_app_btn">View</button></a>
                                       </div>
                                   </div>                    
                               </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%if (mc_repeater.Items.Count == 0)  
                                { %>  
                                  <p class="montserrat grey-blue-second" style="margin-top:50px;">You have no MC's</p>
                              <%} %>  
                        </FooterTemplate>
                  </asp:Repeater>
     </section>
</asp:Content>
