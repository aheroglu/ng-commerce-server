using Newtonsoft.Json;
using Server.Application;
using Server.Infrastructure;
using Server.Presentation;
using Server.WebAPI;
using Server.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

builder
    .Services
    .AddApplication();

builder
    .Services
    .AddInfrastructure(builder.Configuration);

builder
    .Services
    .AddPresentation();

builder
    .Services
    .AddControllers()
    .AddApplicationPart(typeof(AssemblyMarker).Assembly)
    .AddNewtonsoftJson(action =>
    {
        action.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder
    .Services
    .AddEndpointsApiExplorer();

builder
    .Services
    .AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseMiddleware<ExceptionHandler>();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers().RequireAuthorization();

if (builder.Environment.IsDevelopment())
{
    Helper.GenerateData(app).Wait();
}

app.Run();