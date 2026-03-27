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
    public class DetailsModel : PageModel
    {
        private readonly GerenciadorProjetos.Data.AppDbContext _context;

        public DetailsModel(GerenciadorProjetos.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
