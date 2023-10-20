using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Assistant.DbContexts
{
    public class StudentAssistantDesignTimeDbContext : IDesignTimeDbContextFactory<StudentAssistantDbContext>
    {
        public StudentAssistantDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=studentAsistan.db").Options;
            return new StudentAssistantDbContext(options);
        }
    }
}
