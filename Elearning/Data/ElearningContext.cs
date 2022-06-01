using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Elearning.Models;

namespace Elearning.Data
{
    public class ElearningContext : DbContext
    {
        public ElearningContext (DbContextOptions<ElearningContext> options)
            : base(options)
        {
        }

        public DbSet<Elearning.Models.Myclass>? Myclass { get; set; }

        public DbSet<Elearning.Models.Student>? Student { get; set; }

        public DbSet<Elearning.Models.Subject>? Subject { get; set; }

        public DbSet<Elearning.Models.Format>? Format { get; set; }

        public DbSet<Elearning.Models.Teacher>? Teacher { get; set; }

        public DbSet<Elearning.Models.Test>? Test { get; set; }

        public DbSet<Elearning.Models.TakeClass>? TakeClass { get; set; }
    }
}
