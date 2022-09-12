using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PermissionTest;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    private string permission;
    public string Permission
    {
        get => permission;
        set
        {
            permission = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
	{
		InitializeComponent();
        BindingContext = this;
    }

	private async void OnCounterClicked(object sender, EventArgs e)
	{
        var selectedPermission = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        Permission = selectedPermission.ToString();
    }


    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

