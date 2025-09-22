using SmartLighting.Api.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://127.0.0.1:5173",
            "http://10.112.48.235:5173"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5280); // HTTP
    options.ListenAnyIP(7087, listenOptions => listenOptions.UseHttps()); // HTTPS
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseHttpsRedirection(); // disabled for local/LAN dev
app.UseCors("AllowFrontend");
app.UseAuthorization();
app.MapControllers();
app.Run();