using FinanceControlPro.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ----------------------
//      CORS
// ----------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowVueApp",
    policy =>
    {
         policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
    }
    );
}

);

// ----------------------
//      Swagger
// ----------------------

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new() {Title= "API Backend Proyecto", Version = "v1" });
}

);

// ----------------------
//      AutoMapper
// ----------------------
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowVueApp");

app.MapControllers();



app.Run();

