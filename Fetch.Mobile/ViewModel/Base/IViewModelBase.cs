using Fetch.Mobile.Services;

namespace Fetch.Mobile.ViewModel.Base;

public interface IViewModelBase : IQueryAttributable
{
    public INavigationService NavigationService { get; set; }
    public IAsyncRelayCommand InitializeAsyncCommand { get; }

    public bool IsBusy { get; }

    public bool IsInitialized { get; }
    Task InitializedAsync();

}
