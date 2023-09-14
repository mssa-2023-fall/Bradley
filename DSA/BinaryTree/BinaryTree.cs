using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BinaryTree
{
    public class BradTree<T>
    {
        public TreeNode<T>? Root { get; private set; }

        public int Count { get; private set; }

        public int CountNodes()
        {
            return CountNodes(Root);
        }

        private int CountNodes(TreeNode<T>? node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftCount = CountNodes(node.Left);
            int rightCount = CountNodes(node.Right);

            return 1 + leftCount + rightCount;
        }


        public int Depth(TreeNode<T> node)
        {
            if (node == null)
                return -1;

            int leftDepth = Depth(node.Left);
            int rightDepth = Depth(node.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        public int Depth()
        {
            return Depth(Root);
        }

        public int Min(TreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            while (node.Left != null)
            {
                node = node.Left;
            }

            return Convert.ToInt32(node.Data);
        }

        public int Min()
        {
            if (Root == null)
                throw new InvalidOperationException("Tree is empty.");

            return Min(Root);
        }

        public int Max(TreeNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            while (node.Right != null)
            {
                node = node.Right;
            }

            return Convert.ToInt32(node.Data);
        }

        public int Max()
        {
            if (Root == null)
                throw new InvalidOperationException("Tree is empty.");

            return Max(Root);
        }

        public void Add(T data)
        {
            TreeNode<T> newNode = new TreeNode<T>(data);

            if (Root == null)
            {
                Root = newNode;
                Root.Level = 0;
            }
            else
            {
                Insert(Root, newNode);
            }

            Count++;
        }

        private void Insert(TreeNode<T> parent, TreeNode<T> newNode)
        {
            if (newNode == null || parent == null)
                return;

            if (Comparer<T>.Default.Compare(newNode.Data, parent.Data) <= 0)
            {
                if (parent.Left == null)
                {
                    parent.Left = newNode;
                    newNode.Level = parent.Level + 1;
                    newNode.Parent = parent;
                }
                else
                {
                    Insert(parent.Left, newNode);
                }
            }
            else
            {
                if (parent.Right == null)
                {
                    parent.Right = newNode;
                    newNode.Level = parent.Level + 1;
                    newNode.Parent = parent;
                }
                else
                {
                    Insert(parent.Right, newNode);
                }
            }
        }
        public T Contains(T data)
        {
            return data;
        }

        public bool IsRoot(TreeNode<T> node)
        {
            return node == Root;
        }

        public bool IsLeaf(TreeNode<T> node)
        {
            return node != null && node.Left == null && node.Right == null;
        }
    }
}



/*
 * public class BinaryTree<T>
{
    public TreeNode<T>? Root { get; private set; }

    public int Count { get; private set; }

    public int Depth(TreeNode<T> node)
    {
        if (node == null)
            return -1;

        int leftDepth = Depth(node.Left);
        int rightDepth = Depth(node.Right);

        return Math.Max(leftDepth, rightDepth) + 1;
    }

    public int Depth()
    {
        return Depth(Root);
    }

    public int Min(TreeNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));

        while (node.Left != null)
        {
            node = node.Left;
        }

        return Convert.ToInt32(node.Data);
    }

    public int Min()
    {
        if (Root == null)
            throw new InvalidOperationException("Tree is empty.");

        return Min(Root);
    }

    public int Max(TreeNode<T> node)
    {
        if (node == null)
            throw new ArgumentNullException(nameof(node));

        while (node.Right != null)
        {
            node = node.Right;
        }

        return Convert.ToInt32(node.Data);
    }

    public int Max()
    {
        if (Root == null)
            throw new InvalidOperationException("Tree is empty.");

        return Max(Root);
    }

    public void Add(T data)
    {
        TreeNode<T> newNode = new TreeNode<T>(data);

        if (Root == null)
        {
            Root = newNode;
            Root.Level = 0;
        }
        else
        {
            Insert(Root, newNode);
        }

        Count++;
    }

    private void Insert(TreeNode<T> parent, TreeNode<T> newNode)
    {
        if (newNode == null || parent == null)
            return;

        if (Comparer<T>.Default.Compare(newNode.Data, parent.Data) <= 0)
        {
            if (parent.Left == null)
            {
                parent.Left = newNode;
                newNode.Level = parent.Level + 1;
                newNode.Parent = parent;
            }
            else
            {
                Insert(parent.Left, newNode);
            }
        }
        else
        {
            if (parent.Right == null)
            {
                parent.Right = newNode;
                newNode.Level = parent.Level + 1;
                newNode.Parent = parent;
            }
            else
            {
                Insert(parent.Right, newNode);
            }
        }
    }

    public bool IsRoot(TreeNode<T> node)
    {
        return node == Root;
    }

    public bool IsLeaf(TreeNode<T> node)
    {
        return node != null && node.Left == null && node.Right == null;
    }
*/