using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_User
{
    public class NewAccountModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public NewAccountModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User user { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
