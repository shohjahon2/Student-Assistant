using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.DTOs
{
   public  class AnswerDTO
    {
        [Key]
        public Guid Key { get; set; }
        public int Id { get; set; }
        public string QuestionContext { get; set; }
        public string Answered { get; set; }
    }
}
