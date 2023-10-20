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
    class QuestionCreator : IQuestionCreator
    {
        private readonly StudentAssistantDbContextFactory _dbContextFactory;

        public QuestionCreator(StudentAssistantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateQuestion(Question question)
        {
            using (StudentAssistantDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                QuestionDTO question1 = ToQuestionDTO(question);
                dbContext.Questions.Add(question1);
                await dbContext.SaveChangesAsync();
            }
        }

        private QuestionDTO ToQuestionDTO(Question question)
        {
            return new QuestionDTO
            {
                Id=question.Id,
                QuestionContext=question.QuestionContext,
                Answer1=question.Answer1,
                Answer2=question.Answer2,
                Answer3=question.Answer3,
                Answer4=question.Answer4
            };
        }
    }
}
