using MVVMEssentials.Stores;
using MVVMEssentials.ViewModels;

namespace AssignmentEWay.WPF.Services
{
    public class MyNavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _executeViewModel;

        public MyNavigationService(NavigationStore navigationStore, Func<TViewModel> executeViewModel)
        {
            _navigationStore = navigationStore;
            _executeViewModel = executeViewModel;
        }

        /// <summary>
        /// Call the executeViewModel function and set the current view model to the result
        /// </summary>
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _executeViewModel();
        }
    }
}
