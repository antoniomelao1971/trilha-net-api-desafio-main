namespace DesafioApiMelao.Interfaces;

public interface ITarefaRepository
{
    Task<IEnumerable<Tarefa>> GetTarefas();
    // salvar alteracoes
    Task<bool> SaveChangesAsync();

    // Get By Id
    Task<Tarefa> GetTarefasPorId(int id);
    // Get By Titulo
    Task<Tarefa> GetTarefasPorTitulo(string titulo);
    // Get By Data
    Task<Tarefa> GetTarefasPorData(DateTime data);
    // Add Tarefa
    void InsertTarefas(Tarefa tarefa);

    // Update Tarefa
    void UpdateTarefas(Tarefa tarefa);

    // Delete Tarefa
    void DeleteTarefas(Tarefa tarefa);
}