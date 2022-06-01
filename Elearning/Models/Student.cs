using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Elearning.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; } 
        public string username { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string Gmail { get; set; }
        public string Gender { get; set; }
        public DateTime Dateofbirth { get; set; }
        public DateTime Schoolyear { get; set; }
        [ForeignKey("MyclassId")]
        public Myclass Myclass { get; set; }
    }
}
