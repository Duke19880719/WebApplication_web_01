using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication_web_01.Models.Db_context
{
    public class DB_Context: DbContext
    {
        public DB_Context(DbContextOptions<DB_Context> options) : base(options)
        { 
        
        }

        public DbSet<db_student_model> student { get; set; }
    }
}
