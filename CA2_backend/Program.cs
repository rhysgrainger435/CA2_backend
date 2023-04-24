global using CA2_backend.Data;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Sqlite;
using CA2_backend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
	//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
	options.UseSqlite("Data Source=songs.db");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var dbContext = scope.ServiceProvider.GetService<DataContext>();
	dbContext.Database.EnsureCreated();

	if (!dbContext.Songs.Any())
	{
		// Seed the data to the database
		dbContext.Songs.AddRange(new[]
		{
			new Songs
			{
				id = 1,
				songName = "Law Of Attraction",
				artistName = "Dave",
				albumName = "We're All Alone In This Together"
			},
			new Songs
			{
				id = 2,
				songName = "Ferrari Horses",
				artistName = "D Block Europe",
				albumName = "The Blue Print - Us Vs. Them"
			},
			new Songs
			{
				id = 3,
				songName = "One More Time",
				artistName = "Daft Punk",
				albumName = "Discovery"
			}
		});

		dbContext.Artists.AddRange(new[]
		{
			new Artist
			{
				id = 1,
				artistName = "Dave",
				genre = "Pop"
			},
			new Artist
			{
				id = 2,
				artistName = "D Block Europe",
				genre = "Rap"
			},
			new Artist
			{
				id = 3,
				artistName = "Daft Punk",
				genre = "Dance"
			}
		});

		dbContext.SaveChanges();
	}
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
