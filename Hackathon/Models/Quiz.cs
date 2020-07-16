using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackathon.Models
{
    // QUIZ CLASS
    public class Quiz
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required,Display(Name="Total Points")]
        public int TotalPoints { get; set; }

        [Required,Display(Name="Related Job")]
        public string RelatedJob { get; set; }

        // QUESTIONS
        [NotMapped]
        public IEnumerable<Question> Questions { get; set; }
        public string Questions_JSON { get; set; }

        public void Set_Questions_JSON()
        {
            if(Questions != null)
                Questions_JSON = JsonConvert.SerializeObject(Questions);
        }
        
        public void Get_Questions_JSON()
        {
            if(Questions_JSON != null)
                Questions = JsonConvert.DeserializeObject<IEnumerable<Question>>(Questions_JSON);
        }
    }
}
