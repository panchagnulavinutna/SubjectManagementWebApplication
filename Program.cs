using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubjectManagementWebApplication.Models.Subjects;
using SubjectManagementWebApplication.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Add Authentication and Authorization
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

// 🔹 Add Database Context (Choose the one actually needed)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddRazorPages();
builder.Services.AddDbContext<SubjectManagementWebApplicationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'SubjectManagementWebApplicationContext' not found.")));

var app = builder.Build();

// 🔹 Configure Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

// 🔹 Apply Migrations (Instead of `EnsureCreated()`)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate();  // ✅ Apply Migrations
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
