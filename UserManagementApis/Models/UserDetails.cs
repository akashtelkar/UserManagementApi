using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserManagementApis.Models
{
    public class UserDetails
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? UId { get; set; }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public AddressInfo Address { get; set; } = new AddressInfo();
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public CompanyInfo Company { get; set; } = new CompanyInfo();
    }
}

