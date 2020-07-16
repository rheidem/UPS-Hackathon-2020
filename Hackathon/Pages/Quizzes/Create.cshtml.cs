using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_Quizzes
{
    public class CreateModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public CreateModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            All_Questions = from q in _context.Questions select q;
            foreach(Question q in All_Questions)
            {
                q.Get_Tags_JSON();
                q.Get_MCAnswers_JSON();
            }

            return Page();
        }

        [BindProperty]
        public Quiz Quiz { get; set; }

        [BindProperty]
        public IEnumerable<Question> All_Questions { get;set; }

        [BindProperty]
        public string Questions { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            All_Questions = from q in _context.Questions select q;
            IEnumerable<string> Question_Strings = Questions.Split('\n');
            foreach(string s in Question_Strings) 
            {
                foreach(Question q in All_Questions)
                {
                    if(s == q.Name)
                    {
                        // Quiz.Questions.Append(new Question{
                        //     Correct_MCAnswer = q.Correct_MCAnswer,
                        //     ID = q.ID,
                        //     MCAnswers = q.MCAnswers,
                        //     MCAnswers_JSON = q.MCAnswers_JSON,
                        //     Name = q.Name,
                        //     NumPoints = q.NumPoints,
                        //     QuestionCode = q.QuestionCode,
                        //     QuestionText = q.QuestionText,
                        //     QuestionType = q.QuestionType,
                        //     Tags = q.Tags,
                        //     Tags_JSON = q.Tags_JSON
                        // });
                        
                    }
                }
            }

            foreach(Question q in Quiz.Questions)
            {
                Quiz.TotalPoints += q.NumPoints;
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Quiz.Set_Questions_JSON();
            _context.Quizzes.Add(Quiz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
