﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace heDeno.MyDenoDBServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyDenoDBServiceReference.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        heDenoDB.CompositeType GetDataUsingDataContract(heDenoDB.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<heDenoDB.CompositeType> GetDataUsingDataContractAsync(heDenoDB.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAppointmentsByPatientId", ReplyAction="http://tempuri.org/IService1/GetAppointmentsByPatientIdResponse")]
        heDenoDB.Entity.Appointment[] GetAppointmentsByPatientId(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAppointmentsByPatientId", ReplyAction="http://tempuri.org/IService1/GetAppointmentsByPatientIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Appointment[]> GetAppointmentsByPatientIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateAppointment", ReplyAction="http://tempuri.org/IService1/CreateAppointmentResponse")]
        int CreateAppointment(string date, System.TimeSpan time, int doctorId, int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreateAppointment", ReplyAction="http://tempuri.org/IService1/CreateAppointmentResponse")]
        System.Threading.Tasks.Task<int> CreateAppointmentAsync(string date, System.TimeSpan time, int doctorId, int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAppointment", ReplyAction="http://tempuri.org/IService1/UpdateAppointmentResponse")]
        int UpdateAppointment(int id, string date, System.TimeSpan time, int doctorId, int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/UpdateAppointment", ReplyAction="http://tempuri.org/IService1/UpdateAppointmentResponse")]
        System.Threading.Tasks.Task<int> UpdateAppointmentAsync(int id, string date, System.TimeSpan time, int doctorId, int patientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneAppointment", ReplyAction="http://tempuri.org/IService1/GetOneAppointmentResponse")]
        heDenoDB.Entity.Appointment GetOneAppointment(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneAppointment", ReplyAction="http://tempuri.org/IService1/GetOneAppointmentResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Appointment> GetOneAppointmentAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllSpecialty", ReplyAction="http://tempuri.org/IService1/GetAllSpecialtyResponse")]
        heDenoDB.Entity.Specialty[] GetAllSpecialty();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllSpecialty", ReplyAction="http://tempuri.org/IService1/GetAllSpecialtyResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Specialty[]> GetAllSpecialtyAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetClinicBySpecialty", ReplyAction="http://tempuri.org/IService1/GetClinicBySpecialtyResponse")]
        heDenoDB.Entity.Clinic[] GetClinicBySpecialty(string specialty);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetClinicBySpecialty", ReplyAction="http://tempuri.org/IService1/GetClinicBySpecialtyResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Clinic[]> GetClinicBySpecialtyAsync(string specialty);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneClinic", ReplyAction="http://tempuri.org/IService1/GetOneClinicResponse")]
        heDenoDB.Entity.Clinic GetOneClinic(string clinic_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetOneClinic", ReplyAction="http://tempuri.org/IService1/GetOneClinicResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Clinic> GetOneClinicAsync(string clinic_name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDoctorByClinic", ReplyAction="http://tempuri.org/IService1/GetDoctorByClinicResponse")]
        heDenoDB.Entity.Doctor[] GetDoctorByClinic(string clinic_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDoctorByClinic", ReplyAction="http://tempuri.org/IService1/GetDoctorByClinicResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Doctor[]> GetDoctorByClinicAsync(string clinic_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllAppointmentsByDoctorAndDate", ReplyAction="http://tempuri.org/IService1/GetAllAppointmentsByDoctorAndDateResponse")]
        heDenoDB.Entity.Appointment[] GetAllAppointmentsByDoctorAndDate(int doctorId, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllAppointmentsByDoctorAndDate", ReplyAction="http://tempuri.org/IService1/GetAllAppointmentsByDoctorAndDateResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Appointment[]> GetAllAppointmentsByDoctorAndDateAsync(int doctorId, string date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CancelAppointment", ReplyAction="http://tempuri.org/IService1/CancelAppointmentResponse")]
        int CancelAppointment(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CancelAppointment", ReplyAction="http://tempuri.org/IService1/CancelAppointmentResponse")]
        System.Threading.Tasks.Task<int> CancelAppointmentAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePatient", ReplyAction="http://tempuri.org/IService1/CreatePatientResponse")]
        int CreatePatient(System.Guid uuid, string email, string phoneNum, string firstName, string lastName, System.DateTime dateOfBirth, string gender, string password, string nric);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CreatePatient", ReplyAction="http://tempuri.org/IService1/CreatePatientResponse")]
        System.Threading.Tasks.Task<int> CreatePatientAsync(System.Guid uuid, string email, string phoneNum, string firstName, string lastName, System.DateTime dateOfBirth, string gender, string password, string nric);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPatientByEmail", ReplyAction="http://tempuri.org/IService1/getPatientByEmailResponse")]
        heDenoDB.Entity.Patient getPatientByEmail(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getPatientByEmail", ReplyAction="http://tempuri.org/IService1/getPatientByEmailResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Patient> getPatientByEmailAsync(string email, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getById", ReplyAction="http://tempuri.org/IService1/getByIdResponse")]
        heDenoDB.Entity.Patient getById(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getById", ReplyAction="http://tempuri.org/IService1/getByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Patient> getByIdAsync(string id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updateEmail", ReplyAction="http://tempuri.org/IService1/updateEmailResponse")]
        int updateEmail(string secretId, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updateEmail", ReplyAction="http://tempuri.org/IService1/updateEmailResponse")]
        System.Threading.Tasks.Task<int> updateEmailAsync(string secretId, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updatePhoneNum", ReplyAction="http://tempuri.org/IService1/updatePhoneNumResponse")]
        int updatePhoneNum(string secretId, string phoneNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/updatePhoneNum", ReplyAction="http://tempuri.org/IService1/updatePhoneNumResponse")]
        System.Threading.Tasks.Task<int> updatePhoneNumAsync(string secretId, string phoneNum);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verifyEmail", ReplyAction="http://tempuri.org/IService1/verifyEmailResponse")]
        int verifyEmail(string secretId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/verifyEmail", ReplyAction="http://tempuri.org/IService1/verifyEmailResponse")]
        System.Threading.Tasks.Task<int> verifyEmailAsync(string secretId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isEmailVerified", ReplyAction="http://tempuri.org/IService1/isEmailVerifiedResponse")]
        bool isEmailVerified(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/isEmailVerified", ReplyAction="http://tempuri.org/IService1/isEmailVerifiedResponse")]
        System.Threading.Tasks.Task<bool> isEmailVerifiedAsync(string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMCById", ReplyAction="http://tempuri.org/IService1/SelectMCByIdResponse")]
        heDenoDB.Entity.MedicalCertificate[] SelectMCById(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMCById", ReplyAction="http://tempuri.org/IService1/SelectMCByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalCertificate[]> SelectMCByIdAsync(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMCById", ReplyAction="http://tempuri.org/IService1/SelectOneMCByIdResponse")]
        heDenoDB.Entity.MedicalCertificate SelectOneMCById(string givenMCId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMCById", ReplyAction="http://tempuri.org/IService1/SelectOneMCByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalCertificate> SelectOneMCByIdAsync(string givenMCId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMIById", ReplyAction="http://tempuri.org/IService1/SelectMIByIdResponse")]
        heDenoDB.Entity.MedicalInstruct[] SelectMIById(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMIById", ReplyAction="http://tempuri.org/IService1/SelectMIByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalInstruct[]> SelectMIByIdAsync(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMIById", ReplyAction="http://tempuri.org/IService1/SelectOneMIByIdResponse")]
        heDenoDB.Entity.MedicalInstruct SelectOneMIById(string givenMIId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMIById", ReplyAction="http://tempuri.org/IService1/SelectOneMIByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalInstruct> SelectOneMIByIdAsync(string givenMIId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectDoctorByID", ReplyAction="http://tempuri.org/IService1/SelectDoctorByIDResponse")]
        heDenoDB.Entity.Doctor SelectDoctorByID(string givenDoctorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectDoctorByID", ReplyAction="http://tempuri.org/IService1/SelectDoctorByIDResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Doctor> SelectDoctorByIDAsync(string givenDoctorID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectClinicByID", ReplyAction="http://tempuri.org/IService1/SelectClinicByIDResponse")]
        heDenoDB.Entity.Clinic SelectClinicByID(string clinic_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectClinicByID", ReplyAction="http://tempuri.org/IService1/SelectClinicByIDResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Clinic> SelectClinicByIDAsync(string clinic_id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMRById", ReplyAction="http://tempuri.org/IService1/SelectMRByIdResponse")]
        heDenoDB.Entity.MedicalRecord[] SelectMRById(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectMRById", ReplyAction="http://tempuri.org/IService1/SelectMRByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalRecord[]> SelectMRByIdAsync(string givenPatientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMRById", ReplyAction="http://tempuri.org/IService1/SelectOneMRByIdResponse")]
        heDenoDB.Entity.MedicalRecord SelectOneMRById(string givenMRId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectOneMRById", ReplyAction="http://tempuri.org/IService1/SelectOneMRByIdResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.MedicalRecord> SelectOneMRByIdAsync(string givenMRId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectPatientByID", ReplyAction="http://tempuri.org/IService1/SelectPatientByIDResponse")]
        heDenoDB.Entity.Patient SelectPatientByID(string givenPatientID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SelectPatientByID", ReplyAction="http://tempuri.org/IService1/SelectPatientByIDResponse")]
        System.Threading.Tasks.Task<heDenoDB.Entity.Patient> SelectPatientByIDAsync(string givenPatientID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : heDeno.MyDenoDBServiceReference.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<heDeno.MyDenoDBServiceReference.IService1>, heDeno.MyDenoDBServiceReference.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public heDenoDB.CompositeType GetDataUsingDataContract(heDenoDB.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.CompositeType> GetDataUsingDataContractAsync(heDenoDB.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public heDenoDB.Entity.Appointment[] GetAppointmentsByPatientId(int id) {
            return base.Channel.GetAppointmentsByPatientId(id);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Appointment[]> GetAppointmentsByPatientIdAsync(int id) {
            return base.Channel.GetAppointmentsByPatientIdAsync(id);
        }
        
        public int CreateAppointment(string date, System.TimeSpan time, int doctorId, int patientId) {
            return base.Channel.CreateAppointment(date, time, doctorId, patientId);
        }
        
        public System.Threading.Tasks.Task<int> CreateAppointmentAsync(string date, System.TimeSpan time, int doctorId, int patientId) {
            return base.Channel.CreateAppointmentAsync(date, time, doctorId, patientId);
        }
        
        public int UpdateAppointment(int id, string date, System.TimeSpan time, int doctorId, int patientId) {
            return base.Channel.UpdateAppointment(id, date, time, doctorId, patientId);
        }
        
        public System.Threading.Tasks.Task<int> UpdateAppointmentAsync(int id, string date, System.TimeSpan time, int doctorId, int patientId) {
            return base.Channel.UpdateAppointmentAsync(id, date, time, doctorId, patientId);
        }
        
        public heDenoDB.Entity.Appointment GetOneAppointment(int id) {
            return base.Channel.GetOneAppointment(id);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Appointment> GetOneAppointmentAsync(int id) {
            return base.Channel.GetOneAppointmentAsync(id);
        }
        
        public heDenoDB.Entity.Specialty[] GetAllSpecialty() {
            return base.Channel.GetAllSpecialty();
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Specialty[]> GetAllSpecialtyAsync() {
            return base.Channel.GetAllSpecialtyAsync();
        }
        
        public heDenoDB.Entity.Clinic[] GetClinicBySpecialty(string specialty) {
            return base.Channel.GetClinicBySpecialty(specialty);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Clinic[]> GetClinicBySpecialtyAsync(string specialty) {
            return base.Channel.GetClinicBySpecialtyAsync(specialty);
        }
        
        public heDenoDB.Entity.Clinic GetOneClinic(string clinic_name) {
            return base.Channel.GetOneClinic(clinic_name);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Clinic> GetOneClinicAsync(string clinic_name) {
            return base.Channel.GetOneClinicAsync(clinic_name);
        }
        
        public heDenoDB.Entity.Doctor[] GetDoctorByClinic(string clinic_id) {
            return base.Channel.GetDoctorByClinic(clinic_id);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Doctor[]> GetDoctorByClinicAsync(string clinic_id) {
            return base.Channel.GetDoctorByClinicAsync(clinic_id);
        }
        
        public heDenoDB.Entity.Appointment[] GetAllAppointmentsByDoctorAndDate(int doctorId, string date) {
            return base.Channel.GetAllAppointmentsByDoctorAndDate(doctorId, date);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Appointment[]> GetAllAppointmentsByDoctorAndDateAsync(int doctorId, string date) {
            return base.Channel.GetAllAppointmentsByDoctorAndDateAsync(doctorId, date);
        }
        
        public int CancelAppointment(int id) {
            return base.Channel.CancelAppointment(id);
        }
        
        public System.Threading.Tasks.Task<int> CancelAppointmentAsync(int id) {
            return base.Channel.CancelAppointmentAsync(id);
        }
        
        public int CreatePatient(System.Guid uuid, string email, string phoneNum, string firstName, string lastName, System.DateTime dateOfBirth, string gender, string password, string nric) {
            return base.Channel.CreatePatient(uuid, email, phoneNum, firstName, lastName, dateOfBirth, gender, password, nric);
        }
        
        public System.Threading.Tasks.Task<int> CreatePatientAsync(System.Guid uuid, string email, string phoneNum, string firstName, string lastName, System.DateTime dateOfBirth, string gender, string password, string nric) {
            return base.Channel.CreatePatientAsync(uuid, email, phoneNum, firstName, lastName, dateOfBirth, gender, password, nric);
        }
        
        public heDenoDB.Entity.Patient getPatientByEmail(string email, string password) {
            return base.Channel.getPatientByEmail(email, password);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Patient> getPatientByEmailAsync(string email, string password) {
            return base.Channel.getPatientByEmailAsync(email, password);
        }
        
        public heDenoDB.Entity.Patient getById(string id) {
            return base.Channel.getById(id);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Patient> getByIdAsync(string id) {
            return base.Channel.getByIdAsync(id);
        }
        
        public int updateEmail(string secretId, string email) {
            return base.Channel.updateEmail(secretId, email);
        }
        
        public System.Threading.Tasks.Task<int> updateEmailAsync(string secretId, string email) {
            return base.Channel.updateEmailAsync(secretId, email);
        }
        
        public int updatePhoneNum(string secretId, string phoneNum) {
            return base.Channel.updatePhoneNum(secretId, phoneNum);
        }
        
        public System.Threading.Tasks.Task<int> updatePhoneNumAsync(string secretId, string phoneNum) {
            return base.Channel.updatePhoneNumAsync(secretId, phoneNum);
        }
        
        public int verifyEmail(string secretId) {
            return base.Channel.verifyEmail(secretId);
        }
        
        public System.Threading.Tasks.Task<int> verifyEmailAsync(string secretId) {
            return base.Channel.verifyEmailAsync(secretId);
        }
        
        public bool isEmailVerified(string email) {
            return base.Channel.isEmailVerified(email);
        }
        
        public System.Threading.Tasks.Task<bool> isEmailVerifiedAsync(string email) {
            return base.Channel.isEmailVerifiedAsync(email);
        }
        
        public heDenoDB.Entity.MedicalCertificate[] SelectMCById(string givenPatientId) {
            return base.Channel.SelectMCById(givenPatientId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalCertificate[]> SelectMCByIdAsync(string givenPatientId) {
            return base.Channel.SelectMCByIdAsync(givenPatientId);
        }
        
        public heDenoDB.Entity.MedicalCertificate SelectOneMCById(string givenMCId) {
            return base.Channel.SelectOneMCById(givenMCId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalCertificate> SelectOneMCByIdAsync(string givenMCId) {
            return base.Channel.SelectOneMCByIdAsync(givenMCId);
        }
        
        public heDenoDB.Entity.MedicalInstruct[] SelectMIById(string givenPatientId) {
            return base.Channel.SelectMIById(givenPatientId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalInstruct[]> SelectMIByIdAsync(string givenPatientId) {
            return base.Channel.SelectMIByIdAsync(givenPatientId);
        }
        
        public heDenoDB.Entity.MedicalInstruct SelectOneMIById(string givenMIId) {
            return base.Channel.SelectOneMIById(givenMIId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalInstruct> SelectOneMIByIdAsync(string givenMIId) {
            return base.Channel.SelectOneMIByIdAsync(givenMIId);
        }
        
        public heDenoDB.Entity.Doctor SelectDoctorByID(string givenDoctorID) {
            return base.Channel.SelectDoctorByID(givenDoctorID);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Doctor> SelectDoctorByIDAsync(string givenDoctorID) {
            return base.Channel.SelectDoctorByIDAsync(givenDoctorID);
        }
        
        public heDenoDB.Entity.Clinic SelectClinicByID(string clinic_id) {
            return base.Channel.SelectClinicByID(clinic_id);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Clinic> SelectClinicByIDAsync(string clinic_id) {
            return base.Channel.SelectClinicByIDAsync(clinic_id);
        }
        
        public heDenoDB.Entity.MedicalRecord[] SelectMRById(string givenPatientId) {
            return base.Channel.SelectMRById(givenPatientId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalRecord[]> SelectMRByIdAsync(string givenPatientId) {
            return base.Channel.SelectMRByIdAsync(givenPatientId);
        }
        
        public heDenoDB.Entity.MedicalRecord SelectOneMRById(string givenMRId) {
            return base.Channel.SelectOneMRById(givenMRId);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.MedicalRecord> SelectOneMRByIdAsync(string givenMRId) {
            return base.Channel.SelectOneMRByIdAsync(givenMRId);
        }
        
        public heDenoDB.Entity.Patient SelectPatientByID(string givenPatientID) {
            return base.Channel.SelectPatientByID(givenPatientID);
        }
        
        public System.Threading.Tasks.Task<heDenoDB.Entity.Patient> SelectPatientByIDAsync(string givenPatientID) {
            return base.Channel.SelectPatientByIDAsync(givenPatientID);
        }
    }
}
