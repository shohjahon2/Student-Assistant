using Student_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.IServices
{
    public interface IQuestionService
    {
    Task<IEnumerable<Question>> GetQuestion();
    }
}
