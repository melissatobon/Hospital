using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        public int Document { get; set; }       
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }
        
        public int Age { get; set; }
        public string Diagnosis { get; set; }
        public string Entity { get; set; }
        public string DateBirth { get; set; }
        public string Record { get; set; }
        

        public ICollection<LaboratoryExam> LaboratoryExams { get; set; }
        public ICollection<MedicalNote> MedicalNotes { get; set; }
        public ICollection<NurseNote> NurseNotes { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<VitalSign> VitalSigns { get; set; }







    }
}
