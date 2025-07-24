using BookShop.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;


public class UserService
{
    private readonly IMongoCollection<User> _usersCollection;
    private readonly IMongoCollection<Like> _likesCollection;


    public UserService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        var database = client.GetDatabase(settings.Value.DatabaseName);
        _usersCollection = database.GetCollection<User>("Users");
        _likesCollection = database.GetCollection<Like>("Likes");
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _usersCollection.Find(u => u.Username == username).AnyAsync();
    }

    public async Task CreateAsync(User user)
    {
        await _usersCollection.InsertOneAsync(user);
    }
    public async Task<User?> AuthenticateAsync(string username, string password)
    {
        return await _usersCollection.Find(u => u.Username == username && u.Password == password).FirstOrDefaultAsync();
    }

    public async Task<bool> AddLikeAsync(string userId, string bookId)
    {
        var exists = await _likesCollection.Find(l => l.UserId == userId && l.BookId == bookId).AnyAsync();
        if (exists) return false;

        await _likesCollection.InsertOneAsync(new Like { UserId = userId, BookId = bookId });
        return true;
    }

  

 



}
