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
    public class IndexModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public IndexModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Projeto> Projeto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Projeto = await _context.Projetos.ToListAsync();
            Projeto = await _context.Projetos
                .Include(p => p.Gerente)
                .Include(p => p.Equipa)
                .ToListAsync();
        }
    }
}
