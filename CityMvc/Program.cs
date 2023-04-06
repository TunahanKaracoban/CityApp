using CityMvc.RepositoryMvc.Abstract;
using CityMvc.RepositoryMvc.Concrete;
using CityWebApi.Repository.Abstract;
using CityWebApi.Repository.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Configuration.AddJsonFile("appsettings.json", optional: false);
builder.Services.AddScoped<ISehirRepository, SehirRepository>();
builder.Services.AddHttpClient<ISehirRepository, SehirRepository>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["WebApiBaseUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Sehir}/{action=Index}/{id?}");

app.Run();
