using ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample.ViewModel;
using Windows.UI.Xaml.Controls;

namespace ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      InitializeComponent();
      ViewModel = new MainViewModel();
    }

    internal MainViewModel ViewModel { get; }
  }
}
