using Microsoft.EntityFrameworkCore;
using MiddleWareApi.Data;
using MiddleWareApi.Filters;
using MiddleWareApi.MiddleWares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(option =>
option.Filters.Add<LogActivityFilter>()
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<LimitingRequestMiddleWare>();
app.UseMiddleware<ProfilingMiddleWare>();

app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllers();

app.Run();
