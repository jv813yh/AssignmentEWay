using AssignmentEWay.Data.Models;
using AssignmentEWay.WPF.ViewModels;

namespace AssignmentEWay.WPF.States
{
    /// <summary>
    /// This class is used to store the current contact.
    /// </summary>
    public class ContactStore
    {
        public ContactViewModel CurrentContact { get; set; }

        public List<HistoryContactViewModel> VisitHistoryContacts { get; set; }

        public ContactStore()
        {
            CurrentContact = new ContactViewModel();
            VisitHistoryContacts = new List<HistoryContactViewModel>();
        }
    }
}
