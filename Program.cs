using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Notes.API.Notes.Domain.Repositories;
using Notes.API.Notes.Domain.Services;
using Notes.API.Notes.Mapping;
using Notes.API.Notes.Persistence.Repositories;
using Notes.API.Notes.Services;
using Notes.API.Shared.Domain.Repositories;
using Notes.API.Shared.Persistence.Context;
using Notes.API.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// Open Api Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",new OpenApiInfo
    {
        Version = "v1",
        Title="Notes.API",
        Description = "First Proyect 💥",
        Contact = new OpenApiContact
        {
            Name = "Piero Marquez",
            Url=new Uri("https://mylicense.com")
        },
        License = new OpenApiLicense
        {
            Name = "Notes License",
            Url = new Uri("https://mylicense.com")
        }
    });
    options.EnableAnnotations();
} );

//Connection String
var connectionString = builder.Configuration.GetConnectionString("NotesDBConnection");

builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
    optionsBuilder.UseMySQL(connectionString!)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());


//Lowercase URLS
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//Adding Services
//Note Services
//Notes
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();

//Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Automapper Services
builder.Services.AddAutoMapper(
    typeof(ModelToResourceProfile),
    typeof(ResourceToModelProfile));

var app = builder.Build();

//Validation for ensuring database object or itself are created.
using (var scope=app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context?.Database.EnsureCreated();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("v1/swagger.json","v1");
        options.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();