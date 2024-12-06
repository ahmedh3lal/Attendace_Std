using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Attendace_Std.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Your Full Name Plz : ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address format")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*?&]{6,}$",
        ErrorMessage = "Password must contain at least one letter, one number, and be at least 6 characters long")]

        public string Password { get; set; }
        public string Repassword { get; set; }

        [Required(ErrorMessage = "Enter Your Level Plz : ")]
        [ForeignKey("level")]
        public int Level_id { get; set; }
        public Level? level { get; set; }
        [Required(ErrorMessage = "Enter Your Specialization Plz : ")]
        [ForeignKey("specialization")]
        public int Specialization_id { get; set; }
       
        public Specialization? specialization { get; set; }

        //register
        /*
         * name 
         * email 
         * pas 
         * repass
         * level 
         * spacial
         * */
        //login 
        /*
         * email
         * pass
         * 
         */
        /*//
         * form data
         * factoryname
         * subervisor
         * location 
         * data
         * */
    }
}
