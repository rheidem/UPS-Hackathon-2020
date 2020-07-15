using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hackathon.Models
{
    // USERTYPE ENUM
    public enum UserType { Admin, Applicant };

    // USER CLASS
    public class User 
    {
        [Required]
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public UserType UserType { get; set; }

        // COMPLETED QUIZZES
        [NotMapped]
        public IEnumerable<Completed_Quiz> Completed_Quizzes { get; set; }
        public string Completed_Quizzes_JSON { get; set; }

        public void Set_Completed_Quizzes_JSON()
        {
            if(Completed_Quizzes != null)
                Completed_Quizzes_JSON = JsonConvert.SerializeObject(Completed_Quizzes);
        }
        
        public void Get_Completed_Quizzes_JSON()
        {
            if(Completed_Quizzes_JSON != null)
                Completed_Quizzes = JsonConvert.DeserializeObject<IEnumerable<Completed_Quiz>>(Completed_Quizzes_JSON);
        }
    }
}