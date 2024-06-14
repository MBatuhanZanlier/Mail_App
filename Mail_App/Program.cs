using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAcessLayer.Abstract;
using DataAcessLayer.Context;
using DataAcessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddDbContext<MailAppContext>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>(); 
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<MailAppContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Login/Index/";
    opt.AccessDeniedPath = "/Login/Index/";
});
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
