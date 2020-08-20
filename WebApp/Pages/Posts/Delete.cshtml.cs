using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public class DeleteModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public DeleteModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Posts Posts { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Posts = await _context.Posts.FirstOrDefaultAsync(m => m.ID == id);

            if (Posts == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Posts = await _context.Posts.FindAsync(id);

            if (Posts != null)
            {
                _context.Posts.Remove(Posts);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
