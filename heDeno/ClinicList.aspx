<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClinicList.aspx.cs" Inherits="heDeno.ClinicList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row justify-content-between vertical-center" style="background-color:#EBEBEB;">
        <div class="col-5" style="margin-left: 30px; margin-right: 30px;">
            <asp:DropDownList ID="select_specialty" CssClass="standard-inputField full-width-inputField" runat="server" ForeColor="#829FD9"></asp:DropDownList>
        </div>
        <div class="col-3">
            <asp:Button ID="Button1" runat="server" Text="Go" class="montserrat rounded-full standard-btn-secondary btn-standard-width y-gap" OnClick="Button1_Click" />
        </div>
    </div>
    <div class="container mt-4">
        <%  if (clinicList.Count > 0)
            {%>
            <div class="row" style="padding:10px; border: 1px solid #829FD9; background-color:#829FD9;">
                <div class="col">
                    <h1 class="montserrat" style="color:white;">List of <%=specialty%> Clinics</h1>
                </div>
            </div>
        <%  foreach (var c in clinicList)
            {%>
                <div class="row" style="padding:35px; border: 1px solid #829FD9; align-items:center">
                    <div class="col-10">         
                        <h3 class="montserrat grey-blue"><%= c.ClinicName %></h3>
                        <span class="clinic-info"><%= c.Address %></span>
                        <span class="clinic-info">Tel: <%= c.PhoneNum %></span>
                        <span class="clinic-info">Operating Hours: </span>
                        <span class="clinic-info"><%= c.StartTime %> to <%= c.EndTime %></span>
                    </div>
                    <div class="col-2" style="align-items:center">
                        <a href="BookAppointment?specialty=<%=c.ClinicType%>&clinic=<%=c.Id%>" class="montserrat rounded-full standard-btn-secondary btn-standard-width y-gap">
                            Book Here
                        </a>
                    </div>
                </div>
        <%  }%>
                
            
        <%  } else {%>
        <h1 class="montserrat grey-blue-second" >No clinic found.</h1>
        <% } %>
    </div>
</asp:Content>
