using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorProjetos.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O título da tarefa é obrigatório.")]
        public string Titulo { get; set; } // Adicionando o titulo
        public string Descricao { get; set; }
        public int ProjetoId { get; set; }
        public string Prioridade { get; set; }
        public int PercentualConclusao { get; set; }
        [ForeignKey("ProjetoId")]
        public virtual Projeto? Projeto { get; set; }
        public int? MembroResponsavelId { get; set; } // ID do MEMBRO
        [ForeignKey("MembroResponsavelId")]
        public virtual Usuario? MembroResponsavel { get; set; }
    }
}