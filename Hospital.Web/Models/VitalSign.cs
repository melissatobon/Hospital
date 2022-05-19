using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class VitalSign
    {
        [Key]
        public int Id { get; set; }
        public int Date { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public int Time{ get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public float Temperature { get; set; }
        public int Fc { get; set; }
        public int Pas { get; set; }
        public int Pad { get; set; }
        public int Fr { get; set; }
        public int Spo2 { get; set; }
        public int Glucometry { get; set; }

        public ICollection<Patient> Patients { get; set; }//Llave foranea
    }
}
