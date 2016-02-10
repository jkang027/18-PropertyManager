namespace PropertyManager.Api.Models
{
    public class TenantModel
    {
        public int TenantId { get; set; }
        public int? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public AddressModel PriorAddress { get; set; }
    }
}