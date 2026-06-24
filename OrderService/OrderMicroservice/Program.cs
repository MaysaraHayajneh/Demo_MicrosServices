using Order.Application;
using Order.Application.Contracts.Clients;
using Order.Infustructure;
using Order.Infustructure.Clients;
using Order.Presentation;
using OrderMicroservice.Filters;
using Shared.Messaging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers((opt) =>
{
    opt.Filters.Add<ValidationFilter>();

}).AddApplicationPart(typeof(IPresentationAssemply).Assembly);

builder.Services
    .AddInfustructreServices(builder.Configuration)
    .AddApplicationServices()
    .AddRabbitMqMessaging(builder.Configuration);


builder.Services.AddHttpClient();
builder.Services.AddScoped<ICustomerServiceClient, CustomerServiceClient>();
builder.Services.AddScoped<IProductServiceClient, ProductServcieClient>();
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
