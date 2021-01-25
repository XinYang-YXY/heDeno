using heDenoDB.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace heDenoDB
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<Appointment> GetAppointmentsByPatientId(int patientId)
        {
            Appointment appointment = new Appointment();
            return appointment.SelectByPatientId(patientId);
        }
        public int CreateAppointment(DateTime startDateTime, DateTime endDateTime, int doctorId, int patientId)
        {
            Appointment appointment = new Appointment(startDateTime, endDateTime, doctorId, patientId);
            return appointment.Insert();
        }
        public int UpdateAppointment(int id, DateTime startDateTime, DateTime endDateTime, int doctorId, int patientId)
        {
            Appointment appointment = new Appointment();
            return appointment.Update(id, startDateTime, endDateTime, doctorId, patientId);
        }
        public Appointment GetOneAppointment(int id)
        {
            Appointment appointment = new Appointment();
            return appointment.SelectOneAppointment(id);
        }

    }
}
