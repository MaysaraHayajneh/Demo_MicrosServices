using Order.Application;
using Infustructure;
using Presentation;
using ProductMicroservice.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers((opt) =>
{
	opt.Filters.Add<ValidationFilter>();

}).AddApplicationPart(typeof(IPresentationAssemply).Assembly);


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
