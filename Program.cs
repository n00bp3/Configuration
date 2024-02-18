using ConfgApi.Logic;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//binding values from appsettings.json
//builder.Services.Configure<AppOptions>(
//    builder.Configuration.GetSection(nameof(AppOptions))
//    );
builder.Services.ConfigureOptions<AppOptionSetup>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//app.MapGet("options", (IOptions<AppOptions> options,
//    IOptionsSnapshot<AppOptions> optionsSnapshot,       //configured at scoped service, will change value as per request
//    IOptionsMonitor<AppOptions> optionsMonitor)         //singleton, but will always give current value irrespective to request
//    =>
//{
//    var response = new
//    {
//        OptonsValue = options.Value.EgValue,
//        SnapshotValue = optionsSnapshot.Value.EgValue,
//        MonitorValue = optionsMonitor.CurrentValue.EgValue
//    };
//    return Results.Ok(response);
//}
//);

app.Run();
