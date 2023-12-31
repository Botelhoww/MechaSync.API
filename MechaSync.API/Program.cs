using FluentValidation;
using MechaSync.Domain.Interface;
using MechaSync.Domain.Requests;
using MechaSync.Infrastructure;
using MechaSync.Infrastructure.Context;
using MechaSync.Services;
using MechaSync.Services.Interfaces;
using MechaSync.Services.Services;
using MechaSync.Services.Validators;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MechaSyncDbContext>(options =>
    options.UseSqlServer("Server=BOTELHO\\SQLEXPRESS;Database=MechaSync;Trusted_Connection=true;TrustServerCertificate=true"));

builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();

builder.Services.AddScoped<IValidator<RegisterRequest>, RegisterValidator>();
builder.Services.AddScoped<IValidator<LoginRequest>, LoginValidator>();

builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
// builder.Services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
// builder.Services.AddScoped<IFaturaRepository, FaturaRepository>();
// builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
// builder.Services.AddScoped<IPecaRepository, PecaRepository>();
// builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MechaSync API");
        c.DocumentTitle = "Documentação Micro-SaaS - MechaSync";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();