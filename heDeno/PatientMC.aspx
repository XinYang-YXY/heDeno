<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientMC.aspx.cs" Inherits="heDeno.PatientMC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        span{
            font-weight: bold;
        }
    </style>

    <div class="container montserrat card pt-2">
        <h3 class="text-center" style="margin-bottom:35px;">Medical Certificate</h3>
        <div class="d-flex flex-start">
            <p>MC ID: <span runat="server" id="mc_id">1</span></p>
        </div>        
        <div class="d-flex justify-content-between" style="margin-bottom:3.5rem;">
            <div>
                <p>NAME: <span runat="server" id="patient_name">John Doe</span></p>
            </div>
            <div>
                <p>NRIC: <span runat="server" id="patient_nric">T998887A</span></p>
            </div>
        </div>
        <div>
            <p>This is to certify that above-named is unfit for <span runat="server" id="duration">2 days</span> from <span runat="server" id="start_date">19-Apr-2018</span> to <span runat="server" id="end_date">20-Apr-2018</span>.</p>
        </div>
        <div>
            <p>Type of medical leave granted: <span runat="server" id="medical_leave">Hospitaliation Leave</span></p>
        </div>
        <div style="margin-bottom:3.5rem;">
            <p>Comments:</p>
            <span runat="server" id="comments">frfruf9runfunfuvnfvufnvufnvfuvnfunvuf</span>
        </div>
        <div class="row" style="margin-bottom:30px;">
            <div class="col-lg-4 col-4">
                <p>CLINIC NAME:</p>
                <span runat="server" id="clinic_name">Tan Tock Seng</span>
            </div>
            <div class="col-lg-4 col-4">
                <p>DOCTOR NAME:</p>
                <span runat="server" id="doctor_name">Dr Lim</span>
            </div>
            <div class="col-lg-4 col-4">
                <p>SPECIALIZATION:</p>
                <span runat="server" id="specialization">Cardiology</span>
            </div>
        </div>
        <div class="row" style="margin-bottom:3.5rem;">
            <div class="col-lg-4 col-4">
                <p>DATE :</p>
                <span runat="server" id="date">Dr Lim</span>
            </div>
            <div class="col-lg-4 col-4">
                <p>DOCTOR SIGNATURE:</p>
                <span runat="server" id="doctor_signature">????</span>
            </div>
            <div class="col-lg-4 col-4">
            </div>
        </div>
        <div>
            <p class="text-center">This medical certificate is retrieved from <span runat="server" id="mc_url">https://www.google.com</span></p>
        </div>
        <div class="text-center">
            <asp:Placeholder ID="placeholder_qrcode" runat="server"/>
        </div>
    </div>
</asp:Content>
