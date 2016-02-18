using DbLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Contexts
{
    public class MainContext : DbContext
    {
        public MainContext() : base("MainContext")
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

        }

        // Таблицы БД:
        public virtual DbSet<Topic> Topics { get; set; }
    }
}
