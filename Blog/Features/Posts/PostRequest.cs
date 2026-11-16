using Blog.Features.Categories;

namespace Blog.Features.Posts;

public class PostRequest
{
    public string Slug { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public List<Category> Categories { get; set; } = new();
    
    public PostRequest(string slug, string title, string body)
    {
        Slug = slug;
        Title = title;
        Body = body;
    }

    public PostRequest(string slug, string title, string body, List<Category> categories)
    {
        Slug = slug;
        Title = title;
        Body = body;
        Categories = categories;
    }
}