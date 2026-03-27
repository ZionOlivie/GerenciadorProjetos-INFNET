using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GerenciadorProjetos.Data;
using GerenciadorProjetos.Models;

namespace GerenciadorProjetos.Pages.Projetos
{
    public class DeleteModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public DeleteModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projeto Projeto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.FirstOrDefaultAsync(m => m.Id == id);

            if (projeto == null)
            {
                return NotFound();
            }
            else
            {
                Projeto = projeto;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto != null)
            {
                Projeto = projeto;
                _context.Projetos.Remove(Projeto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
