using Microsoft.AspNetCore.Mvc;
using WebApplication_web_01.Models.Db_context;
using WebApplication_web_01.Models.Interface;

namespace WebApplication_web_01.Models
{
    public class A_School : Interface_school
    {
        private DB_Context Db_Context;
        public A_School(DB_Context DbContext) {

            Db_Context = DbContext;
        }
        public async Task Add(db_student_model student)
        {
            Db_Context.student.Add(student);
            await  Db_Context.SaveChangesAsync();
        }

        public IEnumerable<db_student_model> Get()
        {
            return Db_Context.student.ToList();
         
        }

        public db_student_model get_by_id(int id)
        {
            return Db_Context.student.Find(id);
        }


        public async Task  Update(db_student_model student)
        {
            Db_Context.student.Update(student);
          await  Db_Context.SaveChangesAsync();

        }

        public async Task Delete(string id)
        {
           var obj = Db_Context.student.Find(id);
            if (obj != null)
            {
                Db_Context.student.Remove(obj);
                await Db_Context.SaveChangesAsync();
            }
        }
    }
}
