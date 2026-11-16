using Microsoft.AspNetCore.Http.HttpResults;

namespace Blog.Features.Categories;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this RouteGroupBuilder group)
    {
        var categories = group.MapGroup("/categories");
        categories.MapGet("/", GetAll);
        categories.MapPost("/add", Add);
        categories.MapPost("/edit", Update);
        categories.MapDelete("/delete", Delete);
        return categories;
    }

    public static IResult GetAll(CategoryService svc)
    {
        return Results.Ok(svc.GetAll());
    }

    public static IResult Add(CategoryRequest req, CategoryService svc)
    {
        Category category = svc.Add(req);
        return Results.Created($"categories/{category.Id}", category);
    }

    public static IResult Update(int id, CategoryRequest req, CategoryService svc)
    {
        svc.Update(id, req);
        return Results.Ok();
    }

    public static IResult Delete(int id, CategoryService svc)
    {
        svc.Delete(id);
        return Results.Ok();
    }
}
