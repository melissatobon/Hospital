using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hospital.Web.Models
{
    public class Patient
    {
        
        public int Id { get; set; }

        public string Document { get; set; }

        public string Name { get; set; }
        
        public int Age { get; set; }
        public string Diagnosis { get; set; }
        public string Entity { get; set; }
        public string DateBirth { get; set; }
        public string Record { get; set; }
        

        
        public ICollection<MedicalNote> MedicalNotes { get; set; }
       
       
        public ICollection<VitalSign> VitalSigns { get; set; }

       
    }
}
