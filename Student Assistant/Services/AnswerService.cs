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
    public class AnswerService : IAnswerService
    {
        private readonly StudentAssistantDbContextFactory _dbContextFactory;

        public AnswerService(StudentAssistantDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Answer>> GetAnswers()
        {
            using (StudentAssistantDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
               IEnumerable<AnswerDTO> answers =  await dbContext.Answers.ToListAsync();
                return answers.Select(a => ToAnswer(a));
            }
        }

        private Answer ToAnswer(AnswerDTO a)
        {
            return new Answer(a.Id,a.QuestionContext,a.Answered);
        }
    }
}
