using Elearning.Data;
using Elearning.Models;

namespace Elearning.Services
{
    public class sqlFormat : IFormat
    {
        private ElearningContext _elearningContext;
        public sqlFormat(ElearningContext elearningContext)
        {
            _elearningContext = elearningContext;
        }
        public Format AddFormat(Format format)
        {
            _elearningContext.Format.Add(format);
            _elearningContext.SaveChanges();
            return format;
        }   

        public void DeteleFormat(Format format)
        {
            _elearningContext.Format.Remove(format);
            _elearningContext.SaveChanges();
        }

        public Format EditFormat(Format format)
        {
            var existingFormat = _elearningContext.Format.Find(format.FormatId);
            if (existingFormat != null)
            {
                _elearningContext.Format.Update(format);
                _elearningContext.SaveChanges();
            }
            return format;
        }

        public Format GetFormat(int id)
        {
           var format = _elearningContext.Format.Find(id);
            return format;
        }

        public List<Format> GetFormats()
        {
            return _elearningContext.Format.ToList();
        }
    }
}
