using Blog.Features.Categories;

namespace Blog.Features.Posts;

public static class PostEndpoints
{
    public static RouteGroupBuilder MapPostEndpoints(this RouteGroupBuilder builder)
    {
        RouteGroupBuilder posts = builder.MapGroup("/posts");
        posts.MapGet("/", GetAll)
            .WithName("GET Posts")
            .WithSummary("Returns all posts")
            .Produces<List<Post>>();
        posts.MapGet("/id/{id:int}", GetById)
            .WithName("Get by Id")
            .WithSummary("Returns a post by it's Id")
            .Produces<Post?>();
        posts.MapGet("/slug/{slug}", GetBySlug)
            .WithName("Get by slug")
            .WithSummary("Returns a post by it's slug")
            .Produces<Post?>();
        posts.MapGet("/add", GetPostForm)
            .WithName("Get post's form")
            .WithSummary("Returns a form of what the post needs to be created.");
        posts.MapGet("/q", QuerySearch)
            .WithName("Search by title")
            .WithSummary("Accepts a query parameter to look for a certain title");
        
        posts.MapPost("/add", Add)
            .WithName("Create a post")
            .WithSummary("Creates a post using a post's request")
            .Accepts<PostRequest>("application/json")
            .Produces<Post>();
        posts.MapPost("/edit/{id:int}", Update)
            .WithName("Update a Post")
            .WithSummary("Accepts an Id, a PostRequest and updates it")
            .Accepts<PostRequest>("application/json")
            .Produces<Post>();

        posts.MapDelete("/delete/{id:int}", Delete)
            .WithName("Delete a post")
            .WithSummary("Deletes a post by it's Id");
        
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
        return Results.Ok("[\n  {\n    \"Name\": \"slug\",\n    \"Type\": \"String\",\n    \"FullType\": \"System.String\",\n    \"IsNullable\": false\n  },\n  {\n    \"Name\": \"title\",\n    \"Type\": \"String\",\n    \"FullType\": \"System.String\",\n    \"IsNullable\": false\n  },\n  {\n    \"Name\": \"body\",\n    \"Type\": \"String\",\n    \"FullType\": \"System.String\",\n    \"IsNullable\": false\n  },\n  {\n    \"Name\": \"categories\",\n    \"Type\": \"List`1\",\n    \"FullType\": \"System.Collections.Generic.List`1[[Category, Blog]]\",\n    \"IsNullable\": true\n  }\n]");
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