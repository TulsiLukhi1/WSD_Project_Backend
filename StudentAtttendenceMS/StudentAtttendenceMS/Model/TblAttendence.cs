using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentAtttendenceMS.Model
{
    public class TblAttendence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(TblAttendence))]
        public int StudnetId { get; set; }

        public DateTime Date { get; set; }

        public bool isPresent { get; set; }
    }
}
