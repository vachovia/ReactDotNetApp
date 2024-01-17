using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.AutoMapperConfig;
using ReactDotNetApp.DataAccess;
using ReactDotNetApp.Models;
using ReactDotNetApp.Repositories;
using ReactDotNetApp.Repositories.Interfaces;
using ReactDotNetApp.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddSingleton(a => new BlobServiceClient(
    builder.Configuration.GetConnectionString("AzureStorage"))
);
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
