using BtkAkademi_AI_BlogProject.WebApi.Context;
using BtkAkademi_AI_BlogProject.WebApi.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogIAContext>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<BlogIAContext>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
