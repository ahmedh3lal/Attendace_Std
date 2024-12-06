using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendace_Std.Models
{
    public class Std_factory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int stdId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Factory")]
        public int facId { get; set; }
        public Factory? Factory { get; set; }

    }
}
