using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_Quizzes
{
    public class EditModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public EditModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Completed_Quiz Completed_Quiz { get; set; }

        [BindProperty]
        public List<int> AnswerScores { get; set; }
        public Quiz Quiz { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Completed_Quiz = await _context.Completed_Quiz.FirstOrDefaultAsync(m => m.ID == id);
            Completed_Quiz.Get_Answers_JSON();
            
            Quiz = await _context.Quizzes.FirstOrDefaultAsync(m => m.Name == Completed_Quiz.CorrespondingQuizName);
            Quiz.Get_Questions_JSON();

            AnswerScores = new List<int>();
            foreach(Question q in Quiz.Questions)
            {
                AnswerScores.Add(0);
            }

            if (Completed_Quiz == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Completed_Quiz.QuizType = QuizType.Graded;


            Completed_Quiz.Get_Answers_JSON();

            for(int i = 0; i < Completed_Quiz.Answers.Count(); ++i)
            {
                Completed_Quiz.Answers.ElementAt(i).pointsGraded = AnswerScores.ElementAt(i);
            }

            foreach(Answer a in Completed_Quiz.Answers)
            {
                Completed_Quiz.pointsEarned += a.pointsGraded;

            }

            Completed_Quiz.Set_Answers_JSON();
            _context.Attach(Completed_Quiz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Completed_QuizExists(Completed_Quiz.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool Completed_QuizExists(int id)
        {
            return _context.Completed_Quiz.Any(e => e.ID == id);
        }
    }
}
