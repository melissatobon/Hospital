using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class LaboratoryExam
    {
        [Key]
        public int Id { get; set; }
        public int Date { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public int Time { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Outcome { get; set; }

        public ICollection<Patient> Patients { get; set; }//Llave foranea
    }
}
