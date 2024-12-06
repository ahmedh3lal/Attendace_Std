using System.ComponentModel.DataAnnotations;

namespace Attendace_Std.Models
{
    public class Supervisor
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Supervisor plz ")]
        public string Name { get; set; }
    }
}
