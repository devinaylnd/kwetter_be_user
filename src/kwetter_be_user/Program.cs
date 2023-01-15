using Microsoft.EntityFrameworkCore;
using kwetter_user.DbContext;
using kwetter_user.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient<IUserService, UserService>();

builder.Host.ConfigureServices((context, collection) =>
{
    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
        connectionString  ?? throw new InvalidOperationException(),
        ServerVersion.AutoDetect(connectionString)
    ));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
