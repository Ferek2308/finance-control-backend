using FinanceControlPro.Infrastructure.Persistence;
using FinanceControlPro.Infrastructure.Persistence.Repositories;
using FinanceControlPro.Application.Auditing;
using FinanceControlPro.API.Middlewares;
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


// ----------------------
//      DbContext
// ----------------------

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ----------------------
//      Dependency Injection
// ----------------------
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IAuditService, AuditService>();
builder.Services.AddScoped<DebugAuditService>();


var app = builder.Build();




using (var scope = app.Services.CreateScope())
{
    var debugAudit = scope.ServiceProvider.GetRequiredService<DebugAuditService>();

    await debugAudit.LogSystemStartupAsync(
        ip: "SYSTEM",
        userAgent: "APPLICATION_STARTUP"
    );
}



// ----------------------
//      Pipeline HTTP
// ----------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowVueApp");


//Middleware de auditoría (antes de MapControllers)
app.UseMiddleware<AuditMiddleware>();


app.MapControllers();



app.Run();

