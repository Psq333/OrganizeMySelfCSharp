using log4net;
using log4net.Config;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Caricare la configurazione di log4net dal file log4net.config
var logRepository = LogManager.GetRepository(System.Reflection.Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();


// Log di esempio (puoi sostituirlo con il log all'interno dei tuoi controller o servizi)
ILog log = LogManager.GetLogger(typeof(Program));
log.Info("Applicazione avviata!");

app.Run();
