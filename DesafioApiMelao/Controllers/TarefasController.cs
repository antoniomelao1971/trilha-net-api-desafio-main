namespace DesafioApiMelao.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TarefasController : ControllerBase
{
    // DI
    private readonly ITarefaRepository _repository;
    public TarefasController(ITarefaRepository repository)
    {
        _repository = repository;
    }

    // GET TODAS AS TAREFAS
    [HttpGet]
    public async Task<IActionResult> GetTarefas()
    {
        var tarefas = await _repository.GetTarefas();
        return tarefas.Any()
        ? Ok(tarefas)
        : NoContent();
    }

    // GET TAREFA POR ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTarefasPorId(int id)
    {
        var tarefa = await _repository.GetTarefasPorId(id);

        return tarefa != null
        ? Ok(tarefa)
        : NotFound("Tarefa não encontrada!");
    }
    // GET TAREFA POR TITULO
    [HttpGet("Titulo/{titulo}")]
    public async Task<IActionResult> GetTarefasPorTitulo(string titulo)
    {
        var tarefa = await _repository.GetTarefasPorTitulo(titulo);

        return tarefa != null
        ? Ok(tarefa)
        : NotFound("Tarefa não encontrada!");
    }
    // GET TAREFA POR DATA
    [HttpGet("Data/{data}")]
    public async Task<IActionResult> GetTarefasPorData(DateTime data)
    {
        var tarefa = await _repository.GetTarefasPorData(data);

        return tarefa != null
        ? Ok(tarefa)
        : NotFound("Tarefa não encontrada!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTarefas(int id)
    {
        var tarefa = await _repository.GetTarefasPorId(id);

        if (tarefa == null)
            return NotFound("Tarefa não encontrada!");

        _repository.DeleteTarefas(tarefa);

        return await _repository.SaveChangesAsync()
        ? Ok()
        : BadRequest();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTarefas(int id, Tarefa tarefa)
    {
        var tarefaUpdate = await _repository.GetTarefasPorId(id);

        if (tarefa == null)
            return NotFound("Tarefa não encontrada!");

        tarefaUpdate.DataTarefa = tarefa.DataTarefa;
        tarefaUpdate.Descricao = tarefa.Descricao;
        tarefaUpdate.Titulo = tarefa.Titulo;

        return await _repository.SaveChangesAsync()
        ? Ok()
        : BadRequest();
    }
    [HttpPost]
    public async Task<IActionResult> InsertTarefas(Tarefa tarefa)
    {

        _repository.InsertTarefas(tarefa);
        return await _repository.SaveChangesAsync()
        ? Ok()
        : BadRequest();
    }
}