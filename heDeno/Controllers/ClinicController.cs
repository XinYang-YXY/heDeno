using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using heDenoDB.Entity;

namespace heDeno.Controllers
{
    public class ClinicController : ApiController
    {
        [HttpGet]
        public List<Clinic> getClinicList(string specialty)
        {
            List<Clinic> clinicList = new List<Clinic>();
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            clinicList = client.GetClinicBySpecialty(specialty).ToList<Clinic>();

            return clinicList;
        }
    }
}
