using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_web_01.Models;
using WebApplication_web_01.Models.Interface;


namespace WebApplication_web_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly  BankService _bankService;

        public HomeController(BankService bankService)
        {
            _bankService = bankService;
        }

        public IActionResult Index()
        {
            ViewData["BankId"] = _bankService.BankId;
            ViewData["BankName"] = _bankService.BankName;
            ViewData["Deposit"] = _bankService.Deposit;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        
        [HttpPost]
        public IActionResult Test()
        {
            return Ok("123");
        }
        [HttpPost]
        public IActionResult Test01([FromBody] StudentClass data0)
        {
            //JsonConvert.SerializeObject()�G�o�Ӥ�k�Ӧ۩� Newtonsoft.Json �M��A�ΨӱN����ǦC�Ʀ� JSON �榡���r��C
            //�o�N���ۥ��|�N data0 ���Ҧ���ơ]�ݩʡB�ƭȵ��^�ഫ���@�ӲŦX JSON �榡���r��C
            //�����ন json �r��
            string str1 = Newtonsoft.Json.JsonConvert.SerializeObject(data0);

            System.Diagnostics.Debug.WriteLine("������ json : "+str1);

            //JsonConvert.DeserializeObject<StudentClass>()�G�o�Ӥ�k�|�N JSON �r��ϧǦC�Ʀ��@�Ӫ���C
            //�b�o�ӨҤl���AStudentClass �O�ϧǦC�ƫ᪺�ؼ������A�o�N���ۧڭ̴���q str1 �r�ꤤ�إߤ@�� StudentClass ����������C
            //json�r�� �� ����
            var list1 = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentClass>(str1);

            System.Diagnostics.Debug.WriteLine("json�� ���� : " + list1);

      
            System.Diagnostics.Debug.WriteLine("list item : "+list1.stu_name);
       

            return Ok(new{ stu_name = data0.stu_name, gender = data0.gender});

           

        }

        //no [FromBody] and no model
        [HttpPost]
        public IActionResult Test02(string stu_name,string gender)
        {
            return Ok(new { stu_name,gender});
        }

        //[HttpPost]
        //public IActionResult Test03(string stu_name, string gender)
        //{
        //    return Ok(new { stu_name, gender });
        //}
        [HttpPost]
        public IActionResult ajax_method([FromBody] MethodModel model1)
        {
            //method = "788";
            return Ok(new { model1.method });

        }

        [HttpPost]
        public IActionResult ajax_method1(string method)
        {
            
            return Ok(new { method });

        }

        public IActionResult DI_Action([FromServices] BankService action_di)
        {
            ViewData["BankId"] = action_di.BankId;
            ViewData["BankName"] = action_di.BankName;
            ViewData["Deposit"] = action_di.Deposit;
            return View();
        }
     
        public IActionResult DI_union_DbConnect()
        {
            return View();
        }

        
    }
}
