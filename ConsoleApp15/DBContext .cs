using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15;

static class DBContext
{
    static int _uidCounter = 0;
    static Patient[] patients = new Patient[0];
    static Doctor[] doctors = new Doctor[0];
    static Appointment[] appointments = new Appointment[0];

    public static void AddNewPatient(Patient patient)
    {
        Array.Resize(ref patients, patients.Length + 1);
        patients[patients.Length - 1] = patient;
        patient.Id = ++_uidCounter;
        HospitalStats.TotalPatientCount++;

    }
    public static void AddNewDoctor(Doctor doctor)
    {
        Array.Resize(ref doctors, doctors.Length + 1);
        doctors[doctors.Length - 1] = doctor;
        doctor.Id = ++_uidCounter;
        HospitalStats.TotalDoctorCount++;
    }
    public static void AddNewAppointment(Appointment appointment)
    {
        Array.Resize(ref appointments, appointments.Length + 1);
        appointments[appointments.Length - 1] = appointment;
        HospitalStats.TotalAppointmentCount++;
    }
    public static Patient[] GetAllPatient()
    {
        return patients;
    }
    public static Doctor[] GetAllDoctor()
    {
        return doctors;
    }
    public static Appointment[] GetAllAppointment()
    {
        return appointments;
    }


}
