using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Markup;

namespace ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample
{
  public class TypeExtension : MarkupExtension
  {
    public string FullTypeName { get; set; }

  }
}
