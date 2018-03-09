namespace ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample.Model
{
  public class WinDevDepartment : Department
  {
    private string _usedUiStack;

    public string UsedUiStack
    {
      get { return _usedUiStack; }
      set
      {
        _usedUiStack = value;
        OnPropertyChanged(nameof(UsedUiStack));
      }
    }

  }
}
