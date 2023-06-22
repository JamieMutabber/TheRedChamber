using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRedChamber.Data;
using TheRedChamber.Helpers;
using TheRedChamber.Interfaces;
using TheRedChamber.Model;
using TheRedChamber.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add photoservice 
builder.Services.AddScoped<IPhotoService, PhotoService>();

// Add cloudinary services
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));

// Add connectionstring for DB connection 
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("redchamberDb"));
});

// Add identity framework functionalities
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

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
