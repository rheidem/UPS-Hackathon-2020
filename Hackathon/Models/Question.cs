using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackathon.Models
{
    // QUESTIONTYPE ENUM
    public enum QuestionType 
    { 
        [Display(Name="Multiple Choice")]
        multiple_choice, 
        [Display(Name="Short Answer")]
        short_answer, 
        [Display(Name="Video Response")]
        video_response, 
        [Display(Name="Coding Question")]
        coding, 
        [Display(Name="Code Correction")]
        code_correction 
    };

    // QUESTION CLASS
    public class Question
    {   
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required,Display(Name="Number of Points")]
        public int NumPoints { get; set; }

        [Required,Display(Name="Question Type")]
        public QuestionType QuestionType { get; set; }

        [Required,Display(Name="Question Text")]
        public string QuestionText { get; set; }

        [Display(Name="Question Code")]
        public string QuestionCode { get; set; }

        [Display(Name="Correct MC Answer")]
        public string Correct_MCAnswer { get; set; }

        // MC ANSWERS
        [NotMapped,Display(Name="MC Answers")]
        public IEnumerable<string> MCAnswers { get; set; }
        public string MCAnswers_JSON { get; set; }

        public void Set_MCAnswers_JSON()
        {
            if(MCAnswers != null)
                MCAnswers_JSON = JsonConvert.SerializeObject(MCAnswers);
        }
        
        public void Get_MCAnswers_JSON()
        {
            if(MCAnswers_JSON != null)
                MCAnswers = JsonConvert.DeserializeObject<IEnumerable<string>>(MCAnswers_JSON);
        }

        // TAGS
        [NotMapped,Display(Name="Tags")]
        public IEnumerable<string> Tags { get; set; }
        public string Tags_JSON { get; set; }

        public void Set_Tags_JSON()
        {
            if(Tags != null)
                Tags_JSON = JsonConvert.SerializeObject(Tags);
        }
        
        public void Get_Tags_JSON()
        {
            if(Tags_JSON != null)
                Tags = JsonConvert.DeserializeObject<IEnumerable<string>>(Tags_JSON);
        }
    }
}
