using MVVMEssentials.ViewModels;

namespace AssignmentEWay.WPF.ViewModels
{
    public class MessageViewModel : ViewModelBase
    {
        private bool _isError = false;
        public bool IsError
        {
            get => _isError;
            set
            {
                if (_isError != value)
                {
                    _isError = value;
                    OnPropertyChanged(nameof(IsError));
                }
            }
        }

        private string _message = string.Empty;
        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }
    }
}
