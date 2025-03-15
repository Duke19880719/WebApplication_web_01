namespace WebApplication_web_01.Models.Interface
{
    public interface Interface_school
    {
        IEnumerable<db_student_model> Get();

        db_student_model get_by_id(int id);

        Task Add (db_student_model student);

        Task Update(db_student_model student);
     
        Task Delete(string id);
    }

}
