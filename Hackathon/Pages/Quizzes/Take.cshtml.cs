using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Hackathon.Pages_Quizzes
{
    public class TakeModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public TakeModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.ID == id);
            Quiz.Get_Questions_JSON();
            foreach(Question q in Quiz.Questions)
            {
                q.Get_MCAnswers_JSON();
            }

            names = _context.Users.Select(x=>x.Name).Distinct();

            Completed_Quiz = new Completed_Quiz();

            Completed_Quiz.Answers = new List<Answer>();

            foreach(Question q in Quiz.Questions)
            {
                Completed_Quiz.Answers.Add(new Answer(q.QuestionType));
            }

            Completed_Quiz.CorrespondingQuizName = Quiz.Name;
            Completed_Quiz.maxPoints = Quiz.TotalPoints;
            Completed_Quiz.QuizType = QuizType.Pending;

            return Page();
        }

        [BindProperty]
        public Completed_Quiz Completed_Quiz { get; set; }
        
        [BindProperty]
        public Quiz Quiz { get; set; }
        public IEnumerable<string> names { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Completed_Quiz.Set_Completed_Quizzes_JSON();
            _context.Completed_Quiz.Add(Completed_Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
