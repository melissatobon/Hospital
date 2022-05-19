using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        public int Document { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public int Age { get; set; }
        public string Diagnosis { get; set; }
        public string Entity { get; set; }
        public string DateBirth { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

      


    }
}
