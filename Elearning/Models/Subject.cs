using System.ComponentModel.DataAnnotations;

namespace Elearning.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; } 
        public string Name { get; set; }    
        public string Nest { get; set; }
    }
}
