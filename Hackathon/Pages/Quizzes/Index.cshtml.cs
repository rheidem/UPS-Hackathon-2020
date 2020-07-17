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

        public IEnumerable<Quiz> Quiz { get;set; }
        public IEnumerable<User> user { get; set; }
        public IEnumerable<Completed_Quiz> Completed_Quizzes { get; set; } 

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Quiz = from q in _context.Quizzes orderby q.Name select q;
            user = from u in _context.Users select u;
            Completed_Quizzes = from cq in _context.Completed_Quiz 
                            where cq.QuiztakerName.Contains(SearchTerm) || string.IsNullOrEmpty(SearchTerm)
                            orderby cq.QuiztakerName, cq.QuizType
                            select cq;

            // foreach(User u in user)
            // {
            //     u.Get_Completed_Quizzes_JSON();
            //     foreach(Completed_Quiz cq in u.Completed_Quizzes)
            //     {
            //         Completed_Quizzes.Add(cq);
            //     }   
            // } 
        }
    }
}
