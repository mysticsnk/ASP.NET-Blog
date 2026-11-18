using Blog.Features.Categories;
using Blog.Features.Posts;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<PostService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/openapi/{documentName}.json");
    app.MapScalarApiReference("/scalar", options =>
    {
        options.WithTitle("Scalar test for Blog")
            .SortOperationsByMethod()
            .WithOpenApiRoutePattern("/openapi/{documentName}.json");
    });
}

app.MapGet("/about", () => "Hello World!");
var api = app.MapGroup("/api/v1");
api.MapPostEndpoints();
api.MapCategoryEndpoints();

app.Run();