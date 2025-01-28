namespace AssignmentEWay.Data.Models
{
    public class Contact 
    {
        public string ItemGuid { get; set; }
        public string OwnerGuid { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string? BusinessAddressCity { get; set; } 
        public string? BusinessAddressCountryEn { get; set; } 
        public string? BusinessAddressPOBox { get; set; } 
        public string? BusinessAddressPostalCode { get; set; } 
        public string? BusinessAddressState { get; set; } 
        public string? BusinessAddressStreet { get; set; } 
        public string? Company { get; set; }
        public string? Department { get; set; } 
        public string? Email1Address { get; set; } 
        public string? Email2Address { get; set; } 
        public string? Email3Address { get; set; } 
        public string? HomeAddressCity { get; set; } 
        public string? HomeAddressCountryEn { get; set; } 
        public string? HomeAddressPOBox { get; set; } 
        public string? HomeAddressPostalCode { get; set; } 
        public string? HomeAddressState { get; set; } 
        public string? HomeAddressStreet { get; set; }
        public string? ProfilePictureBase64 { get; set; }
        public string? ICQ { get; set; } 
        public string? PhoneNumber1 { get; set; } 
        public string? Title { get; set; } 
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
