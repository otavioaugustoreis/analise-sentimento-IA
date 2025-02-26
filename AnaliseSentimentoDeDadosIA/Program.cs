using Azure.AI.TextAnalytics;
using Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var endpoint = new Uri(builder.Configuration["AzureTextAnalytics:Endpoint"]);
var credential = new AzureKeyCredential(builder.Configuration["AzureTextAnalytics:Key"]);
builder.Services.AddSingleton<TextAnalyticsClient>(new TextAnalyticsClient(endpoint, credential));


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

app.Run();
