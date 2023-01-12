using MovieFinder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("https://moviefinderfro-prod-moviefinder-4it03d.mo2.mogenius.io", "http://moviefinderfro-prod-moviefinder-4it03d.mo2.mogenius.io")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMovieApiService, MovieApiService>();

builder.Services.AddHttpClient("TheMovieDatabaseApi", c => c.BaseAddress = new Uri("https://api.themoviedb.org"));

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(u => u.SwaggerEndpoint("/swagger/v1/swagger.json", "movie finder v1"));


app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
