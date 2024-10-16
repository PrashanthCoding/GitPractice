var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MasterDataContext>(options =>
    options.UseSqlServer("YourConnectionStringHere")); // Replace with your actual connection string

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Prevents camelCasing
    });

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
