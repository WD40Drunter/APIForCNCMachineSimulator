using CNCWebAPI.Data;
using CNCWebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/machine", async (AppDbContext db) =>
{
    var machines = await db.Machines.ToListAsync();
    return Results.Ok(machines);
})
.WithName("GetMachines")
.WithOpenApi();

app.MapPost("/api/machine", async (AppDbContext db, Machine machine) =>
{
    db.Machines.Add(machine);
    await db.SaveChangesAsync();
    return Results.Created($"/api/machine/{machine.Id}", machine);
});

app.Run();
