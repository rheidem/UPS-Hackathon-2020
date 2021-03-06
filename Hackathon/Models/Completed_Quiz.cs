using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackathon.Models
{
    // QUIZTYPE ENUM
    public enum QuizType { Pending, Graded };

    // COMPLETED QUIZ CLASS
    public class Completed_Quiz
    {
        [Required]
        public int ID { get; set; }
        
        [Required,Display(Name="Applicant Tested")]
        public string QuiztakerName { get; set; }

        [Required,Display(Name="Quiz Taken")]
        public string CorrespondingQuizName { get; set; }

        [Required]
        public int maxPoints { get; set; }

        [Required]
        public int pointsEarned { get; set; }

        [Required]
        public QuizType QuizType { get; set; }

        // ANSWERS
        [NotMapped]
        public List<Answer> Answers { get; set; }
        public string Answers_JSON { get; set; }

        public void Set_Answers_JSON()
        {
            if(Answers != null)
                Answers_JSON = JsonConvert.SerializeObject(Answers);
        }
        
        public void Get_Answers_JSON()
        {
            if(Answers_JSON != null)
                Answers = JsonConvert.DeserializeObject<List<Answer>>(Answers_JSON);
        }
    }
}