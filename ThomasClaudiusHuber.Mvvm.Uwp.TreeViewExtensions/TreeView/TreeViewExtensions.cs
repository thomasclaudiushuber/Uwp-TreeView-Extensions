using System;
using System.Collections;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace ThomasClaudiusHuber.Mvvm.Uwp.Extensions
{
  public class TreeViewExtensions
  {
    public static readonly DependencyProperty ItemsSourceProperty;
    public static readonly DependencyProperty TemplatesProperty;

    static TreeViewExtensions()
    {
      ItemsSourceProperty = DependencyProperty.RegisterAttached("ItemsSource", typeof(object), typeof(TreeViewExtensions), new PropertyMetadata(null, OnItemsSourceChanged));
      TemplatesProperty = DependencyProperty.RegisterAttached("Templates", typeof(ImplicitTemplateList), typeof(TreeViewExtensions), new PropertyMetadata(null));
    }

    public static object GetItemsSource(TreeView treeView)
    {
      return treeView.GetValue(ItemsSourceProperty);
    }

    public static void SetItemsSource(TreeView treeView, object value)
    {
      treeView.SetValue(ItemsSourceProperty, value);
    }

    public static ImplicitTemplateList GetTemplates(TreeView treeView)
    {
      return (ImplicitTemplateList)treeView.GetValue(TemplatesProperty);
    }

    public static void SetTemplates(TreeView treeView, ImplicitTemplateList value)
    {
      treeView.SetValue(TemplatesProperty, value);
    }

    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var treeView = d as TreeView;
      if (treeView != null)
      {
        if (e.OldValue != null)
        {
          // NOTE: Unsubscribe from any events, but as long as we don't subscribe, there's no need to unsubscribe. :)
        }
        if (e.NewValue != null)
        {
          InitializeTreeView(treeView, e.NewValue);
        }
      }
    }

    private static void InitializeTreeView(TreeView treeView, object newValue)
    {
      var templateList = TreeViewExtensions.GetTemplates(treeView);
      AddChildren(new TreeNodeParent(treeView), templateList, newValue);
    }

    private static void AddChildren(TreeNodeParent parent, ImplicitTemplateList templateList, object itemsSource)
    {
      var collection = itemsSource as IEnumerable;
      if (collection != null)
      {
        foreach (var item in collection)
        {
          var node = new TreeViewNode();
          var itemName = item.GetType().Name;
          var template = templateList?.FirstOrDefault(x => string.Equals(x.DataTypeName, itemName));
          var element = template.DataTemplate.LoadContent() as FrameworkElement;
          element.DataContext = item;
          node.Content = element;

          // Implicitly bind the TreeViewNode's IsExpanded property to an IsExpanded property of the data item (=department in this sample)
          // TODO: This is hardcoded and bad. Tried to create a Setter on the TreeViewItem Style like this:
          // <Setter Property="IsExpanded" Value="{Binding IsExpanded,Mode=TwoWay}"/>, but it didn't do the trick.
          var b = new Binding { Source = item, Path = new PropertyPath("IsExpanded"), Mode = BindingMode.TwoWay };
          BindingOperations.SetBinding(node, TreeViewNode.IsExpandedProperty, b);

          var itemsSourcePropertyName = (template as HierarchicalImplicitTemplate)?.ItemsSourcePropertyName;

          if (itemsSourcePropertyName != null)
          {
            var propertyInfo = item.GetType().GetProperty(itemsSourcePropertyName);
            if (propertyInfo == null)
            {
              throw new ArgumentException($"Property {itemsSourcePropertyName} not found on object of type {item.GetType().FullName}");
            }
            itemsSource = propertyInfo.GetValue(item);
            AddChildren(new TreeNodeParent(node), templateList, itemsSource);
          }

          parent.Children.Add(node);
        }
      }
    }
  }
}
