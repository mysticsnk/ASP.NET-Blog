namespace Blog.Features.Categories;

public class CategoryService
{
    public List<Category> Categories = new();
    public int Counter;

    public Category Add(CategoryRequest req)
    {
        Category category = new Category(
            Interlocked.Increment(ref Counter),
            req.Name
        );
        
        Categories.Add(category);
        return category;
    }

    public List<Category> GetAll() => Categories;

    public void Update(int id, CategoryRequest newCategory)
    {
        Category? category = Categories.FirstOrDefault(c => c.Id == id);
        category?.Name = newCategory.Name;
    }

    public void Delete(int id)
    {
        Categories = Categories.Where(c => c.Id != id).ToList();
    }


}