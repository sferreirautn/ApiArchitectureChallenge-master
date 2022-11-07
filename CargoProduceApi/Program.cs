using CargoProduceApi.Middleware;
using DataAccess.Context;
using DataAccess.Context.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.IncludeXmlComments(AppContext.BaseDirectory + @"\CargoProduceApi.xml"));

builder.Services.AddDbContext<ClientDbContext>(options => { options.UseInMemoryDatabase(databaseName: "Client_DB"); });

IoC.AddDependency(builder.Services);
Mapper.AddAutoMapper(builder.Services);

var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ClientDbContext>();
    DbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CargoProduceApi");
    });
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
