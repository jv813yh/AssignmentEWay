using AssignmentEWay.Data.Models;
using AssignmentEWay.Domain.Services.Interfaces;
using AssignmentEWay.Shared.Dtos;
using eWayCRM.API;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace AssignmentEWay.Domain.Services
{
    public class EwayProvider : IEwayService
    {
        public async Task<ApiResponse<Contact>> GetContactByEmailAsync(string emailAddress, string? guid = null)
        {
            if (string.IsNullOrEmpty(emailAddress) &&
                string.IsNullOrEmpty(guid))
            {
                throw new ArgumentNullException("Required fields", "Email adress or Guid can not be empy:" + nameof(emailAddress));
            }

            // Create Connection object with your credentials
            Connection wcfConnection = new Connection(
                        Constants.BaseServiceUrl,
                        Constants.TestUsername,
                        Connection.HashPassword(Constants.TestPassword)
                        );

            try
            {
                // Get contact by email with call method using Constants.GetUserByEmailFunctionName function by async 
                var response = await Task.Run(() =>
                        wcfConnection.CallMethod(Constants.GetUserByEmailFunctionName, SetJObject(emailAddress, guid)));

                if (response != null)
                {
                    // Validate response
                    string returnCode = response["ReturnCode"]?.ToString();

                    if (returnCode.Contains("rcSuccess"))
                    {
                        // Get data from response
                        string jsonData = response["Data"].ToString();
                        if (!string.IsNullOrEmpty(jsonData))
                        {
                            // Parse data to Contact object
                            List<ContactDto> contactsDto = JsonConvert.DeserializeObject<List<ContactDto>>(jsonData);
                            if (contactsDto.Count == 0)
                            {
                                return new ApiResponse<Contact>(false, null, "No contact found with the given email address.");
                            }

                            // Return ApiResponse with Contact object 
                            return new ApiResponse<Contact>(true, contactsDto[0].MapToContact());

                        }
                        else
                        {
                            return new ApiResponse<Contact>(false, null, "We received an unsuccessful response for the data, please check the input.");
                        }
                    }
                    else
                    {
                        return new ApiResponse<Contact>(false, null, "We received an unsuccessful response for the data, please check the input.");
                    }
                }

                return new ApiResponse<Contact>(false, null, "We did not receive any response while obtaining client information.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // Log the exception ToBeDone
                return new ApiResponse<Contact>(false, null, "Exception thrown while retrieving contact information");
            }
        }

        private JObject SetJObject(string emailAddress, string? giud)
        {
            if(!string.IsNullOrEmpty(giud))
            {
                return JObject.FromObject(new
                {
                    transmitObject = new
                    {
                        ItemGUID = giud
                    },
                    includeProfilePictures = true
                });
            }

            return JObject.FromObject(new
            {
                transmitObject = new
                {
                    Email1Address = emailAddress
                },
                includeProfilePictures = true
            });
        }
    }
}
