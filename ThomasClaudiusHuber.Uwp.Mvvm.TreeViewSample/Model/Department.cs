using System.Collections.ObjectModel;

namespace ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample.Model
{

  public class Department : Observable
  {
    private string _departmentName;
    private bool _isSelected;

    public Department()
    {
      Children = new ObservableCollection<Department>();
    }

    public ObservableCollection<Department> Children { get; set; }

    public string DepartmentName
    {
      get { return _departmentName; }
      set
      {
        _departmentName = value;
        OnPropertyChanged(nameof(DepartmentName));
      }
    }

    public bool IsSelected
    {
      get { return _isSelected; }
      set
      {
        _isSelected = value;
        OnPropertyChanged(nameof(IsSelected));
      }
    }

    private bool _isExpanded;

    public bool IsExpanded
    {
      get { return _isExpanded; }
      set
      {
        _isExpanded = value;
        OnPropertyChanged(nameof(IsExpanded));
      }
    }

  }
}
