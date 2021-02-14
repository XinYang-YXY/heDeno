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
        public List<Specialty> GetAllSpecialty()
        {
            Specialty specialty = new Specialty();
            return specialty.SelectAllSpecialty();
        }
        public List<Clinic> GetClinicBySpecialty(string specialty)
        {
            Clinic clinic = new Clinic();
            return clinic.SelectBySpecialty(specialty);
        }
        public Clinic GetOneClinic(string clinic_name)
        {
            Clinic clinic = new Clinic();
            return clinic.SelectByName(clinic_name);
        }
        public List<Doctor> GetDoctorByClinic(string clinic_id)
        {
            Doctor doctor = new Doctor();
            return doctor.SelectByClinic(clinic_id);
        }

        public int CreatePatient(Guid uuid, string email, string phoneNum, string firstName,
            string lastName, DateTime dateOfBirth, string gender, string password)
        {
            Patient patient = new Patient(null, email, phoneNum, firstName, lastName, dateOfBirth, gender);
            return patient.Insert(uuid, password);
        }

        public Patient getPatientByEmail(string email, string password)
        {
            Patient patient = new Patient();
            return patient.GetByEmail(email, password);
        }

        public Patient getById(string id)
        {
            Patient patient = new Patient();
            return patient.GetById(id);
        }

        public int updateEmail(string secretId, string email)
        {
            Patient patient = new Patient();
            return patient.updateEmail(secretId, email);
        }

        public int updatePhoneNum(string secretId, string phoneNum)
        {
            Patient patient = new Patient();
            return patient.updatePhoneNum(secretId, phoneNum);
        }

        public int verifyEmail(string secretId)
        {
            Patient patient = new Patient();
            return patient.verifyEmail(secretId);
        }

        public bool isEmailVerified(string email)
        {
            Patient patient = new Patient();
            return patient.isEmailVerified(email);
        }
    }
}
