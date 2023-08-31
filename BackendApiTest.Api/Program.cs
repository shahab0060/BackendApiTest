using Autofac;
using Autofac.Extensions.DependencyInjection;
using BackendApiTest.Api.Modules;
using BackendApiTest.DataLayer.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

#region Services

#region data protection

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory() + "\\wwwroot\\Auth\\"))
    .SetApplicationName("BackendApiTestProject")
    .SetDefaultKeyLifetime(TimeSpan.FromDays(90));

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = "/login-directly";
    options.LogoutPath = "/log-out";
    options.ExpireTimeSpan = TimeSpan.FromDays(180);
    options.SlidingExpiration = true;
});

#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region swagger

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Sample Zoo Web Api",
    });
});

CorsSet(builder);

#endregion

RegisterServices(builder.Services);

#region DbContext Config

builder.Services.AddDbContext<BackendApiTestDbContext>(options =>
{
    options.UseSqlServer(connectionString: builder.Configuration.GetConnectionString("BackendApiTestConnectionString"),
    sqlServerOptions => sqlServerOptions.CommandTimeout(6000));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

#endregion

#endregion

#region App


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");
else
    app.UseExceptionHandler("/Home/Error");

//The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
#region Swagger

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetPreflightMaxAge(new TimeSpan(24, 12, 1)));


#endregion

#region AddIoC

void RegisterServices(IServiceCollection services)
{
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
         .ConfigureContainer<ContainerBuilder>(builder =>
         {
             builder.RegisterModule(new AutofacModule());
         });
}


static void CorsSet(WebApplicationBuilder builder)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("CorsPolicy",
            builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    });
}

#endregion


app.Run();

#endregion