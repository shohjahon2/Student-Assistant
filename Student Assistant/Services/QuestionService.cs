using Microsoft.EntityFrameworkCore;
using Student_Assistant.DbContexts;
using Student_Assistant.DTOs;
using Student_Assistant.IServices;
using Student_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.Services
{
    class QuestionService : IQuestionService
    {
        private readonly StudentAssistantDbContextFactory _dbContextFactory;


        public QuestionService(StudentAssistantDbContextFactory dbContextFactory)
        {
          _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Question>> GetQuestion()
        {
            using (StudentAssistantDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<QuestionDTO> question = await dbContext.Questions.ToListAsync();
                return question.Select(q => ToQuestion(q));
            }
        }

        private static Question ToQuestion(QuestionDTO q)
        {
            return new Question(q.Id,q.QuestionContext,q.Answer1,q.Answer2,q.Answer3,q.Answer4);
        }
    }
}
