using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace ThomasClaudiusHuber.Mvvm.Uwp.Extensions
{
  /// <summary>
  /// Abstraction for TreeView and TreeViewNode, as they don't share the same interface for their children
  /// </summary>
  public class TreeNodeParent
  {
    private readonly TreeView _treeView;
    private readonly TreeViewNode _treeViewNode;

    public TreeNodeParent(TreeView treeView)
    {
      _treeView = treeView;
    }
    public TreeNodeParent(TreeViewNode treeViewNode)
    {
      _treeViewNode = treeViewNode;
    }

    public IList<TreeViewNode> Children
    {
      get
      {
        return _treeView != null
          ? _treeView.RootNodes
          : _treeViewNode.Children;
      }
    }
  }
}
