using Microsoft.EntityFrameworkCore;
using PeyverCom.Core.Helper;
using PeyverCom.Core.Interfaces;
using PeyverCom.Core.Utilities;
using PeyverCom.Data.PeyveyComDAL;
using PeyverCom.Service.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPasswordHasher,PasswordHasher>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton(new JWTTokenHelper("YourSecretKey", "YourIssuer", "YourAudience"));

builder.Services.AddDbContext<PeyverComDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PeyverComDb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
