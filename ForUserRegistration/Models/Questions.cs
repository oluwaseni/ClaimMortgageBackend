using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForUserRegistration.Models
{
    public class Questions
    {
        [Key]
        public int id { get; set; }
        public string QuestionsOn { get; set; }
        public string ExpectedAnswers { get; set; }
    }
}
