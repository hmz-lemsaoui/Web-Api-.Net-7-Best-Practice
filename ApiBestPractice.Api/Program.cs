using ApiBestPractice.Api.Configuration;
using ApiBestPractice.DataServices.Data;
using ApiBestPractice.DataServices.Repositories;
using ApiBestPractice.DataServices.Repositories.Interfaces;
using  Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConfig = new DataBaseConfig();
builder.Configuration.GetSection("DatabaseConfig").Bind(dbConfig);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        options.UseSqlite(
            builder.Configuration.GetConnectionString("DefaultConnection"), action =>
            {
                action.CommandTimeout(dbConfig.TimeoutTime);
            });
        // dev environment
        options.EnableDetailedErrors(dbConfig.DetailError);
        options.EnableSensitiveDataLogging(dbConfig.SensitiveDataLogging);
    });

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
