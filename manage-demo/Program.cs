using Autofac.Extensions.DependencyInjection;
using Autofac;
using manage_demo.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Autofac.Core;
using manage_demo.Service.Users;
using manage_demo.Service.Login;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddScoped<ILoginAppService, LoginAppService>();
//builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS");
    });
});

// Add services to the container.
/*
builder.Services.AddDbContext<DataContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("Default");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
});*/

builder.Services.AddAutofac();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{   // 注入Service程序集
    string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
    builder.RegisterAssemblyTypes(Assembly.Load(assemblyName))
    .AsImplementedInterfaces()
    .InstancePerDependency();
});

/*
builder.Services.AddCors(options =>
{
    options.AddPolicy("any", builder =>
    {
        builder.AllowAnyOrigin() //允许任何来源的主机访问
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();//指定处理cookie
    });
});
*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization(); 

app.MapControllers();

app.Run();
