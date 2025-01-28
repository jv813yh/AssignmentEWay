using AssignmentEWay.WPF.ViewModels;
using MVVMEssentials.Commands;
using System.Diagnostics;

namespace AssignmentEWay.WPF.Commands
{
    public class LoadRecentContactsCommandAsync : CommandBase
    {
        private readonly HomeViewModel _homeViewModel;

        public LoadRecentContactsCommandAsync(HomeViewModel homeViewModel)
        {
            _homeViewModel = homeViewModel;
        }

        public override void Execute(object parameter)
        {
            try
            {
                _homeViewModel.LoadRecentContact();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
