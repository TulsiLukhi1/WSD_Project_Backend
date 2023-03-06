using Microsoft.EntityFrameworkCore;
using StudentAtttendenceMS.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<SAContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("ConSAMS")));
builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy",builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("MyPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
