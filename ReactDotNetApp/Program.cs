using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using ReactDotNetApp.AutoMapperConfig;
using ReactDotNetApp.Middlewares.Services;
using ReactDotNetApp.Repositories;
using ReactDotNetApp.Repositories.Interfaces;
using ReactDotNetApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.UseAppIdentityContext(builder.Configuration);

builder.Services.UseAppAuthentication(builder.Configuration);

builder.Services.AddControllers();

builder.Services.UseCustomOpenApi();

builder.Services.AddSingleton(a => new BlobServiceClient(
    builder.Configuration.GetConnectionString("AzureStorage"))
);
builder.Services.AddSingleton<IBlobService, BlobService>();
builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddScoped<ICartItemRepository, CartItemRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>(); 
builder.Services.AddScoped<IOrderHeaderRepository, OrderHeaderRepository>();

builder.Services.AddAutoMapper(typeof(MapperConfig));

var app = builder.Build();

app.UseSwagger();

if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseSwaggerUI(s => {
        s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
        s.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();

app.UseCors(b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
