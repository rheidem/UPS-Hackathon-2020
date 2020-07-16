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
    public class IndexModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public IndexModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public IEnumerable<Question> Question { get;set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {

            Question = from q in _context.Questions select q;

            foreach(Question q in Question) {
                q.Get_Tags_JSON();
            }

            Question = from q in Question 
                            where q.Tags.Contains(SearchTerm) || string.IsNullOrEmpty(SearchTerm)
                            orderby q.Name
                            select q;
        }
    }
}
