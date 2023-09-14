using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class TreeNode<T>
{
    public T Data { get; set; }
    public TreeNode<T>? Left { get; set; }
    public TreeNode<T>? Right { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public int Level { get; set; }

    public TreeNode(T data)
    {
        Data = data;
        Left = null;
        Right = null;
        Parent = null;
        Level = 0;
    }
  
}
