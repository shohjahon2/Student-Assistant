using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.DbContexts
{
     public class StudentAssistantDbContextFactory
    {
        private string _connectionString;

        public StudentAssistantDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public StudentAssistantDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;
            return new StudentAssistantDbContext(options);
        }
    }
}
