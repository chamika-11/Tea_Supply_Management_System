using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TeaManagement.Data;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext with SQL Server
builder.Services.AddDbContext<TeaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add EF Core exception filter for development
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add controller support (API only, no views)
builder.Services.AddControllers();

var app = builder.Build();

//  Automatically create and seed database if not exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TeaDbContext>();
        DbInitializer.Initialize(context); // Make sure it's "DbInitializer", not "DbSetInitializer"
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating or seeding the database.");
    }
}

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
