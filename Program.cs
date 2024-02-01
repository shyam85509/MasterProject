var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//sesson midleware configuration ======start====
builder.Services.AddSession(
    options =>
    {
        options.IdleTimeout = TimeSpan.FromSeconds(100);
        options.Cookie.IsEssential = true;
    }
    );
builder.Services.AddHttpContextAccessor();
//sesson midleware configuration ======end====

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

//sesson use 
app.UseSession();


app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MasterCRUD}/{action=Login}/{id?}");

app.Run();
