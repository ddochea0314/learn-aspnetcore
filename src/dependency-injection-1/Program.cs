var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// builder.Services.AddSingleton<GuidService>(); // 나머지 함수 주석처리 후  실행시, 2개의 GUID 모두 동일하게 표시. 새로고침해도 변하지 않음
// builder.Services.AddScoped<GuidService>(); // 나머지 함수 주석처리 후 실행시, 2개의 GUID 모두 동일하게 표시. 새로고침마다 변함
builder.Services.AddTransient<GuidService>(); // 나머지 함수 주석처리 후 실행시, 2개의 GUID 모두 다르게하게 표시. 새로고침마다 변함
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
