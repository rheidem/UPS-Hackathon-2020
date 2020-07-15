using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackathon.Models
{
    public class Answer
    {
        [Required]
        public QuestionType QuestionType { get; set; }

        public string Answer_Text { get; set; }

        [Required]
        public int pointsGraded { get; set; }
    }
}