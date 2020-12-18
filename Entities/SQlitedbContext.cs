using BlazorPrueba.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPrueba.Entities
{
    public class SQlitedbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var connectionbuilder = new SqliteConnectionStringBuilder { DataSource = "Db.db" };
            var connectionString = connectionbuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            builder.UseSqlite(connection);
        }

        public DbSet<Accidente> Accidentes { get; set; }
        public DbSet<Persona> Personas { get; set; }

    }
}
