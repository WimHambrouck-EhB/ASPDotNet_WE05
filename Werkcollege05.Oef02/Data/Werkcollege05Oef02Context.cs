using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Werkcollege05.Oef02.Models;

namespace Werkcollege05.Oef02.Data
{
    public class Werkcollege05Oef02Context : DbContext
    {
        public Werkcollege05Oef02Context (DbContextOptions<Werkcollege05Oef02Context> options)
            : base(options)
        {
        }

        public DbSet<Werkcollege05.Oef02.Models.Gebruiker> Gebruiker { get; set; }
    }
}
