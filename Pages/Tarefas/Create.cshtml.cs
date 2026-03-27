using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Pages.Tarefas
{
    public class CreateModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public CreateModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            // Carrega todos os projetos cadastrados para mostrar na hora de criar a tarefa
            var listaProjetos = _context.Projetos.ToList();
            ViewData["ProjetoId"] = new SelectList(listaProjetos, "Id", "Titulo");

            var listaMembros = _context.Usuarios.ToList();
            ViewData["Membros"] = new SelectList(listaMembros, "Id", "Nome");

            return Page();
        }

        [BindProperty]
        public Tarefa Tarefa { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tarefas.Add(Tarefa);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
