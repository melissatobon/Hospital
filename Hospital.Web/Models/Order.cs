using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hospital.Web.Models
{
    public class Order
    {
       
        public int Id { get; set; }
        public string Date { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Time { get; set; }
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        [Required]
        public string Process { get; set; }   
        
        public int Estatus { get; set; }

        [JsonIgnore]  //lo ignora en la respuesta json
        [NotMapped]   //no se crea en la base de datos
        public int IdPatient { get; set; }

    }
}
