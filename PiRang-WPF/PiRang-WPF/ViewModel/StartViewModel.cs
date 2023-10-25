using PiRang_WPF.Core;
using PiRang_WPF.Services;
using PiRang_WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiRang_WPF.ViewModel;

class StartViewModel : Core.ViewModel
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

    public RelayCommand NavigateToLoginCommand { get; set; }
    public RelayCommand NavigateToRegisterCommand { get; set; }
    public StartViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToLoginCommand = new RelayCommand(o => { Navigation.NavigateTo<LoginViewModel>();  }, o => true);
        NavigateToRegisterCommand = new RelayCommand(o => { Navigation.NavigateTo<RegisterViewModel>();  }, o => true);
        Navigation.NavigateTo<LoginViewModel>();
    }
}