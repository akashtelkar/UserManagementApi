using MongoDB.Driver;
using Microsoft.Extensions.Options;
using UserManagementApis.Models;

namespace UserManagementApis.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<UserDetails> _userCollection;
        public UserService(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<UserDetails>(userDatabaseSettings.Value.UserCollectionName);
        }
        //To fetch all users.
        public async Task<List<UserDetails>> GetUserDetail() => await _userCollection.Find(_ => true).ToListAsync();

        //To fetch a user as per the user id.
        public async Task<UserDetails?> GetUserDetailById(int userid) => await _userCollection.Find(x => x.Id == userid).FirstOrDefaultAsync();

        //To create a new user entry.
        public async Task CreateUser(UserDetails userDetails) => await _userCollection.InsertOneAsync(userDetails);

        //To update a user as per the user id.
        public async Task UpdateUser(UserDetails userDetails, int userid) => await _userCollection.ReplaceOneAsync(x => x.Id == userid, userDetails);

        //To remove a user as per the user id.
        public async Task DeleteUser(int userid) => await _userCollection.DeleteOneAsync(x => x.Id == userid);
    }
}
