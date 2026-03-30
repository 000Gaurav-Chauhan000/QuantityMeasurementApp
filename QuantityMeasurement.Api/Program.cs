using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Business.Interfaces;
using QuantityMeasurement.Business.Services;
using QuantityMeasurement.Repository;

var builder = WebApplication.CreateBuilder(args);

// =============================
// 1. Add Controllers
// =============================
builder.Services.AddControllers();

// =============================
// 2. Add Swagger
// =============================
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// =============================
// 3. Register Services (DI)
// =============================
// ⚠ Make sure interface + class match
builder.Services.AddScoped<IQuantityAppService, QuantityAppService>();

// =============================
// 4. Register DbContext
// =============================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// =============================
// 5. Build App
// =============================
var app = builder.Build();

// =============================
// 6. Middleware
// =============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// =============================
// 7. Run
// =============================
app.Run();