using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiUrl = "https://jsonplaceholder.typicode.com/posts";

    static async Task Main()
    {
        Console.WriteLine("Fetching data...");
        await GetPosts();

        Console.WriteLine("\nCreating a new post...");
        await CreatePost();

        Console.WriteLine("\nUpdating an existing post...");
        await UpdatePost(1); // Updating post with ID 1

        Console.WriteLine("\nDeleting a post...");
        await DeletePost(1); // Deleting post with ID 1


    }

    // GET request: Fetch posts
    private static async Task GetPosts()
    {
        HttpResponseMessage response = await client.GetAsync(apiUrl);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Response:\n" + responseBody.Substring(0, 200) + "..."); // Displaying only first 200 chars
    }

    // POST request: Create a new post
    private static async Task CreatePost()
    {
        var newPost = new
        {
            title = "New Post",
            body = "This is a sample post created using a POST request.",
            userId = 1
        };

        StringContent content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(newPost),
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await client.PostAsync(apiUrl, content);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Created Post:\n" + responseBody);
    }

    // PUT request: Update an existing post
    private static async Task UpdatePost(int postId)
    {
        var updatedPost = new
        {
            id = postId,
            title = "Updated Title",
            body = "Updated content using PUT request.",
            userId = 1
        };

        StringContent content = new StringContent(
            System.Text.Json.JsonSerializer.Serialize(updatedPost),
            Encoding.UTF8,
            "application/json"
        );

        HttpResponseMessage response = await client.PutAsync($"{apiUrl}/{postId}", content);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Updated Post:\n" + responseBody);
    }

    // DELETE request: Delete a post
    private static async Task DeletePost(int postId)
    {
        HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/{postId}");
        response.EnsureSuccessStatusCode();
        Console.WriteLine($"Post {postId} deleted successfully.");
    }
}
