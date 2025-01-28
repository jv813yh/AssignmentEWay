using AssignmentEWay.WPF.Commands;
using AssignmentEWay.WPF.States;
using MVVMEssentials.ViewModels;
using System.Windows.Input;

namespace AssignmentEWay.WPF.ViewModels
{
    public class InfoContantViewModel : ViewModelBase
    {
        private readonly ContactStore _contactStore;

        public ContactViewModel Contact
        {
            get => _contactStore.CurrentContact;
            set
            {
                _contactStore.CurrentContact = value;
                OnPropertyChanged(nameof(Contact));
            }
        }

        public ICommand NavigateBackToHomeCommand { get; }

        public InfoContantViewModel(ContactStore contactStore,
                                    NavigateCommand<HomeViewModel> navigateCommandToHome)
        {
            _contactStore = contactStore;

            NavigateBackToHomeCommand = navigateCommandToHome;
        }
    }
}
