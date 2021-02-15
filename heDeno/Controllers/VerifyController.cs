using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;

using heDenoDB.Entity;


namespace heDeno.Controllers
{
    public class VerifyController : ApiController
    {
        [HttpGet]
        public int VerifyEmail(string id)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            int result = client.verifyEmail(id);

            return result;
        }

        [HttpGet]
        public bool isEmailVerified(string email)
        {
            MyDenoDBServiceReference.Service1Client client = new MyDenoDBServiceReference.Service1Client();
            bool isVerified = client.isEmailVerified(email);

            return isVerified;
        }

    }
}
