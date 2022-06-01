using System.ComponentModel.DataAnnotations;

namespace Elearning.Models
{
    public class Myclass
    {
            [Key]
            public int MyclassId { get; set; }
            public string Name { get; set; }
    }
}
