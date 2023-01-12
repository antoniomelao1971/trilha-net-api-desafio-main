namespace DesafioApiMelao.Repositories;

public class TarefaRepository : ITarefaRepository
{
    // DI
    private readonly AppDbContext _context;
    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }
    public void UpdateTarefas(Tarefa tarefa)
    {
        _context.Update(tarefa);
    }
    public void DeleteTarefas(Tarefa tarefa)
    {
        _context.Remove(tarefa);
    }

    public async Task<IEnumerable<Tarefa>> GetTarefas()
    {
        return await _context.Tarefas.AsNoTracking().ToListAsync();
    }

    public async Task<Tarefa> GetTarefasPorData(DateTime data)
    {
        var tarefa = await _context.Tarefas
        .Where(x => x.DataTarefa == data)
        .FirstOrDefaultAsync();

        return tarefa;
    }

    public async Task<Tarefa> GetTarefasPorId(int id)
    {
        var tarefa = await _context.Tarefas
        .Where(x => x.Id == id)
        .FirstOrDefaultAsync();

        return tarefa;
    }
    public async Task<Tarefa> GetTarefasPorTitulo(string titulo)
    {
        var tarefa = await _context.Tarefas
        .Where(x => x.Titulo.Contains(titulo))
        .FirstOrDefaultAsync();

        return tarefa;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void InsertTarefas(Tarefa tarefa)
    {
        _context.Add(tarefa);
    }
}