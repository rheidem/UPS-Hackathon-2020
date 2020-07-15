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
    public class IndexModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public IndexModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public IList<Quiz> Quiz { get;set; }

        public async Task OnGetAsync()
        {
            Quiz = await _context.Quizzes.ToListAsync();
        }
    }
}
