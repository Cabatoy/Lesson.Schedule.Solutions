using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Saas.Core.Security.Security.Encyption;
using Saas.Core.Security.Security.Security.Jwt;
using Saas.Entities.Models;
using ServiceStack;
using TokenOptions = Saas.Core.Security.Security.Security.Jwt.TokenOptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextFactory<GordionDbContext>();



var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    //(string)Convert.ChangeType(Configuration["TokenOptions:ValidAudience"], typeof(string)),
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

    };

});
builder.Services.AddDependencyResolvers(new ICoreModule[]
{
    new CoreModule()
});

builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1",new OpenApiInfo
    {
        Version = "v12",
        Title = "Saas.WebCoreApi Doc.",
        Description = "Saas.WebCoreApi",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Çahatay Özdemir",
            //Url = "",
            Email = "cahatayozdemir@gmail.com",
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,xmlFilename));
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterType<GordionDbContext>().AsSelf().As<GordionDbContext>().InstancePerLifetimeScope();
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

//debug ederken burayi kapatirsan hatalari kabak gibi gorebilirsin Çahatay
//app.ConfigureCustomExceptionMiddleware();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

//neler yapilabilir.(evde ne yapilabilir) tokenla yetkiyi yakalmis olucaz
app.UseAuthentication();

//anahtar(eve giris) giris bilgileri ile login saglamak icin
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
