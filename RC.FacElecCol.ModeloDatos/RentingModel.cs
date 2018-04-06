namespace RC.FacElecCol.ModeloDatos
{
    using System.Data.Entity;
    using Modelo.Entidades.RentingModel;

    public class RentingModel : DbContext
    {
        // Your context has been configured to use a 'RentingFeCoModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'RC.FacElecCol.ModeloDatos.RentingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'RentingModel' 
        // connection string in the application configuration file.
        public RentingModel() : base("name=RentingFeCoModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.
        public virtual DbSet<FeCActividades> FeCActividades { get; set; }
        public virtual DbSet<FeCActividadesPeriodicas> FeCActividadesPeriodicas { get; set; }
        public virtual DbSet<FeCActividadesProgramadas> FeCActividadesProgramadas { get; set; }
        public virtual DbSet<FeCEstadosActividades> FeCEstadosActividades { get; set; }
        public virtual DbSet<FeCTareas> FeCTareas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FeCActividades>()
                .HasOptional(e => e.ActividadProgramada)
                .WithRequired(e => e.Actividad);

            modelBuilder.Entity<FeCActividades>()
                .HasOptional(e => e.ActividadPeriodica)
                .WithRequired(e => e.Actividad);

            modelBuilder.Entity<FeCEstadosActividades>()
                .HasMany(e => e.Actividades)
                .WithRequired(e => e.EstadoActividad)
                .HasForeignKey(e => e.CodigoEstado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeCTareas>()
                .HasMany(e => e.Actividades)
                .WithRequired(e => e.Tarea)
                .HasForeignKey(e => e.CodigoTarea)
                .WillCascadeOnDelete(false);
        }
    }
}
