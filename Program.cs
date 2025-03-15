using WebApplication_web_01.Models.Db_context;
using WebApplication_web_01.Models.Interface;
using Microsoft.EntityFrameworkCore;
using WebApplication_web_01.Models;

var builder = WebApplication.CreateBuilder(args);

// 註冊 MVC 控制器與視圖服務
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services：這是 ASP.NET Core 應用程式中用來註冊服務的容器。
//AddTransient：設定服務的生命週期為「短暫」，也就是說每次注入時都會創建一個新的實例。
//如果希望在整個應用程式中共用一個實例，可以使用 AddSingleton；
//若希望在每個請求中共用一個實例，可以使用 AddScoped。

//<BankService, A_Bank>：指定當需要 BankService（通常是一個介面或抽象類型）的實例時，
//實際上會建立並返回一個 A_Bank 類型的實例。
//總結來說，這段程式碼使得當你的應用程式在執行期間需要一個 BankService 時，
//會自動注入一個新的 A_Bank 實例，從而實現鬆耦合與方便測試的目的。

builder.Services.AddTransient<BankService, A_Bank>();

// 設定 Entity Framework Core 使用 SQL Server，並從 appsettings.json 讀取連線字串
builder.Services.AddDbContext<DB_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db_string")));

// 註冊  介面與實作，藉由 DI 提供資料存取服務
builder.Services.AddScoped<Interface_school, A_School>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
