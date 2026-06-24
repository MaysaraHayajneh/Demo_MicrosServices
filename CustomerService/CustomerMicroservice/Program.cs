using Customer.Application;
using Customer.Infustructure;
using Customer.Presentation;
using CustomerMicroservice.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers((opt) =>
{
	opt.Filters.Add<ValidationFilter>();

}).AddApplicationPart(typeof(IPresentationAssemply).Assembly);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var logger = LoggerFactory.Create(x => x.AddConsole())
    .CreateLogger("Startup");

logger.LogInformation("ENVvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv: {env}", builder.Environment.EnvironmentName);


var cs = builder.Configuration.GetConnectionString("DefaultConnection");

logger.LogInformation("ConnectionString loaded: {exists}", !string.IsNullOrEmpty(cs));
logger.LogInformation("ConnectionString loaded: {exists}", cs);

builder.Services
	.AddInfustructreServices(builder.Configuration)
	.AddApplicationServices();

builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
