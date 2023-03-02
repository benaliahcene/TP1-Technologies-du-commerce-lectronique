var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddDistributedMemoryCache();
/*builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});*/
builder.Services.AddSession();
var app = builder.Build();
app.UseSession();

app.UseMvc(route => route.MapRoute("Default", "{controller=Home}/{action=Index}"));

app.UseFileServer();
app.Run();
