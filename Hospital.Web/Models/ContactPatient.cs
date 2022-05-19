using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class ContactPatient
    {
        [Key]
        public int Id { get; set; }
        public string ContactName { get; set; }
        public int ContactPhone { get; set; }

        public ICollection<Patient> Patients { get; set; }//Llave foranea
    }
}
