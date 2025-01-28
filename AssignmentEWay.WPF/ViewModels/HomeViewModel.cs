using AssignmentEWay.Data.Interfaces;
using AssignmentEWay.Data.Models;
using AssignmentEWay.WPF.Commands;
using AssignmentEWay.WPF.Services;
using AssignmentEWay.WPF.Services.Interfaces;
using AssignmentEWay.WPF.States;
using MVVMEssentials.Commands;
using MVVMEssentials.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace AssignmentEWay.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        // Service to interact with EWay CRM
        private readonly IEwayCrmService _ewayCrmService;

        // Service to interact with the local database (.json file)
        private readonly IDataHistoryService _dataService;

        // Store to keep the current contact
        private readonly ContactStore _contactStore;

        // For busy indicator
        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;
                    OnPropertyChanged(nameof(IsBusy));
                }
            }
        }

        // Property to store the email address
        private string _emailAddress = string.Empty;
        public string EmailAddress
        {
            get => _emailAddress;
            set
            {
                if (_emailAddress != value)
                {
                    _emailAddress = value;
                    OnPropertyChanged(nameof(EmailAddress));
                }
            }
        }

        private string _searchEmailAddresses = string.Empty;
        public string SearchEmailAddresses
        {
            get => _searchEmailAddresses;
            set
            {
                if (_searchEmailAddresses != value)
                {
                    _searchEmailAddresses = value;
                    OnPropertyChanged(nameof(SearchEmailAddresses));
                    RecentContactsCollectionView.Refresh();
                }
            }
        }

        private HistoryContactViewModel _selectedContact;
        public HistoryContactViewModel SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;
                    OnPropertyChanged(nameof(SelectedContact));
                    // Execute the command to get the contact by Guid
                    GetContactCommand.Execute("Guid");
                }
            }
        }

        /// <summary>
        /// Collection of recent contacts 
        /// </summary>
        private ObservableCollection<HistoryContactViewModel> _recentContacts { get; set; }

        // Collection for the recent contacts to be displayed in the UI 
        // with searching
        public ICollectionView RecentContactsCollectionView { get; private set; }

        // Load the recent contacts command from the local database (.json file)
        public ICommand LoadRecentContactsCommand { get; }

        // Get the contact by email address from the EWay CRM API
        public ICommand GetContactCommand { get; }

        /// <summary>
        /// ViewModel for the message to be displayed for the user
        /// </summary>
        public MessageViewModel Message { get; set; }

        public HomeViewModel(IEwayCrmService ewayCrmService,
                             IDataHistoryService dataService,
                             ContactStore contactStore,
                             NavigateCommand<InfoContantViewModel> goToInfoContantViewModel)
        {
            // Initialize the services
            _ewayCrmService = ewayCrmService;
            _dataService = dataService;
            _contactStore = contactStore;

            Message = new MessageViewModel();
            _recentContacts = new ObservableCollection<HistoryContactViewModel>();

            // Commands
            LoadRecentContactsCommand = new LoadRecentContactsCommandAsync(this);
            GetContactCommand = new GetContactCommandAsync(_contactStore, _ewayCrmService, _dataService, this, goToInfoContantViewModel);
        }

        /// <summary>
        /// Create the HomeViewModel and load the recent contacts
        /// </summary>
        /// <param name="ewayCrmService"></param>
        /// <param name="dataService"></param>
        /// <param name="contactStore"></param>
        /// <param name="goToInfoContantViewModel"></param>
        /// <returns></returns>
        public static HomeViewModel CreateAndLoadRecentContacts(IEwayCrmService ewayCrmService,
                                                                IDataHistoryService dataService,
                                                                ContactStore contactStore,
                                                                NavigateCommand<InfoContantViewModel> goToInfoContantViewModel)
        {
            var homeViewModel = new HomeViewModel(ewayCrmService, dataService, contactStore, goToInfoContantViewModel);

            // Load the recent contacts
            homeViewModel.LoadRecentContactsCommand.Execute(null);

            return homeViewModel;
        }

        /// <summary>
        /// Load the recent contacts from the local database
        /// and set the filter for the collection view
        /// </summary>
        /// <returns></returns>
        public void LoadRecentContact()
        {

            IsBusy = true;

            try
            {
                //Get the recent contacts from the local database (.son file)
                var recentContacts =  _dataService.LoadHistory();
                if (recentContacts != null)
                {
                    _contactStore.VisitHistoryContacts = MapperToHistoryContactViewModelCollection(recentContacts);

                    if(_contactStore.VisitHistoryContacts.Count > 0)
                    {
                        // Add the recent contacts to the collection
                        _recentContacts.Clear();
                        foreach (var contact in _contactStore.VisitHistoryContacts)
                        {
                            _recentContacts.Add(contact);
                        }

                        // Set the collection view
                        RecentContactsCollectionView = CollectionViewSource.GetDefaultView(_recentContacts);

                        //Set filter for the collection view
                        RecentContactsCollectionView.Filter = (obj) =>
                        {
                            if (obj is HistoryContactViewModel contact)
                            {
                                return contact.EmailAddress.Contains(SearchEmailAddresses);
                            }

                            return false;
                        };
                    }
                }
            }
            catch (Exception)
            {
                Message.IsError = true;
                Message.Message = "Error loading recent contacts";
            }
            finally
            {
                IsBusy = false;
            }
        }

        /// <summary>
        /// Mapper to the history contact view model collection
        /// </summary>
        /// <param name="contacts"></param>
        /// <returns></returns>
        private List<HistoryContactViewModel> MapperToHistoryContactViewModelCollection(ICollection<VisitHistoryContact> contacts)
        {
            return contacts.Select(x => new HistoryContactViewModel
            {
                ItemGuid = x.ItemGuid,
                EmailAddress = x.EmailAddress,
                LastVisitDate = x.LastVisitDate,
                Count = x.Count
            }).ToList();
        }
    }
}
