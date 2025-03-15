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
            //JsonConvert.SerializeObject()：這個方法來自於 Newtonsoft.Json 套件，用來將物件序列化成 JSON 格式的字串。
            //這意味著它會將 data0 的所有資料（屬性、數值等）轉換為一個符合 JSON 格式的字串。
            //物件轉成 json 字串
            string str1 = Newtonsoft.Json.JsonConvert.SerializeObject(data0);

            System.Diagnostics.Debug.WriteLine("物件轉 json : "+str1);

            //JsonConvert.DeserializeObject<StudentClass>()：這個方法會將 JSON 字串反序列化成一個物件。
            //在這個例子中，StudentClass 是反序列化後的目標類型，這意味著我們期望從 str1 字串中建立一個 StudentClass 類型的物件。
            //json字串 轉 物件
            var list1 = Newtonsoft.Json.JsonConvert.DeserializeObject<StudentClass>(str1);

            System.Diagnostics.Debug.WriteLine("json轉 物件 : " + list1);

      
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
