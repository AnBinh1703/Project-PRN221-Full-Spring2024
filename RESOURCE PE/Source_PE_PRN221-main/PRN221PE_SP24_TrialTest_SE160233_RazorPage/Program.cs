using PRN221PE_SP24_TrialTest_SE160233_RazorPage.Ulity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDatabase();
builder.Services.AddUnitOfWork();
//builder.Services.AddDbContext<PizzaStoreContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("PizzaShopConnection")));
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set the session timeout as needed
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapRazorPages();

app.Run();
