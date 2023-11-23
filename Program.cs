using Swashbuckle.AspNetCore.Swagger;
using TweetBook.Installers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
InstallerExtensions.InstallServicesInAssembly(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseHsts();
}

// Configure swagger
var swaggerOptions = new TweetBook.Options.SwaggerOptions();
builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

app.UseSwagger(option =>
{
    option.RouteTemplate = swaggerOptions.JsonRoute;
});

app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
