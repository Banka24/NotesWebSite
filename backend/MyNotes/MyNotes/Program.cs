using MyNotes.DataAccess;

namespace MyNotes
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen();
			builder.Services.AddScoped<NotesDbContext>();
			builder.Services.AddCors(option =>
			{
				option.AddDefaultPolicy(policy =>
				{
					policy.WithOrigins("http://localhost:3000");
					policy.AllowAnyHeader();
					policy.AllowAnyMethod();
				});
			});

			var app = builder.Build();
			using (var scope = app.Services.CreateScope())
			{
				using var dbContext = scope.ServiceProvider.GetRequiredService<NotesDbContext>();
				dbContext.Database.EnsureCreated();
			}

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseCors();
			app.MapControllers();

			app.Run();
		}
	}
}