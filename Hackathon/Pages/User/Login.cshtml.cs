using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Hackathon.Models;
using Hackathon.Data;

namespace Hackathon.Pages_User
{
    public class LoginModel : PageModel
    {

        private readonly ILogger<LoginModel> _logger;

        public User user { get; set; }

        [BindProperty]
        public string InputName { get; set; }

        [BindProperty]
        public string InputPassword { get; set; }
        public hackathonContext Context { get; }

        public LoginModel(ILogger<LoginModel> logger, hackathonContext _context)
        {
            _logger = logger;
            Context = _context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            user = Context.Users.FirstOrDefault(e => e.Name == InputName);
            if(user == null) {
                return RedirectToPage("/Error");
            }
            else
            {
                if(user.Password == InputPassword)
                {
                    return RedirectToPage("/Index");
                }
                else{
                    return RedirectToPage("/Error");
                }
            }
        }
    }
}