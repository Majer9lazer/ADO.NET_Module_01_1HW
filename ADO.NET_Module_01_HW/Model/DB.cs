namespace ADO.NET_Module_01_HW.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<newEquipment> newEquipments { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturers { get; set; }
        public virtual DbSet<TablesStopReason> TablesStopReasons { get; set; }
        public virtual DbSet<TrackMeter> TrackMeters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<newEquipment>()
                .HasMany(e => e.TrackMeters)
                .WithRequired(e => e.newEquipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipments)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);
        }
    }
}
