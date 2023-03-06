using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAtttendenceMS.Model
{
    public class TblFaculty
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FacultyID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; }

        
        public string Qualification { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        [MinLength(3, ErrorMessage = "Minimum 3 Character required"), MaxLength(10, ErrorMessage = "Maximum 10 Character Allowed")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Minimum 5 Character required"), MaxLength(10, ErrorMessage = "Maximum 10 Character Allowed")]
        public string Password { get; set; } 
    }
}
