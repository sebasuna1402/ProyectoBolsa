

using Microsoft.EntityFrameworkCore;
using DataAccess;
using Services;
using ProyectoBolsa.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataAccess(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

//Para SQL server
builder.Services.AddDbContext<MyApiContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("MyApiContext") ?? throw new InvalidOperationException("Connection string 'MyApiContext' not found.")));


//builder.Services.AddDbContext<MyApiContext>(options =>
//options.UseInMemoryDatabase("ExamenBD"));


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().WithMethods().WithHeaders();
                      });
});


//builder.Services.AddControllers();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);


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

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
