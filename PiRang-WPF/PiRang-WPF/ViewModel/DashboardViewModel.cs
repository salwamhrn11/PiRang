using PiRang_WPF.Core;
using PiRang_WPF.Services;

namespace PiRang_WPF.ViewModel;

internal class DashboardViewModel : Core.ViewModel
{
    public INavigationService _navigation;
    public INavigationService Navigation
    {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToLoginBerandaCommand { get; set; }
    public DashboardViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToLoginBerandaCommand = new RelayCommand(o => { Navigation.NavigateTo<BerandaViewModel>(); }, o => true);
        Navigation.NavigateTo<BerandaViewModel>();
    }
}
