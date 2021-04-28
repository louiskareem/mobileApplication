using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestfulAPI.Models;

namespace RestfulAPI.Database
{
    public class AlarmContext : DbContext
    {
        public AlarmContext(DbContextOptions<AlarmContext> options) : base(options)
        {
        }

        public DbSet<Alarm> Alarms
        {
            get;
            set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alarm>()
                        .HasMany(x => x.Recipients);
                        //.WithMany(x => x.Alarms);
        }
    }
}
