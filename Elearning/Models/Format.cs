using Elearning.Services;
using System.ComponentModel.DataAnnotations;

namespace Elearning.Models
{
    public interface Format : IFormat
    {
        [Key]
        public int FormatId { get; set; }
        public string Name { get; set; }
    }
}
