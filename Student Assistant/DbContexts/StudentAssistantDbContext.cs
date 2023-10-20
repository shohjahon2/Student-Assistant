using Microsoft.EntityFrameworkCore;
using Student_Assistant.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.DbContexts
{
    public class StudentAssistantDbContext:DbContext
    {

        public DbSet<QuestionDTO> Questions  { get; set; }
        public DbSet<AnswerDTO> Answers  { get; set; }
        public StudentAssistantDbContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}
