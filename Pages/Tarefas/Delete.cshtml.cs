using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Pages.Tarefas
{
    public class DeleteModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public DeleteModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tarefa Tarefa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FirstOrDefaultAsync(m => m.Id == id);

            if (tarefa == null)
            {
                return NotFound();
            }
            else
            {
                Tarefa = tarefa;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa != null)
            {
                Tarefa = tarefa;
                _context.Tarefas.Remove(Tarefa);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
