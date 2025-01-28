using AssignmentEWay.Data.Models;
using AssignmentEWay.Domain.Services.Interfaces;
using AssignmentEWay.Shared.Dtos;
using AssignmentEWay.WPF.Services.Interfaces;
using System.Diagnostics;

namespace AssignmentEWay.WPF.Services
{
    public class EwayCrmProvider : IEwayCrmService
    {
        private readonly IEwayService _ewayService;

        public EwayCrmProvider(IEwayService ewayService)
        {
            _ewayService = ewayService;
        }

        /// <summary>
        /// Get contact by email address
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public async Task<ApiResponse<Contact>> GetContactByEmailAsync(string emailAddress, string? guid = null)
        {
            try
            {
                var response = await _ewayService.GetContactByEmailAsync(emailAddress, guid);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // Log the exception ToBeDone
                throw;
            }
        }
    }
}
