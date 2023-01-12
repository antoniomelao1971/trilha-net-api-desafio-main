namespace DesafioApiMelao.Models;

[Table("Tarefas")]
[Index(nameof(Id))]
public class Tarefa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public int Id { get; set; }

    [Column("Titulo", TypeName = "VARCHAR")]
    [MaxLength(100)]
    [Required(ErrorMessage = "Título é um campo obrigatório!")]
    public string Titulo { get; set; } = string.Empty!;

    [Column("Descricao", TypeName = "VARCHAR")]
    [MaxLength(500)]
    [Required(ErrorMessage = "Descricao é um campo obrigatório!")]
    public string Descricao { get; set; } = string.Empty!;

    [Column("DataTarefa", TypeName = "DATETIME")]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    // [Required]
    public DateTime DataTarefa { get; set; }

}