using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Elearning.Models
{
    public class Test
    {
        [Key]
        public int TestId { get; set; }
        public string Topic { get; set; }
        public string Workingtime { get; set; }
        public string Classify { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Description { get; set; }
        public string AttachTeacher { get; set; }
        public string AttachStudent { get; set; }
        public string Comment { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
        [ForeignKey("StudentId")]
        public Student Student { get; set; }
        [ForeignKey("FormatId")]
        public Format Format { get; set; }

    }
}
