using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data; 
using Microsoft.AspNetCore.Http;

namespace GerenciadorProjetos.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _context;

        public LoginModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string email, string senha)
        {
            // Busca o usuário no banco comparando Email e Senha
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);

            if (usuario != null)
            {
                HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
                HttpContext.Session.SetString("UsuarioTipo", usuario.TipoUsuario);

                return RedirectToPage("/Index");
            }

            // errou os dados
            ViewData["Erro"] = "Email ou senha inválidos!";
            return Page();
        }
    }
}