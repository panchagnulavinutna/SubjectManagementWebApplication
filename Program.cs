using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SubjectManagementWebApplication.Models.Subjects;
using SubjectManagementWebApplication.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SubjectContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SubjectContext") ?? throw new InvalidOperationException("Connection string 'SubjectContext' not found.")));

// Add database context
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
using (var scope = app.Services.CreateScope())
{
    var servies = scope.ServiceProvider;
    var context = servies.GetRequiredService<SubjectContext>();
    context.Database.EnsureCreated();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
