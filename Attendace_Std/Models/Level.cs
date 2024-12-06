using System.ComponentModel.DataAnnotations;

namespace Attendace_Std.Models
{
    public class Level
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name of Level Plz : ")]
        public string Name { get; set; }
    }
}
