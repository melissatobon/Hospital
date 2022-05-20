using Hospital.Web.Data.Entities;
using Hospital.Web.Enums;
using Hospital.Web.Helpers;
using Hospital.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Web.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(ApplicationDbContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckPatientsAsync();
            await CheckRolesAsync();
            await CheckUserAsync("1214742406", "Melissa", "Restrepo", "mrestrepo@hotmail.com", "3000000000", "Bello", UserType.Admin);

        }
        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
           
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    Employee = _context.Employees.FirstOrDefault(),
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "1214742406"); //password debe tener una longitud de 6 caracteres
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }


        private async Task CheckPatientsAsync()
        {
            if (!_context.Patients.Any())
            {
                _context.Patients.Add(new Patient{
                    Document = 123456,
                    Name = "Alejandro",
                    Age = 22,
                    Diagnosis = "Gastroentiritis aguda",
                    Entity = "Sura",
                    DateBirth = "27-04-1998",
                    Record = "AQ: OS de humero derecho",
                    MedicalNotes = new List<MedicalNote> {
                            new MedicalNote { Date = "19-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },
                            new MedicalNote { Date = "18-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },

                        },
                    NurseNotes = new List<NurseNote> {
                            new NurseNote { Date = "19-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },

                            new NurseNote { Date = "18-05-2022",
                            Time = "23:00",
                            Note = "Paciente en malas condiciones" },
                    },
                    VitalSigns = new List<VitalSign> {
                    new VitalSign {
                        Date = "19-05-2022",
                        Time = "05:00",
                        Temperature = 38,
                        Fc = 70,
                        Pas = 120,
                        Pad = 70,
                        Fr = 12,
                        Spo2 = 96,
                        Glucometry = 97
                        },

                     new VitalSign{
                        Date = "18-05-2022",
                        Time = "23:00",
                        Temperature = 38,
                        Fc = 70,
                        Pas = 120,
                        Pad = 70,
                        Fr = 12,
                        Spo2 = 96,
                        Glucometry = 97
                        }
                    }

                
                });
                _context.Patients.Add(new Patient
                {
                    Document = 14343456,
                    Name = "Kevin",
                    Age = 32,
                    Diagnosis = "Sepsis",
                    Entity = "Sura",
                    DateBirth = "27-06-1928",
                    Record = "AQ: OS de humero derecho, AA: Alergia a voncomicina",
                    MedicalNotes = new List<MedicalNote> {
                            new MedicalNote { Date = "19-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },
                            new MedicalNote { Date = "18-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },

                        },
                    NurseNotes = new List<NurseNote> {
                            new NurseNote { Date = "19-05-2022",
                            Time = "07:00",
                            Note = "Paciente en malas condiciones" },

                            new NurseNote { Date = "18-05-2022",
                            Time = "23:00",
                            Note = "Paciente en malas condiciones" },
                    },
                    VitalSigns = new List<VitalSign> {
                    new VitalSign {
                        Date = "19-05-2022",
                        Time = "05:00",
                        Temperature = 38,
                        Fc = 70,
                        Pas = 120,
                        Pad = 70,
                        Fr = 12,
                        Spo2 = 96,
                        Glucometry = 97
                        },

                     new VitalSign{
                        Date = "18-05-2022",
                        Time = "23:00",
                        Temperature = 38,
                        Fc = 70,
                        Pas = 120,
                        Pad = 70,
                        Fr = 12,
                        Spo2 = 96,
                        Glucometry = 97
                        }
                    }


                });
                await _context.SaveChangesAsync();
            }


        }
    }



}
