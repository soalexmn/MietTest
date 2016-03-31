using DbLayer.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Contexts
{
    public class MainContext : IdentityDbContext<User>
    {
        public MainContext()
            : base("DefaultConnection")
        {
        }

        public MainContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public static MainContext Create()
        {
            return new MainContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // FluentAPI конфигурация
            modelBuilder.Entity<User>()
                .HasMany(u => u.Tests)
                .WithRequired()
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(u => u.TestResults)
                .WithOptional()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithRequired()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Test>()
                .HasMany(t => t.TestResults)
                .WithRequired()
                .WillCascadeOnDelete();

            modelBuilder.Entity<Question>()
                .HasMany(q => q.AnswerVariants)
                .WithRequired()
                .WillCascadeOnDelete();

            modelBuilder.Entity<TestResult>()
                .HasMany(r => r.QuestionResults)
                .WithOptional()
                .WillCascadeOnDelete();

        }

        // Таблицы БД:
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<TestResult> TestResults { get; set; }
        public virtual DbSet<QuestionResult> QuestionResults { get; set; }
        public virtual DbSet<AnswerVariant> AnswerVariants { get; set; }
    }
}
