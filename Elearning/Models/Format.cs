using System.ComponentModel.DataAnnotations;

namespace Elearning.Models
{
    public class Format
    {
        [Key]
        public int FormatId { get; set; }
        public string Name { get; set; }
    }
}
