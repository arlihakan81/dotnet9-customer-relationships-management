using CRM.API.Middlewares;
using CRM.Application.Features.Company.Commands.CreateCompany;
using CRM.Application.Features.Company.Commands.UpdateCompany;
using CRM.Application.Features.Company.Queries.GetCompanies;
using CRM.Application.Features.Contact.Commands.Create;
using CRM.Application.Features.Contact.Commands.Update;
using CRM.Application.Interfaces;
using CRM.Application.Mapping;
using CRM.Application.Repositories;
using CRM.Application.Validations.Company;
using CRM.Application.Validations.Contact;
using CRM.Infrastructure.Contexts;
using CRM.Infrastructure.Repositories;
using CRM.Infrastructure.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Components ??= new();

        document.Components.SecuritySchemes["Bearer"] =
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Name = "Authorization",
                Description = "JWT Bearer Token"
            };

        document.SecurityRequirements.Add(
            new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

        return Task.CompletedTask;
    });
});

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IOrganizationService, OrganizationService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<ILeadRepository, LeadRepository>();
builder.Services.AddScoped<IContactStageRepository, ContactStageRepository>();
builder.Services.AddScoped<IPipelineRepository, PipelineRepository>();
builder.Services.AddScoped<IStageRepository, StageRepository>();
builder.Services.AddScoped<IDealRepository, DealRepository>();
builder.Services.AddScoped<ISourceRepository, SourceRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
// Company Validator
builder.Services.AddScoped<IValidator<CreateCompanyCommand>, CreateCompanyValidator>();
builder.Services.AddScoped<IValidator<UpdateCompanyCommand>, UpdateCompanyValidator>();
// Contact Validator 
builder.Services.AddScoped<IValidator<CreateContactCommand>, CreateContactValidator>();
builder.Services.AddScoped<IValidator<UpdateContactCommand>, UpdateContactValidator>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly);
    config.RegisterServicesFromAssembly(typeof(GetCompaniesQueryHandler).Assembly);
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<ExceptionHandler>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
