using System.ComponentModel.DataAnnotations;

namespace GerenciadorProjetos.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string TipoUsuario { get; set; }

        //muitos-para-muitos
        public virtual ICollection<Projeto>? ProjetosParticipados { get; set; } = new List<Projeto>();
    }
}