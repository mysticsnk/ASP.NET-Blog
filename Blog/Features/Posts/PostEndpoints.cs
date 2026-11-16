using Blog.Features.Categories;

namespace Blog.Features.Posts;

public static class PostEndpoints
{
    public static RouteGroupBuilder MapPostEndpoints(this RouteGroupBuilder builder)
    {
        RouteGroupBuilder posts = builder.MapGroup("/posts");
        posts.MapGet("/", GetAll);
        posts.MapGet("/id", GetById);
        posts.MapGet("/slug", GetBySlug);
        posts.MapGet("/add", GetPostForm);
        posts.MapGet("/q", QuerySearch);
        
        posts.MapPost("/add", Add);
        posts.MapPost("/edit", Update);
        posts.MapDelete("/delete", Delete);
        
        return posts;
    }

    public static IResult GetAll(PostService svc)
    {
        return Results.Ok(svc.GetAll());
    }

    public static IResult GetById(int id, PostService svc)
    {
        return Results.Ok(svc.GetById(id));
    }
    
    public static IResult GetBySlug(string slug, PostService svc)
    {
        return Results.Ok(svc.GetBySlug(slug));
    }

    public static IResult GetByCategory(Category category, PostService svc)
    {
        return Results.Ok(svc.GetByCategory(category));
    }

    public static IResult GetPostForm()
    {
        return Results.Ok("");
    }

    public static IResult Add(PostRequest req, PostService svc)
    {
        Post post = svc.AddPost(req);
        return Results.Created($"/posts/{post.Id}", post);
    }

    public static IResult Update(int id, PostRequest req, PostService svc)
    {
        svc.Update(id, req);
        return Results.Ok();
    }

    public static IResult Delete(int id, PostService svc)
    {
        svc.Delete(id);
        return Results.Ok();
    }

    public static IResult QuerySearch(string search, PostService svc)
    {
        return Results.Ok(svc.QuerySearch(search));
    }
}