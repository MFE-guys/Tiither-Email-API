using TitherEmail.IoC;

using MediatR;
using TitherEmail.Services;
using TitherEmail.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR();
builder.Services
    .AddFluentEmail(builder.Configuration["EmailSettings:From"])
    .AddRazorRenderer()
    .AddSendGridSender(builder.Configuration["EmailSettings:Key"]);
builder.Services.AddScoped<ISendGridService, SendGridService>();

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
