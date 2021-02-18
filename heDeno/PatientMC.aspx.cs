using heDenoDB.Entity;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace heDeno
{
    public partial class PatientMC : System.Web.UI.Page
    {
        MedicalCertificate mc;
        protected void Page_Load(object sender, EventArgs e)
        {
            string mc_id = Request.QueryString["mc"];
            if(mc_id == null)
            {
                Response.Redirect("ViewMC.aspx");
            }
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            mc = client.SelectOneMCById(mc_id);

            mcid.InnerText = mc.Id.ToString();
            start_date.InnerText = mc.StartDate.ToString("MM/dd/yyyy");
            end_date.InnerText = mc.EndDate.ToString("MM/dd/yyyy");
            TimeSpan diff = mc.EndDate.Subtract(mc.StartDate);
            int day = (int)diff.TotalDays;
            duration.InnerText = day.ToString() + " days";
            comments.InnerText = mc.Comments.ToString();
            //doctor_signature.InnerText = mc.DoctorSignature.ToString();
            doctor_name.InnerText = mc.doctorName;
            patient_name.InnerText = mc.patientname;
            patient_nric.InnerText = mc.nric;
            clinic_name.InnerText = mc.clinicName;
            specialization.InnerText = mc.clinicType;
            date.InnerText = mc.appointmentDate;
                
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"http://localhost:50198/PatientMC?mc={mc_id} \nDate Scanned: {DateTime.Now}", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            imgBarCode.Height = 150;
            imgBarCode.Width = 150;

            using (Bitmap bitMap = qrCode.GetGraphic(20))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                placeholder_qrcode.Controls.Add(imgBarCode);
            }


        }
    }
}