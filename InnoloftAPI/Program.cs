using AutoMapper;
using FluentAssertions;
using FluentAssertions.Common;
using InnoloftAPI.Core.Interface;
using InnoloftAPI.Data.ContextData;
using InnoloftAPI.Data.EventRepository;
using InnoloftAPI.Mapper;
using InnoloftAPI.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(x => x.EnableEndpointRouting = false);
builder.Services.AddTransient<IEventService, EventService>();
builder.Services.AddTransient<IEventEventRepository, EventRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDistributedMemoryCache();

builder.Services.AddScoped<ICacheService, CacheService>();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")); // Use SQLite connection string
});

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ProfileMapping());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
