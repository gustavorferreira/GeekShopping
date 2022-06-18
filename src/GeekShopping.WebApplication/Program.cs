using GeekShopping.WebApplication.Services;
using GeekShopping.WebApplication.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient<IProductService, ProductService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ServiceUrls:ProductApi"])
);
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", opttions =>
    {
        opttions.Authority = builder.Configuration["ServiceUrls:IdentityServer"];
        opttions.GetClaimsFromUserInfoEndpoint = true;
        opttions.ClientId = "geek_shopping";
        opttions.ClientSecret = "my_super_secret";
        opttions.ResponseType = "code";
        opttions.ClaimActions.MapJsonKey("role", "role", "role");
        opttions.ClaimActions.MapJsonKey("sub", "sub", "sub");
        opttions.TokenValidationParameters.NameClaimType = "name";
        opttions.TokenValidationParameters.RoleClaimType = "role";
        opttions.Scope.Add("geek_shopping");
        opttions.SaveTokens = true;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
