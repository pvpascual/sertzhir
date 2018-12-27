using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SertzHir.Core.Entities;
using SertzHir.Core.Interfaces;

namespace SertzHir.Services
{
    public class SertzHirDataDbContext:DbContext
    {
        public SertzHirDataDbContext()
            : base("SertzHirDataContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SertzHirDataDbContext, SertzHir.Services.Migrations.Configuration>());

        }


        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<State> States { get; set; }
      
    }
}
