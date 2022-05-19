using System.Collections.Generic;

namespace Hospital.Web.Models
{
    public class AntecedentAllergic
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Patient> Patients { get; set; }//Llave foranea
    }
}
