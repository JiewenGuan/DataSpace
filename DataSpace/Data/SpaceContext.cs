using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataSpace.Models;

namespace DataSpace.Data
{
    public class SpaceContext : DbContext
    {
        public SpaceContext(DbContextOptions<SpaceContext> options) : base(options) { }
        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ResultDataset> ResultDatasets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Experiment>().HasOne(e => e.LeadIstitution).WithMany(i => i.Experiments);
            builder.Entity<Experiment>().HasMany(e => e.Datasets).WithOne(d => d.Experiment);
            builder.Entity<Platform>().HasMany(p => p.Missions).WithOne(m => m.Platform);
            builder.Entity<Mission>().HasMany(m => m.Experiments).WithOne(e => e.Mission);
            builder.Entity<Institution>().HasMany(e => e.People).WithOne(e => e.Institution);
            builder.Entity<Participation>().HasOne(e => e.Participant).WithMany(p => p.Participates).HasForeignKey(e => e.PersonID);
            builder.Entity<Participation>().HasOne(e => e.Role).WithMany(r => r.Participants).HasForeignKey(e => e.RoleID);
            builder.Entity<Participation>().HasOne(p => p.Experiment).WithMany(e => e.Participants).HasForeignKey(p => p.ExperimentID);




        }
    }
}
