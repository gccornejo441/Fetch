namespace Fetch.Mobile.ViewModel.Base;

public abstract partial class ViewModelBase : ObservableObject
{
    private long _isBusy;
    public bool IsBusy => Interlocked.Read(ref _isBusy) > 0;
}
