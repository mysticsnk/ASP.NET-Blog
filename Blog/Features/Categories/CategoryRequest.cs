namespace Blog.Features.Categories;

public class CategoryRequest
{
    public string Name { get; set; }

    public CategoryRequest(string name)
    {
        Name = name;
    }
}