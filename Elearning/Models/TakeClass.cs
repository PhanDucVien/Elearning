using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Elearning.Models
{
    public class TakeClass
    {
        [Key]
        public int TakeClassId { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public DateTime Workingtime { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Security { get; set; }
        public string Link { get; set; }
        [ForeignKey("MyclassId")]
        public Myclass Myclass { get; set; }
        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
