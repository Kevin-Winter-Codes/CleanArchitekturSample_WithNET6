using Application.Behaviors;
using Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieWebAPI.Middleware;
using Persistence;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


//Presentation Layer
var presentationAssembly = typeof(Presentation.AssemblyReference).Assembly;

// Add services to the container.
builder.Services.AddControllers().AddApplicationPart(presentationAssembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDbContext") ?? throw new InvalidOperationException("Connection string 'GeoRelationsDbContext' not found.")));

builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var applicationAssembly = typeof(Application.AssemblyReference).Assembly;

builder.Services.AddMediatR(applicationAssembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//builder.Services.AddValidatorsFromAssembly(applicationAssembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    await using ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await dbContext.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
