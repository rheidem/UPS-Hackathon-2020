using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Hackathon.Models;

namespace Pages.DetailPartialView
{
    public class _detailPartialViewModel : PageModel
    {
        private readonly Hackathon.Data.hackathonContext _context;

        public _detailPartialViewModel(Hackathon.Data.hackathonContext context)
        {
            _context = context;
        }

        public Question Question { get; set; }

        public void OnGet(Question q_in)
        {
            this.Question = q_in;
        }
    }
}