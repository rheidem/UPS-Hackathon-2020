using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Hackathon.Data;
using Hackathon.Models;

namespace Hackathon.Pages_User
{
    public class NewAccountModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;
        public IEnumerable<SelectListItem> UserTypes { get; set; }
        private readonly IHtmlHelper htmlHelper;

        public NewAccountModel(Hackathon.Data.hackathonContext context, IHtmlHelper htmlHelper)
        {
            _context = context;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            UserTypes = htmlHelper.GetEnumSelectList<UserType>();
            return Page();
        }

        [BindProperty]
        public User user { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //user.Set_Completed_Quizzes_JSON();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}
