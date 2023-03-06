using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAtttendenceMS.Model
{
    public class TblStudent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string StudentName { get; set;}

        [Required(ErrorMessage = "Roll Number is required")]
        public int RollNumber { get; set;}

        [Required(ErrorMessage = "Please select the course")]
        public string  Course { get; set;}

        [Required(ErrorMessage = "Please select the semester")]
        public string Semester { get; set;}

        [Required(ErrorMessage = "Please select the branch")]
        public string Branch { get; set;}   


    }
}
