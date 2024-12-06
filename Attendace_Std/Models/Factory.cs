using System.ComponentModel.DataAnnotations;

namespace Attendace_Std.Models
{
    public class Factory
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Factory plz ")]
        public string Name { get; set; }
    }
}
