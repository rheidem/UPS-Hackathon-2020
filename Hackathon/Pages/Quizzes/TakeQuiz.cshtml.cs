using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;
using Newtonsoft.Json;

namespace Hackathon.Pages_Quizzes
{
    public class TakeQuizModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public TakeQuizModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quiz = _context.Quizzes.FirstOrDefault(m => m.ID == id);
            Quiz.Get_Questions_JSON();
            foreach(Question q in Quiz.Questions)
            {
                q.Get_MCAnswers_JSON();
            }

            names = _context.Users.Select(x=>x.Name).Distinct();

            // // -------------------------------------------------------------------
            Completed_Quiz = new Completed_Quiz();

            Completed_Quiz.Answers = new List<Answer>();

            foreach(Question q in Quiz.Questions)
            {
                Completed_Quiz.Answers.Add(new Answer(q.QuestionType));
            }
            Completed_Quiz.Set_Answers_JSON();

            Completed_Quiz.CorrespondingQuizName = Quiz.Name;
            Completed_Quiz.maxPoints = Quiz.TotalPoints;
            Completed_Quiz.QuizType = QuizType.Pending;
            // // -------------------------------------------------------------------

            Answers = new List<string>();
            foreach(Question q in Quiz.Questions)
            {
                Answers.Add("");
            }
            // Answers_JSON = JsonConvert.SerializeObject(Answers);

            return Page();
        }

        [BindProperty]
        public Completed_Quiz Completed_Quiz { get; set; }
        public Quiz Quiz { get; private set; }
        public IEnumerable<string> names { get; set; }

        [BindProperty]
        public List<string> Answers { get; set; }

        // [BindProperty]
        // public string Answers_JSON { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Answers = JsonConvert.DeserializeObject<List<string>>(Answers_JSON);

            Completed_Quiz.Get_Answers_JSON();

            for(int i = 0; i < Completed_Quiz.Answers.Count(); ++i)
            {
                Completed_Quiz.Answers.ElementAt(i).Answer_Text = Answers.ElementAt(i);
            }

            Completed_Quiz.Set_Answers_JSON();
            _context.Completed_Quiz.Add(Completed_Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
