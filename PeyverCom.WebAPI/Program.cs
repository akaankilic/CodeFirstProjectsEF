using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Helper;
using PeyverCom.Core.Interfaces;
using PeyverCom.Core.Models;
using PeyverCom.Core.Utilities;
using PeyverCom.Data.PeyveyComDAL;
using PeyverCom.Service;
using PeyverCom.Service.Interfaces;
using PeyverCom.Service.Repository;
using PeyverCom.Service.Mapping; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger/OpenAPI ayarlarý
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper'ý ekliyoruz.
builder.Services.AddAutoMapper(typeof(MappingProfile)); 

builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddSingleton<JWTTokenHelper>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<PeyverComDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeyverComDb"))
);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
