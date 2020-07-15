using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Data
{
    public class hackathonContext : DbContext
    {
        public hackathonContext (DbContextOptions<hackathonContext> options)
            : base(options)
        {
        }

    }
}
