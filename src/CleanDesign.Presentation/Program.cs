using CleanDesign.Application;
using CleanDesign.Infrastructure;
using CleanDesign.Presentation.Exceptions;
using CleanDesign.SharedKernel;
using Microsoft.OpenApi.Models;
using Serilog;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration)
);

// Add services to the container.

builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "CleanDesign", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


var app = builder.Build();

// Configure the HTTP requeCleanDesign.SharedKernel.Result<CleanDesign.Application.ViewModels.CategoryResponseViewModel>>(CleanDesign.Application.Commands.Category.CreateCategoryCommand.CreateCategoryCommandHandler) -> CleanDesign.Application.Interfaces.IUnitOfWork(CleanDesign.Infrastructure.Repositories.UnitOfWork) -> CleanDesign.Application.Interfaces.IUnitOfWorkst pipeline.

if (app.Environment.IsDevelopment())
{
}
    app.UseSwaggerUI();
    app.UseSwagger();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("AllowAllOrigin");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync().ConfigureAwait(false);
