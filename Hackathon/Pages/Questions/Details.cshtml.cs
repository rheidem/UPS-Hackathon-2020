using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_Questions
{
    public class DetailsModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public DetailsModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Question = await _context.Questions.FirstOrDefaultAsync(m => m.ID == id);
            Question.Get_Tags_JSON();
            Question.Get_MCAnswers_JSON();

            if (Question == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
