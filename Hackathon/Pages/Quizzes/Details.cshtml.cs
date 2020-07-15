using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_Quizzes
{
    public class DetailsModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public DetailsModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.ID == id);

            if (Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
