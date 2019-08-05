using SQLite.CodeFirst;
using System;
using System.Data.Entity;
using System.Data.SQLite;
using TestConscensia.Data.Base;
using TestConscensia.Data.Entities;

namespace TestConscensia.Data.Contexts
{
    /// <summary>
    ///     Context for synchronization DB
    /// </summary>
    [DbConfigurationType(typeof(SqLiteConfiguration))]
    public class TestDbContext : DbContext, IDbContext
    {
        public TestDbContext(string dbPath) : base(new SQLiteConnection
        {
            ConnectionString =
                new SQLiteConnectionStringBuilder { DataSource = dbPath, ForeignKeys = true }.ConnectionString
        }, true)
        {
            Database.SetInitializer<TestDbContext>(new DropCreateDatabaseAlways<TestDbContext>());
        }

        public TestDbContext() : base(new SQLiteConnection
        {
            ConnectionString =
                new SQLiteConnectionStringBuilder { DataSource = AppDomain.CurrentDomain.BaseDirectory + "\\database.db", ForeignKeys = true }
                    .ConnectionString
        }, true)
        {
            Database.SetInitializer<TestDbContext>(new DropCreateDatabaseAlways<TestDbContext>());
        }

        public DbSet<ReportCodeEntity> ReportCode { get; set; }
        public DbSet<OfficeLocationEntity> OfficeLocation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteDropCreateDatabaseAlways<TestDbContext>(modelBuilder);

            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}