using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.DTOs
{
    public class QuestionDTO
    { 
        [Key]
        public Guid Key { get; set; }
        public int Id { get; set; }
        public string QuestionContext { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
    }
}
