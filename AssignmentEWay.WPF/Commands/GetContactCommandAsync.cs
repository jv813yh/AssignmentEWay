using AssignmentEWay.Data.Interfaces;
using AssignmentEWay.Data.Models;
using AssignmentEWay.Shared.Dtos;
using AssignmentEWay.WPF.Services.Interfaces;
using AssignmentEWay.WPF.States;
using AssignmentEWay.WPF.ViewModels;
using eWay.Core.Net;
using MVVMEssentials.Commands;
using System.ComponentModel;
using System.Diagnostics;

namespace AssignmentEWay.WPF.Commands
{
    public class GetContactCommandAsync : AsyncCommandBase, IDisposable
    {
        private readonly ContactStore _contactStore;
        private readonly IEwayCrmService _ewayCrmService;
        private readonly IDataHistoryService _dataHistoryService;
        private readonly HomeViewModel _homeViewModel;
        private readonly NavigateCommand<InfoContantViewModel> _goToInfoContantViewModel;

        public GetContactCommandAsync(ContactStore contactStore,
                                      IEwayCrmService ewayCrmService,
                                      IDataHistoryService dataService,
                                      HomeViewModel homeViewModel,
                                      NavigateCommand<InfoContantViewModel> goToInfoContantViewModel)
        {
            _contactStore = contactStore;
            _ewayCrmService = ewayCrmService;
            _dataHistoryService = dataService;
            _homeViewModel = homeViewModel;
            _goToInfoContantViewModel = goToInfoContantViewModel;

            // Subscribe to the PropertyChanged event of the HomeViewModel
            _homeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_homeViewModel.EmailAddress))
            {
                OnCanExecuteChanged();
            }
        }

        /// <summary>
        /// Check if the command can be executed
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter)
         => !string.IsNullOrWhiteSpace(_homeViewModel.EmailAddress);

        /// <summary>
        /// Execute the command
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected async override Task ExecuteAsync(object parameter)
        {
            
            ApiResponse<Contact> response;

            _homeViewModel.IsBusy = true;
            _homeViewModel.Message.IsError = false;
            _homeViewModel.Message.Message = string.Empty;

            // Check if the email address is valid
            // Very simple validation, it should be improved
            if (!_homeViewModel.EmailAddress.Contains("@") &&
                parameter is null)
            {
                // Set the message to be displayed
                _homeViewModel.Message.IsError = true;
                _homeViewModel.Message.Message = "Your email address is invalid";
                _homeViewModel.IsBusy = false;
                return;
            }

            try
            {

                if(parameter is string value && 
                        value.Contains("Guid"))
                {
                    // Fetch the contact by guid
                    response = await _ewayCrmService.GetContactByEmailAsync(_homeViewModel.EmailAddress, _homeViewModel.SelectedContact.ItemGuid);
                }
                else
                {
                    // Fetch the contact by email address
                    response = await _ewayCrmService.GetContactByEmailAsync(_homeViewModel.EmailAddress);
                }

                if (response.IsSuccess &&
                        response.Data != null)
                {
                    // Set the current contact
                    _contactStore.CurrentContact = AutoMapperToContactViewModel(response.Data);

                    // Check if the contact is already in the recent contacts
                    var currentContact = _contactStore
                                         .VisitHistoryContacts
                                         .FirstOrDefault(x => x.EmailAddress == _contactStore.CurrentContact.EmailAddress);

                if (currentContact == null)
                {
                    HistoryContactViewModel historyContact = new HistoryContactViewModel
                    {
                        ItemGuid = _contactStore.CurrentContact.ItemGuid,
                        EmailAddress = _contactStore.CurrentContact.EmailAddress,
                        LastVisitDate = DateTime.Now,
                        Count = 1
                    };

                    // Insert the contact to the recent contacts
                    _contactStore.VisitHistoryContacts.Add(historyContact);
                }
                else
                {
                    currentContact.LastVisitDate = DateTime.Now;
                    currentContact.Count++;
                    // Update the contact in the recent contacts
                    _contactStore.VisitHistoryContacts.Remove(currentContact);
                    _contactStore.VisitHistoryContacts.Add(currentContact);
                }

                    // Save the contact to the local database
                    _dataHistoryService.SaveHistory(MapperToHistoryContactCollection(_contactStore.VisitHistoryContacts));

                    // Navigation to the InfoContactView
                    _goToInfoContantViewModel.Execute(null);
                }
                
                else
                {
                    // Set the message to be displayed
                    _homeViewModel.Message.IsError = true;
                    _homeViewModel.Message.Message = response.ErrorMessage;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                // Log the exception ToBeDone
                // Set the message to be displayed
                _homeViewModel.Message.IsError = true;
                _homeViewModel.Message.Message = "An error occurred while fetching the contact";
            }
            finally
            {
                _homeViewModel.IsBusy = false;
                Dispose();
            }
        }

        /// <summary>
        /// Dispose the event
        /// </summary>
        public void Dispose()
        {
            _homeViewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }


        private ContactViewModel AutoMapperToContactViewModel(Contact contact)
        {
            // Get the email address 
            // We just use the first email address
            string emailAddresses = string.Empty;
            if (!string.IsNullOrEmpty(contact.Email1Address))
            {
                emailAddresses = contact.Email1Address;
            }
            else if (!string.IsNullOrEmpty(contact.Email2Address))
            {
                emailAddresses = contact.Email2Address;
            }
            else if (!string.IsNullOrEmpty(contact.Email3Address))
            {
                emailAddresses = contact.Email3Address;
            }

            return new ContactViewModel
            {
                
                ItemGuid = contact.ItemGuid,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                EmailAddress = emailAddresses,
                BusinessAddressCity = contact.BusinessAddressCity,
                BusinessAddressStreet = contact.BusinessAddressStreet,
                BusinessAddressPostalCode = contact.BusinessAddressPostalCode,
                BusinessAddressState = contact.BusinessAddressState,
                Company = contact.Company,
                Department = contact.Department,
                HomeAddressCity = contact.HomeAddressCity,
                HomeAddressStreet = contact.HomeAddressStreet,
                HomeAddressState = contact.HomeAddressState,
                Title = contact.Title,
                PhoneNumber1 = contact.PhoneNumber1,
                ProfilePictureBase64 = contact.ProfilePictureBase64
            };
        }

        /// <summary>
        /// Mapper to the history contact collection
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        private List<VisitHistoryContact> MapperToHistoryContactCollection(ICollection<HistoryContactViewModel> contacts)
        {
            return contacts.Select(x => new VisitHistoryContact
            {
                ItemGuid = x.ItemGuid,
                EmailAddress = x.EmailAddress,
                LastVisitDate = x.LastVisitDate,
                Count = x.Count
            }).ToList();
        }
    }
}
