using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public class CreateModel : PageModel
    {
        private readonly WebApp.Data.ApplicationDbContext _context;

        public CreateModel(WebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Posts Posts { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Posts.Add(Posts);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
