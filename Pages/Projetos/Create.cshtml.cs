using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Pages.Projetos
{
    public class CreateModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;
        public CreateModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projeto Projeto { get; set; } = default!;

        [BindProperty]
        public List<int> MembrosSelecionados { get; set; } = new List<int>();
        public IActionResult OnGet()
        {
            var listaGerentes = _context.Usuarios.Where(u => u.TipoUsuario == "Gerente").ToList();
            ViewData["GerenteId"] = new SelectList(listaGerentes, "Id", "Nome");
            ViewData["Usuarios"] = new MultiSelectList(_context.Usuarios, "Id", "Nome");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["GerenteId"] = new SelectList(_context.Usuarios.Where(u => u.TipoUsuario == "Gerente"), "Id", "Nome");
                ViewData["Usuarios"] = new MultiSelectList(_context.Usuarios, "Id", "Nome");
                return Page();
            }

            if (MembrosSelecionados != null && MembrosSelecionados.Any())
            {
                Projeto.Equipa = new List<Usuario>();

                foreach (var id in MembrosSelecionados)
                {
                    // Busca o usuário no banco pelo ID 
                    var usuario = await _context.Usuarios.FindAsync(id);
                    if (usuario != null)
                    {
                        Projeto.Equipa.Add(usuario);
                    }
                }
            }

            _context.Projetos.Add(Projeto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}