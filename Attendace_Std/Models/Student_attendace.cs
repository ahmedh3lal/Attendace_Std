using System.ComponentModel.DataAnnotations.Schema;

namespace Attendace_Std.Models
{
    public class Student_attendace
    {
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public Student? Student { get; set; }
        [ForeignKey("Factory")]
        public int fac_id { get; set; }
        public Factory ? Factory { get; set; }
        [ForeignKey("Supervisor")]
        public int Supervisor_id { get; set; } 
        public Supervisor ? Supervisor {  get; set; }
        public string Location { get; set; }
        public DateTime DateOnly { get; set; } = new DateTime();
    }
}
/*
 * factoryname
 * subervisor
 * location 
 * data

 * */