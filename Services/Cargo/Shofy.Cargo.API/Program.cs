using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Shofy.Cargo.BusinessLayer.Abstract;
using Shofy.Cargo.BusinessLayer.Concrete;
using Shofy.Cargo.DataAccessLayer.Abstract;
using Shofy.Cargo.DataAccessLayer.Context;
using Shofy.Cargo.DataAccessLayer.EntityFramework;
using Shofy.Cargo.EntityLayer.Entities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo ";
    opt.RequireHttpsMetadata = false;
});
builder.Services.AddControllers();
builder.Services.AddScoped<ICargoOperationService, CargoOperationManager>();
builder.Services.AddScoped<ICargoOperationRepository, EfCargoOperation>();
builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerRepository, EfCustomer>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<ICompanyRepository, EfCompany>();
builder.Services.AddScoped<IDetailService, DetailManager>();
builder.Services.AddScoped<IDetailRepository, EfDetail>();


builder.Services.AddDbContext<CargoDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
