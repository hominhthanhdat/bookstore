
using Microsoft.EntityFrameworkCore;
using BookStore.Converters;
using BookStore.Models;
using BookStore.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<BookService,BookServiceImplement>();
builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new DateConvert());
});
builder.Services.AddDbContext<DatabaseContext>(options => options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddControllers();
var app = builder.Build();
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.MapControllers();
app.Run();



