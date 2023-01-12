namespace DesafioApiMelao.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarefa>()
        .Property(x => x.DataTarefa)
        .HasComputedColumnSql("GetUtcDate()");
    }

    // DbSet
    public DbSet<Tarefa> Tarefas { get; set; }
}