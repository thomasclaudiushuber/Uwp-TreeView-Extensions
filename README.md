# Uwp-TreeView-Extensions
The Universal Windows Platform (UWP) contains a new TreeView control. In the current form this TreeView does not support data binding. And UWP also does not support HierarchicalDataTemplates.
This project tries to support data binding and a kind of HierarchicalDataTemplate by defining some attached properties for the TreeView in a class called TreeViewExtensions.

> Thomas Claudius Huber: "So far this repo is just a playground, everything you see here is not production ready! But feel free to use what you need."

The TreeViewExtensions class contains a bindable ItemsSource attached property that you can set on the TreeView:

```xml
    <TreeView ext:TreeViewExtensions.ItemsSource="{x:Bind ViewModel.Departments}">

    </TreeView>
```

The TreeViewExtensions class contains also a Templates attached property that you can set to an ImplicitTemplateList like here:

```xml
    <TreeView ext:TreeViewExtensions.ItemsSource="{x:Bind ViewModel.Departments}">
      <ext:TreeViewExtensions.Templates>
        <ext:ImplicitTemplateList>
          
        </ext:ImplicitTemplateList>
      </ext:TreeViewExtensions.Templates>
    </TreeView>
```

The ImplicitTemplateList can contain two kind of templates: ImplicitTemplate or HierarchicalImplicitTemplate (which is a subclass of ImplicitTemplate). It was not possible to derive these classes from DataTemplate, thus they're wrappers around a DataTemplate. Below you see two HierarchicalImplicitTemplates in action:

```xml
    <TreeView ext:TreeViewExtensions.ItemsSource="{x:Bind ViewModel.Departments}">
      <ext:TreeViewExtensions.Templates>
        <ext:ImplicitTemplateList>
          <ext:HierarchicalImplicitTemplate ItemsSourcePropertyName="Children" DataTypeName="Department">
            <DataTemplate x:DataType="model:Department">
              <CheckBox IsChecked="{x:Bind IsSelected,Mode=TwoWay}" Content="{x:Bind DepartmentName}"/>
            </DataTemplate>
          </ext:HierarchicalImplicitTemplate>
          <ext:HierarchicalImplicitTemplate ItemsSourcePropertyName="Children" DataTypeName="WinDevDepartment">
            <DataTemplate x:DataType="model:WinDevDepartment">
              <StackPanel Orientation="Horizontal" Background="LightBlue" Padding="10">
                <ToggleButton IsChecked="{x:Bind IsSelected,Mode=TwoWay}" Content="{x:Bind IsSelected.ToString(),Mode=OneWay}"/>
                <TextBlock Text="{x:Bind DepartmentName}" Margin="10 0" VerticalAlignment="Center"/>
                <TextBox Text="{x:Bind UsedUiStack,Mode=TwoWay}" Margin="10 0" VerticalAlignment="Center"/>
              </StackPanel>
            </DataTemplate>
          </ext:HierarchicalImplicitTemplate>
        </ext:ImplicitTemplateList>
      </ext:TreeViewExtensions.Templates>
    </TreeView>
```


