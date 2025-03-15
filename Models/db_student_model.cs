using System.ComponentModel.DataAnnotations;

namespace WebApplication_web_01.Models
{
    public class db_student_model
    {
       [Key]
       public string student_no { get; set; }
       public string name { get; set; }
       public int depart_id { get; set; }
    }
}
