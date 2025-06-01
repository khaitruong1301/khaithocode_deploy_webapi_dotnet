using khaithocode_deploy_webapi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.WebHost.UseUrls("http://+:80");
}

//DI controller
builder.Services.AddControllers();

builder.Services.AddSwaggerGen();


string? connectionString = builder.Configuration.GetConnectionString("Connection");

builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(connectionString);
});

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();



app.Run();

