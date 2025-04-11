using System.Net.WebSockets;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Hospital Management System");
                Console.WriteLine("1. Yeni xeste elave et");
                Console.WriteLine("2. Yeni hekim elave et");
                Console.WriteLine("3. Hekime xeste teyin et");
                Console.WriteLine("4. Xestelerin siyahisi");
                Console.WriteLine("5. Hekimlerin siyahisi");
                Console.WriteLine("6. statistikaya bax");
                Console.WriteLine("7. Exit");
            
                Console.Write("Please select an option: ");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine($"Xestenin adini elave et");
                            var name = Console.ReadLine();
                            Console.WriteLine($"Xestenin soyadini elave et");
                            var surname = Console.ReadLine();
                            Console.WriteLine($"Xestenin yasini elave et");
                            var age = int.Parse(Console.ReadLine());
                            Patient patient = new Patient()
                            {
                                Name = name,
                                Surname = surname,  `
                                Age = age
                            };
                            DBContext.AddNewPatient(patient);
                        }
                        break;
                    case "2":
                        {
                            Console.WriteLine($"Hekimin adini elave et :");
                            var name = Console.ReadLine();
                            Console.WriteLine($"Hekimin soyadini elave et :");
                            var surname = Console.ReadLine();
                            Console.WriteLine($"Hekimin yasini elave et :");
                            var age = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Hekimin genderi : 1. kisi   2, qadin");
                            var genderChoice = int.Parse(Console.ReadLine());
                            Gender gender;
                        gender:
                            if (genderChoice == 1)
                            {
                                gender = Gender.Male;
                            }
                            else if (genderChoice == 2)
                            {
                                gender = Gender.Female;
                            }
                            else
                            {
                                Console.WriteLine("2 gender var Agilli ol!!!");
                                goto gender;
                            }
                            Doctor doctor = new Doctor()
                            {
                                Name = name,
                                Surname = surname,
                                Age = age,
                                GenderEnum = gender,
                              
                            };

                            DBContext.AddNewDoctor(doctor);
                        }
                        break;
                    case "3":
                        {
                            Console.WriteLine("Hekimin id sini qeyd edin:");
                            var docID = int.Parse(Console.ReadLine());
                            Console.WriteLine("Xestenin id sini qeyd edin:");
                            var patID = int.Parse(Console.ReadLine());
                            Appointment appointment = new Appointment()
                            {
                                DoctorId = docID,
                                PatientId = patID,
                                Date = DateTime.Now
                            };
                            DBContext.AddNewAppointment(appointment);
                        }
                        break;
                    case "4":
                        {
                            Console.WriteLine("Patient List:");
                            foreach (var patient in DBContext.GetAllPatient())
                            {
                                patient.DisplayInfo();
                            }

                        }
                       
                        break;
                    case "5":
                        {
                            Console.WriteLine("Doctor List:");
                            foreach (var doctor in DBContext.GetAllDoctor())
                            {
                                doctor.DisplayInfo();
                            }
                        }
                        break;
                    case "6":
                        {
                            Console.WriteLine($"Total patients count: {HospitalStats.TotalPatientCount}");
                            Console.WriteLine($"Total doctors count: {HospitalStats.TotalDoctorCount}");
                            Console.WriteLine($"Total appointments count: {HospitalStats.TotalAppointmentCount}");
                        }
                        break;
                    case "7":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            






        }
    }
}
