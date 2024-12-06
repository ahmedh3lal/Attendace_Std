using System.ComponentModel.DataAnnotations;

namespace Attendace_Std.Models
{
    public class Specialization
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name of specialization Plz : ")]
        public string Name { get; set; }
    }
}
