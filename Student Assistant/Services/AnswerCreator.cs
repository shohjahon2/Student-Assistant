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
    public class AnswerCreator : IAnswerCreator
    {
        private readonly StudentAssistantDbContextFactory _dbContextFactory;

        public AnswerCreator(StudentAssistantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateAnswer(Answer answer)
        {
            using (StudentAssistantDbContext dbContext= _dbContextFactory.CreateDbContext())
            {
                AnswerDTO answer1 = ToAnswerDTO(answer);
                dbContext.Answers.Add(answer1);
                await dbContext.SaveChangesAsync();
            }
        }

        private AnswerDTO ToAnswerDTO(Answer answer)
        {
            return new AnswerDTO
            {
                Id = answer.Id,
                QuestionContext = answer.QuestionContext,
                Answered = answer.Answered
            };
        }
    }
}
