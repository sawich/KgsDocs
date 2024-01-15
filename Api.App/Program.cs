using Api.App.Common;
using Api.Infrastructure.Extensions;
using Api.Infrastructure.Mapper.Extensions;
using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<DocumentSchema>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();
builder.Services.AddPersistent(builder.Environment);

builder.Services
    .AddAuthorization()
    .AddIdentityApiEndpoints<UserModel>()
    .AddEntityFrameworkStores<PersistentContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapIdentityApi<UserModel>();
app.MapControllers();

app.Run();
