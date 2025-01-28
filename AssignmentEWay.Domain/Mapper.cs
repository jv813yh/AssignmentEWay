using AssignmentEWay.Data.Models;
using AssignmentEWay.Shared.Dtos;
using System.Text;

namespace AssignmentEWay.Domain
{
    /// <summary>
    /// Extension methods for mapping between domain models and DTOs.
    /// </summary>
    public static class Mapper
    {
        public static Contact MapToContact(this ContactDto contactDto)
        {
            return new Contact
            {
                ItemGuid = contactDto.ItemGuid,
                OwnerGuid = contactDto.OwnerGuid,
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName,
                Email1Address = contactDto.Email1Address,
                Email2Address = contactDto.Email2Address,
                Email3Address = contactDto.Email3Address,
                BusinessAddressCity = contactDto.BusinessAddressCity,
                BusinessAddressPOBox = contactDto.BusinessAddressPOBox,
                BusinessAddressCountryEn = contactDto.BusinessAddressCountryEn,
                BusinessAddressPostalCode = contactDto.BusinessAddressPostalCode,
                BusinessAddressState = contactDto.BusinessAddressState,
                BusinessAddressStreet = contactDto.BusinessAddressStreet,
                Company = contactDto.Company,
                Department = contactDto.Department,
                HomeAddressCity = contactDto.HomeAddressCity,
                HomeAddressCountryEn = contactDto.HomeAddressCountryEn,
                HomeAddressPOBox = contactDto.HomeAddressPOBox,
                HomeAddressPostalCode = contactDto.HomeAddressPostalCode,
                HomeAddressState = contactDto.HomeAddressState,
                HomeAddressStreet = contactDto.HomeAddressStreet,
                PhoneNumber1 = contactDto.PhoneNumber1,
                ProfilePictureBase64 = contactDto.ProfilePictureBase64,
                ICQ = contactDto.ICQ,
                Title = contactDto.Title,
            };
        }

        public static ContactDto MapToContactDto(this Contact contact)
        {
            return new ContactDto
            {
                ItemGuid = contact.ItemGuid,
                OwnerGuid = contact.OwnerGuid,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email1Address = contact.Email1Address,
                Email2Address = contact.Email2Address,
                Email3Address = contact.Email3Address,
                BusinessAddressCity = contact.BusinessAddressCity,
                BusinessAddressPOBox = contact.BusinessAddressPOBox,
                BusinessAddressCountryEn = contact.BusinessAddressCountryEn,
                BusinessAddressPostalCode = contact.BusinessAddressPostalCode,
                BusinessAddressState = contact.BusinessAddressState,
                BusinessAddressStreet = contact.BusinessAddressStreet,
                Company = contact.Company,
                Department = contact.Department,
                HomeAddressCity = contact.HomeAddressCity,
                HomeAddressCountryEn = contact.HomeAddressCountryEn,
                HomeAddressPOBox = contact.HomeAddressPOBox,
                HomeAddressPostalCode = contact.HomeAddressPostalCode,
                HomeAddressState = contact.HomeAddressState,
                HomeAddressStreet = contact.HomeAddressStreet,
                PhoneNumber1 = contact.PhoneNumber1,
                ProfilePictureBase64 = contact.ProfilePictureBase64,
                ICQ = contact.ICQ,
                Title = contact.Title,
            };
        }
    }
}
