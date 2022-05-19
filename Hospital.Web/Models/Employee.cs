using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public int Document { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public int Age { get; set; }        
        public string DateBirth { get; set; }

        [DisplayName("Is Nurse")]
        public bool Nurse { get; set; }

        [DisplayName("Is Medical")]
        public bool Medical { get; set; }

    }
}
