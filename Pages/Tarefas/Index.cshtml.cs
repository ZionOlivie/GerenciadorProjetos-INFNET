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
    public class IndexModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;
        public IndexModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Tarefa> Tarefa { get;set; } = default!;
        public async Task OnGetAsync()
        {
            Tarefa = await _context.Tarefas
                .Include(t => t.Projeto)           
                .Include(t => t.MembroResponsavel) 
                .ToListAsync();
        }
    }
}
