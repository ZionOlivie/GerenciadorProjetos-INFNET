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
    public class DetailsModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public DetailsModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        public Projeto Projeto { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var projeto = await _context.Projetos
                .Include(p => p.Gerente)
                .Include(p => p.Equipa)
                .FirstOrDefaultAsync(m => m.Id == id);

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
    }
}
