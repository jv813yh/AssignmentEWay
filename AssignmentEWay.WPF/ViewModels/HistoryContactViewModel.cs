using MVVMEssentials.ViewModels;

namespace AssignmentEWay.WPF.ViewModels
{
    public class HistoryContactViewModel : ViewModelBase
    {
        public string ItemGuid { get; set; }
        public string EmailAddress { get; set; }
        public DateTime LastVisitDate { get; set; }
        public int Count { get; set; }
    }
}
