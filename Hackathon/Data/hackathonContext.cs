using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hackathon.Models;

namespace Hackathon.Data
{
    public class hackathonContext : DbContext
    {
        public hackathonContext (DbContextOptions<hackathonContext> options)
            : base(options)
        {
        }

        public DbSet<Hackathon.Models.Question> Questions { get; set; }
        public DbSet<Hackathon.Models.Quiz> Quizzes { get; set; }
        public DbSet<Hackathon.Models.User> Users { get; set; }
        public DbSet<Hackathon.Models.Completed_Quiz> Completed_Quiz { get; set; }

    }
}
