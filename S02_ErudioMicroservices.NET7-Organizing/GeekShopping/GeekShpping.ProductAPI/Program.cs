using AutoMapper;
using GeekShpping.ProductAPI.Config;
using GeekShpping.ProductAPI.Interfaces;
using GeekShpping.ProductAPI.Models.Context;
using GeekShpping.ProductAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Auto Mapper
IMapper mapping = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapping);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion

#region DbContext
builder.Services.AddDbContext<MyDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region DI
builder.Services.AddScoped<IProductRepository, ProductRepository>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
