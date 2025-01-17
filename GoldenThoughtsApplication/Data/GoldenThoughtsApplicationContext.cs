using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoldenThoughtsApplication.Models;

namespace GoldenThoughtsApplication.Data
{
    public class GoldenThoughtsApplicationContext : DbContext
    {
        public GoldenThoughtsApplicationContext (DbContextOptions<GoldenThoughtsApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<GoldenThoughtsApplication.Models.Thought> Thought { get; set; } = default!;
    }
}
