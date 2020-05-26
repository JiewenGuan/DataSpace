using Microsoft.EntityFrameworkCore;
using DataSpace.Models;

namespace DataSpace.Data
{
    public class SpaceContext : DbContext
    {
        public SpaceContext(DbContextOptions<SpaceContext> options) : base(options)
        { }

        public DbSet<Experiment> Experiments { get; set; }
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Participation> Participations { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<ExpRole> ExpRoles { get; set; }
        public DbSet<ResultDataset> ResultDatasets { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Experiment>().HasOne(e => e.LeadIstitution).WithMany(i => i.Experiments).HasForeignKey(e => e.LeadInstitutionID);
            builder.Entity<Experiment>().HasMany(e => e.Datasets).WithOne(d => d.Experiment).HasForeignKey(d => d.ExperimentID);
            builder.Entity<Platform>().HasMany(p => p.Missions).WithOne(m => m.Platform).HasForeignKey(m => m.PlatformID);
            builder.Entity<Mission>().HasMany(m => m.Experiments).WithOne(e => e.Mission).HasForeignKey(e => e.MissionID);
            builder.Entity<Institution>().HasMany(e => e.People).WithOne(e => e.Institution).HasForeignKey(e => e.InstitutionID);
            builder.Entity<Participation>().HasOne(e => e.Participant).WithMany(p => p.Participates).HasForeignKey(e => e.PersonID);
            builder.Entity<Participation>().HasOne(e => e.Role).WithMany(r => r.Participants).HasForeignKey(e => e.RoleID);
            builder.Entity<Participation>().HasOne(p => p.Experiment).WithMany(e => e.Participants).HasForeignKey(p => p.ExperimentID);
            builder.Entity<Person>().HasOne<Login>(l => l.Login).WithOne(l => l.Person).HasForeignKey<Login>(l => l.PersonID);

            builder.Entity<Experiment>().HasOne(e => e.Author).WithMany(a => a.Experimentssubmit).HasForeignKey(e => e.AuthorId);


        }
    }
}
