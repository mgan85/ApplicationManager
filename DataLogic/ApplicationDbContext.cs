using DataLogic.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLogic;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Phone> Phones => Set<Phone>();
    public DbSet<JobType> JobTypes => Set<JobType>();
    public DbSet<SkillLevel> SkillLevels => Set<SkillLevel>();
    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<Handler> Handlers => Set<Handler>();
    public DbSet<JobOffer> JobOffers => Set<JobOffer>();
    public DbSet<JobOfferRequiredSkill> JobOfferRequiredSkills => Set<JobOfferRequiredSkill>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<ApplicationStatus> ApplicationStatuses => Set<ApplicationStatus>();
    public DbSet<Application> Applications => Set<Application>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}