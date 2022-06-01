using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elearning.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Name { get; set; }
        [ForeignKey("SubjectId")]
        public Subject Subject { get; set;}
        
    }
}
