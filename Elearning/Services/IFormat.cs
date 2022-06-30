using Elearning.Models;

namespace Elearning.Services
{
    public interface IFormat
    {
        List<Format> GetFormats();
        Format GetFormat(int id);
        Format AddFormat(Format format);
        void DeteleFormat(Format format);
        Format EditFormat(Format format);


    }
}
