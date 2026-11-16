using System.Text.Json;
using Blog.Features.Categories;

namespace Blog.Features.Posts;

public class PostService
{
    public List<Post> Posts = new();
    public int Counter;

    public List<Post> GetAll() => Posts;

    public Post? GetById(int id)
    {
        return Posts.FirstOrDefault(p => p.Id == id);
    }
    
    public Post? GetBySlug(string slug)
    {
        return Posts.FirstOrDefault(p => p.Slug == slug);
    }

    public List<Post> GetByCategory(Category category)
    {
        return Posts.Where(p => p.Categories.Contains(category)).ToList();
    }

    public string GetPostForm()
    {
        return JsonSerializer.Serialize(typeof(PostRequest).GetField("Slug"));
    }

    public Post AddPost(PostRequest req)
    {
        Post post = new Post(Interlocked.Increment(ref Counter), req.Title, req.Slug, req.Body, req.Categories);
        Posts.Add(post);
        return post;
    }

    public void Update(int id, PostRequest newPost)
    {
        Post? post = Posts.FirstOrDefault(p => p.Id == id);
        post?.Title = newPost.Title;
        post?.Body = newPost.Body;
        post?.Slug = newPost.Slug;
        post?.Categories = newPost.Categories;
    }

    public void Delete(int id)
    {
        Posts = Posts.Where(p => p.Id != id).ToList();
    }

    public List<Post> QuerySearch(string search)
    {
        return Posts.Where(p => p.Title.Contains(search)).ToList();
    }
}