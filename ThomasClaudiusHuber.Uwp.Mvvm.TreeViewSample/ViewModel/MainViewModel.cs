using System.Collections.ObjectModel;
using System.Linq;
using ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample.Model;

namespace ThomasClaudiusHuber.Uwp.Mvvm.TreeViewSample.ViewModel
{
  class MainViewModel
  {
    public MainViewModel()
    {
      Departments = new ObservableCollection<Department>
      {
        new Department { DepartmentName ="Root",
          Children=new ObservableCollection<Department>
          {
              new WinDevDepartment{DepartmentName="Windows 10",UsedUiStack="UWP",
                Children=new ObservableCollection<Department>
                {
                  new Department{DepartmentName="Finance"},
                  new Department{DepartmentName="Sales"},
                     new WinDevDepartment{DepartmentName="WinDev", UsedUiStack="WinForms"},
                }},
              new Department{ DepartmentName="Proven Tech",
                 Children=new ObservableCollection<Department>
                {
                  new Department{DepartmentName="Surface"},
                  new Department{DepartmentName="Dial"},
                  new Department{DepartmentName="Pen"},
                  new WinDevDepartment{DepartmentName="XAML Magic",UsedUiStack="WPF"}
                }
              }
          }
        }
      };

      SelectedDepartments = new ObservableCollection<Department>();
    }

    public ObservableCollection<Department> Departments { get; }

    public ObservableCollection<Department> SelectedDepartments { get; }

    public void RefreshSelectedDepartments()
    {
      SelectedDepartments.Clear();
      void CheckSelection(Department department)
      {
        if (department.IsSelected)
        {
          SelectedDepartments.Add(department);
        }
        foreach (var childDepartment in department.Children)
        {
          CheckSelection(childDepartment);
        }
      }

      foreach (var item in Departments)
      {
        CheckSelection(item);
      }
    }

    public void ToogleRootDepartment()
    {
      var rootDepartment = Departments.First();
      rootDepartment.IsExpanded = !rootDepartment.IsExpanded;
    }
  }
}
