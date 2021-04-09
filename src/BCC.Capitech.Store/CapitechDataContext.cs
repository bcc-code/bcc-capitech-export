using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using BCC.Capitech.Model;
using System;

namespace BCC.Capitech.Store
{
    public class CapitechDataContext : DbContext
    {
        public CapitechDataContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected CapitechDataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Absence>().HasKey(a => new { a.ClientId, a.AbsenceId });
            model.Entity<Client>().HasKey(a => new { a.ClientId });
            model.Entity<Competence>().HasKey(a => new { a.ClientId, a.CompetenceId });
            model.Entity<Department>().HasKey(a => new { a.ClientId, a.DepartmentId });
            model.Entity<DutyDefinition>().HasKey(a => new { a.ClientId, a.DutyDefinitionId });
            model.Entity<Employee>().HasKey(a => new { a.ClientId, a.EmployeeId });
            model.Entity<FreeDimension1>().HasKey(a => new { a.ClientId, a.FreeDimension1Id, a.UniqueId });
            model.Entity<FreeDimension2>().HasKey(a => new { a.ClientId, a.FreeDimension2Id, a.UniqueId });
            model.Entity<OperationalPlan>().HasKey(a => new { a.ClientId, a.Id });
            model.Entity<Order>().HasKey(a => new { a.ClientId, a.OrderId });
            model.Entity<Phase>().HasKey(a => new { a.ClientId, a.PhaseId, a.UniqueId });
            model.Entity<Project>().HasKey(a => new { a.ClientId, a.ProjectId, a.UniqueId });
            model.Entity<SubProject>().HasKey(a => new { a.ClientId, a.SubProjectId, a.UniqueId });
            model.Entity<TaskInfo>().HasKey(a => new { a.ClientId, a.TaskId });
            model.Entity<TimeTransaction>().HasKey(a => new { a.ClientId, a.Uid, a.TimeCategoryId });
            model.Entity<DutyType>().HasKey(a => new { a.ClientId, a.DutyTypeId });
            model.Entity<AbsenceTransaction>().HasKey(a => new { a.ClientId, a.AbsenceId, a.DayDate });

            base.OnModelCreating(model);
        }

        public DbSet<Absence> Absences { get; set; }
        public DbSet<AbsenceTransaction> AbsenceTransactions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<DutyDefinition> DutyDefinitions { get; set; }
        public DbSet<DutyType> DutyTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FreeDimension1> FreeDimension1s { get; set; }
        public DbSet<FreeDimension2> FreeDimension2s { get; set; }
        public DbSet<OperationalPlan> OperationalPlans { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SubProject> SubProjects { get; set; }
        public DbSet<TaskInfo> Tasks { get; set; }
        public DbSet<TimeTransaction> TimeTransactions { get; set; }
    }
}