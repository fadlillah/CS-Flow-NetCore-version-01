using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_Flow.Models;

namespace CS_Flow.Data
{
    internal class DataContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=fdflow.db");
        }
        public virtual DbSet<FillingBatch> tblFillingBatch { get; set; }
        public virtual DbSet<FillingPoint> tblFillingPoint { get; set; }
        public virtual DbSet<ChildDevice> tblChildDevice { get; set; }
        public virtual DbSet<FillingSession> tblFillingSession { get; set; }
        public virtual DbSet<EventLog> tblEventLog { get; set; }
    }
}
