using Newtonsoft.Json;

namespace AssignmentEWay.Shared.Dtos
{
    public class ContactDto
    {
        [JsonProperty("ItemGUID")]
        public string ItemGuid { get; set; } = string.Empty;

        [JsonProperty("OwnerGUID")]
        public string OwnerGuid { get; set; } = string.Empty;

        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [JsonProperty("LastName")]
        public string LastName { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressCity")]
        public string BusinessAddressCity { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressCountryEn")]
        public string BusinessAddressCountryEn { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressPOBox")]
        public string BusinessAddressPOBox { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressPostalCode")]
        public string BusinessAddressPostalCode { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressState")]
        public string BusinessAddressState { get; set; } = string.Empty;

        [JsonProperty("BusinessAddressStreet")]
        public string BusinessAddressStreet { get; set; } = string.Empty;

        [JsonProperty("Company")]
        public string Company { get; set; } = string.Empty;

        [JsonProperty("Department")]
        public string Department { get; set; } = string.Empty;

        [JsonProperty("Email1Address")]
        public string Email1Address { get; set; } = string.Empty;

        [JsonProperty("Email2Address")]
        public string Email2Address { get; set; } = string.Empty;

        [JsonProperty("Email3Address")]
        public string Email3Address { get; set; } = string.Empty;

        [JsonProperty("HomeAddressCity")]
        public string HomeAddressCity { get; set; } = string.Empty;

        [JsonProperty("HomeAddressCountryEn")]
        public string HomeAddressCountryEn { get; set; } = string.Empty;

        [JsonProperty("HomeAddressPOBox")]
        public string HomeAddressPOBox { get; set; } = string.Empty;

        [JsonProperty("HomeAddressPostalCode")]
        public string HomeAddressPostalCode { get; set; } = string.Empty;

        [JsonProperty("HomeAddressState")]
        public string HomeAddressState { get; set; } = string.Empty;

        [JsonProperty("HomeAddressStreet")]
        public string HomeAddressStreet { get; set; } = string.Empty;

        [JsonProperty("ProfilePicture")]
        public string ProfilePictureBase64 { get; set; } = string.Empty;

        [JsonProperty("ICQ")]
        public string ICQ { get; set; } = string.Empty;

        [JsonProperty("TelephoneNumber1")]
        public string PhoneNumber1 { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; } = string.Empty;
    }
}
