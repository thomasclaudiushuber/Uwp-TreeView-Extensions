using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace ThomasClaudiusHuber.Mvvm.Uwp.Extensions
{
  [ContentProperty(Name = nameof(DataTemplate))]
  public class ImplicitTemplate : DependencyObject
  {
    public string DataTypeName { get; set; }

    public DataTemplate DataTemplate { get; set; }
  }
}
