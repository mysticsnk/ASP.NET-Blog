using Blog.Features.Categories;
using Blog.Features.Posts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PostService>();
builder.Services.AddSingleton<CategoryService>();
var app = builder.Build();

app.MapGet("/about", () => "Hello World!");
var api = app.MapGroup("/api/v1");
api.MapPostEndpoints();
api.MapCategoryEndpoints();

app.Run();