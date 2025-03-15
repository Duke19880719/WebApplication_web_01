using WebApplication_web_01.Models.Db_context;
using WebApplication_web_01.Models.Interface;
using Microsoft.EntityFrameworkCore;
using WebApplication_web_01.Models;

var builder = WebApplication.CreateBuilder(args);

// ���U MVC ����P���ϪA��
// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services�G�o�O ASP.NET Core ���ε{�����Ψӵ��U�A�Ȫ��e���C
//AddTransient�G�]�w�A�Ȫ��ͩR�g�����u�u�ȡv�A�]�N�O���C���`�J�ɳ��|�Ыؤ@�ӷs����ҡC
//�p�G�Ʊ�b������ε{�����@�Τ@�ӹ�ҡA�i�H�ϥ� AddSingleton�F
//�Y�Ʊ�b�C�ӽШD���@�Τ@�ӹ�ҡA�i�H�ϥ� AddScoped�C

//<BankService, A_Bank>�G���w��ݭn BankService�]�q�`�O�@�Ӥ����Ω�H�����^����ҮɡA
//��ڤW�|�إߨê�^�@�� A_Bank ��������ҡC
//�`���ӻ��A�o�q�{���X�ϱo��A�����ε{���b��������ݭn�@�� BankService �ɡA
//�|�۰ʪ`�J�@�ӷs�� A_Bank ��ҡA�q�ӹ�{�P���X�P��K���ժ��ت��C

builder.Services.AddTransient<BankService, A_Bank>();

// �]�w Entity Framework Core �ϥ� SQL Server�A�ñq appsettings.json Ū���s�u�r��
builder.Services.AddDbContext<DB_Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("db_string")));

// ���U  �����P��@�A�ǥ� DI ���Ѹ�Ʀs���A��
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
