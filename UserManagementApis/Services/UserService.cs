using MongoDB.Driver;
using Microsoft.Extensions.Options;
using UserManagementApis.Models;

namespace UserManagementApis.Services
{
    public class UserService
    {
        private readonly IMongoCollection<UserDetails> _userCollection;
        public UserService(IOptions<UserDatabaseSettings> userDatabaseSettings)
        {
            var mongoClient = new MongoClient(userDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(userDatabaseSettings.Value.DatabaseName);
            _userCollection = mongoDatabase.GetCollection<UserDetails>(userDatabaseSettings.Value.UserCollectionName);
        }
        //To fetch all user details.
        public async Task<List<UserDetails>> GetUserDetails() => await _userCollection.Find(_ => true).ToListAsync();

        //To fetch user details as per the Id.
        public async Task<UserDetails?> GetUserDetailsById(int id) => await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        //To create new user entry.
        public async Task CreateUser(UserDetails userDetails) => await _userCollection.InsertOneAsync(userDetails);

        //To update user details as per the Id.
        public async Task UpdateUser(UserDetails userDetails, int id) => await _userCollection.ReplaceOneAsync(x => x.Id == id, userDetails);

        //To remove user details as per the Id.
        public async Task DeleteUser(int id) => await _userCollection.DeleteOneAsync(x => x.Id == id);
    }
}
