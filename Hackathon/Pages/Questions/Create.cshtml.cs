using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;
using System.ComponentModel.DataAnnotations;

namespace Hackathon.Pages_Questions
{
    public class CreateModel : PageModel
    {
        public IEnumerable<SelectListItem> QuestionTypes { get; set; }
        private readonly Hackathon.Data.hackathonContext _context;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty,Display(Name="Multiple Choice Answers")]
        public string MCAnswers { get; set; }

        [BindProperty]
        public string Tags { get; set; }

        public CreateModel(Hackathon.Data.hackathonContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            QuestionTypes = htmlHelper.GetEnumSelectList<QuestionType>();
            return Page();
        }

        [BindProperty]
        public Question Question { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Get the MCAnswers and Tags from bound variables and put in Question object
            Question.Tags = Tags.Split(' ');
            Question.MCAnswers = MCAnswers.Split('\n');

            Question.Set_MCAnswers_JSON();
            Question.Set_Tags_JSON();
            _context.Questions.Add(Question);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
