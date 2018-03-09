using Windows.UI.Xaml;

namespace ThomasClaudiusHuber.Mvvm.Uwp.Extensions
{
  public class HierarchicalImplicitTemplate : ImplicitTemplate
  {
    public string ItemsSourcePropertyName
    {
      get { return (string)GetValue(ItemsSourcePropertyNameProperty); }
      set { SetValue(ItemsSourcePropertyNameProperty, value); }
    }

    public static readonly DependencyProperty ItemsSourcePropertyNameProperty =
        DependencyProperty.Register("ItemsSourcePropertyName", typeof(string), typeof(HierarchicalImplicitTemplate), new PropertyMetadata(null));
  }
}
