using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendace_Std.Models
{
    public class std_supervisor
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int stdId { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("supervisor")]
        public int suberId { get; set; }
        public Supervisor? supervisor { get; set; }
    }
}
