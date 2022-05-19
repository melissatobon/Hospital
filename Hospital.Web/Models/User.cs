using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Web.Models
{
    public class User
    {
        
        [Key]
        public int Id{ get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<Employee> Employees { get; set; }//Llave foranea
    }
}
