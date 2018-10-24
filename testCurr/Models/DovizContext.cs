using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testCurr.Models
{
    public class DovizContext : DbContext
    {
        public DovizContext(DbContextOptions<DovizContext> options) : base(options)
        { }
            public DbSet<DovizKuru> Doviz_Kuru { get; set; }

     }   
}

