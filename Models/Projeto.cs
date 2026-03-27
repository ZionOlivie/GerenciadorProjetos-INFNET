using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorProjetos.Models
{
    public class Projeto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataPrazo { get; set; }
        public string Status { get; set; }
        [Required]
        public int GerenteResponsavelId { get; set; }

        [ForeignKey("GerenteResponsavelId")]
        public virtual Usuario? Gerente { get; set; }
        public virtual ICollection<Usuario>? Equipa { get; set; } = new List<Usuario>();
    }
}