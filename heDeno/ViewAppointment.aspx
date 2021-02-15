<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointment.aspx.cs" Inherits="heDeno.ViewAppointment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .btn_cancel{
            border: 2px solid #dc3545 !important;
            color: #dc3545 !important;
            margin-left: 5px;
        }
        .btn_cancel:hover{
            color: white !important;
            background-color: #dc3545 !important;
        }
        .view_app_btn{
            width: 200px !important;
        }
        .nav-pills .nav-link.active, .nav-pills .show > .nav-link {
            background-color: #5C73F2 !important;
        }
    </style>

    <section class="vertical-middle-landing">
        <div class="box-style box-desktop-900 item-center">
            <h2 class="montserrat grey-blue-second medium-font" style="margin-bottom:35px;">Your Appointments</h2>

            <ul class="nav nav-pills nav-fill mb-3 montserrat" id="pills-tab" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="pills-upcoming-tab" data-toggle="pill" href="#pills-upcoming" role="tab" aria-controls="pills-upcoming" aria-selected="true">Upcoming Appointments</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="pills-past-tab" data-toggle="pill" href="#pills-past" role="tab" aria-controls="pills-past" aria-selected="false">Past Appointments</a>
                </li>
            </ul>

            <div class="tab-content" id="pills-tabContent">

              <div class="tab-pane fade show active" id="pills-upcoming" role="tabpanel" aria-labelledby="pills-upcoming-tab">
                   <asp:Repeater ID="upcoming_appointment_repeater" runat="server" OnItemCommand="upcoming_appointment_repeater_ItemCommand">
                       <ItemTemplate>
                           <div class="card" style="background-color:rgba(130, 159, 217, 0.15); margin-top: 10px; margin-bottom: 10px; text-align:left;">
                               <div class="card-body" style="padding-bottom: 5px !important;">
                                   <div class="row">                                
                                       <div class="col-lg-12 col-12 montserrat">
                                           <p>Clinic Name: <b><%#Eval("clinicName")%></b></p> 
                                           <p>Doctor: <b><%#Eval("firstName")%></b> <b><%#Eval("lastName")%></b></p>
                                           <p>Specialty: <b><%#Eval("clinicType")%></b></p>
                                           <p>Appointment Time: <b><%#Eval("date")%></b> <b><%#Eval("time")%></b></p>    
                                           <asp:HiddenField runat="server" ID="hidden_id" Value='<%#Eval("id")%>' />
                                       </div>
                                
                                       <div class="col-12 d-flex flex-row-reverse" style="margin-top:10px;">
                                           <asp:LinkButton runat="server" ID="linkbtn_cancel" CommandName="CancelAppointment" CssClass="montserrat rounded-full standard-btn btn-standard-width y-gap item-center btn_cancel view_app_btn" Text="Cancel"/>   
                                           <asp:LinkButton runat="server" ID="linkbtn_update" CommandName="UpdateAppointment" CssClass="montserrat rounded-full standard-btn btn-standard-width y-gap item-center view_app_btn" Text="Change"/>   
                                       </div>
                                   </div>                    
                               </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%if (upcoming_appointment_repeater.Items.Count == 0)  
                                { %>  
                                  <p class="montserrat grey-blue-second" style="margin-top:50px;">You have no upcoming appointments</p>
                              <%} %>  
                        </FooterTemplate>
                  </asp:Repeater>
              </div>

              <div class="tab-pane fade" id="pills-past" role="tabpanel" aria-labelledby="pills-past-tab">
                   <asp:Repeater ID="past_appointment_repeater" runat="server" OnItemCommand="past_appointment_repeater_ItemCommand">
                       <ItemTemplate>
                           <div class="card" style="background-color:rgba(130, 159, 217, 0.15); margin-top: 10px; margin-bottom: 10px; text-align:left;">
                               <div class="card-body" style="padding-bottom: 5px !important;">
                                   <div class="row">                                
                                       <div class="col-lg-12 col-12 montserrat">
                                           <p>Clinic Name: <b><%#Eval("clinicName")%></b></p> 
                                           <p>Doctor: <b><%#Eval("firstName")%></b> <b><%#Eval("lastName")%></b></p>
                                           <p>Specialty: <b><%#Eval("clinicType")%></b></p>
                                           <p>Appointment Time: <b><%#Eval("date")%></b> <b><%#Eval("time")%></b></p>    
                                           <asp:HiddenField runat="server" ID="hidden_id" Value='<%#Eval("id")%>' />
                                       </div>
                                
                                       <div class="col-12 d-flex flex-row-reverse" style="margin-top:10px;">
                                       </div>
                                   </div>                    
                               </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                            <%if (past_appointment_repeater.Items.Count == 0)  
                                { %>  
                                  <p class="montserrat grey-blue-second" style="margin-top:50px;">You have no past appointments</p>
                              <%} %>  
                        </FooterTemplate>
            </asp:Repeater>
              </div>
            </div>           
        </div>
    </section>
    
</asp:Content>
