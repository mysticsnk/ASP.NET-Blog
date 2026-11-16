using Blog.Features.Categories;

namespace Blog.Features.Posts;

public class Post
{
    public int Id { get; set; }
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public List<Category> Categories { get; set; } = new();

    public Post(int id, string slug, string title, string body)
    {
        Id = id;
        Slug = slug;
        Title = title;
        Body = body;
    }
    
    public Post(int id, string slug, string title, string body, List<Category> categories)
    {
        Id = id;
        Slug = slug;
        Title = title;
        Body = body;
        Categories = categories;
    }
}