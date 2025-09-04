using Microsoft.EntityFrameworkCore;
using PackagesBack.Core.Commands;
using PackagesBack.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePackageCommand).Assembly));
builder.Services.AddControllers();

builder.Services.AddDbContext<PackagesBackDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDatabase"));

//builder.Services.AddScoped<DbContext, PackagesBackDbContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});



var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
