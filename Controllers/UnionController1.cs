using Microsoft.AspNetCore.Mvc;
using WebApplication_web_01.Models;
using WebApplication_web_01.Models.Interface;

namespace WebApplication_web_01.Controllers
{
    public class UnionController : Controller
    {
        private Interface_school _school;

        public UnionController(Interface_school interface_School)
        {
            _school = interface_School;
        }
        public IActionResult Display_all()
        {
            var db_student_data = _school.Get();

            Union_Data_Struct data01 = new Union_Data_Struct
            {
                student_list = db_student_data.ToList(),
                student = new db_student_model()

            };

            return View(data01);
        }
        [HttpPost]
        public IActionResult Create(Union_Data_Struct model) {
             _school.Add(model.student);
            return RedirectToAction("Display_all");
        }
        [HttpPost]
        public async Task<ActionResult> Update(Union_Data_Struct model)
        {
            await _school.Update(model.student);
            return RedirectToAction("Display_all");
        }
        public async Task<ActionResult> Delete([Bind(Prefix = "student.student_no")] string id)
        {
            await _school.Delete(id);
            return RedirectToAction("Display_all");
        }

        public async Task<ActionResult> Delete_userid(string id)
        {
            await _school.Delete(id); 
            return RedirectToAction("Display_all");
        }
    }
}
