namespace UserManagementApis.Models
{
    public class AddressInfo
    { 
        public string? Street { get; set; }
        public string? Suite { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public GeoInfo Geo { get; set; } = new GeoInfo();
    }
}
