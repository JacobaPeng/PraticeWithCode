using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms
{
    internal class BinaryTreeInorderTraversal
    {
        //跌代法，使用栈
        public IList<int> InorderTraversal(TreeNode root)
        {
            
            IList<int> results = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count() > 0)
            {

                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;

                }
                root = stack.Pop();
                results.Add(root.val);
                root = root.right;
            }
            return results;
        }
        //
        //IList<int> results = new List<int>();
        //public IList<int> InorderTraversal(TreeNode root)
        //{
        //    InOrder(root);
        //    return results;
        //}
        //public void InOrder(TreeNode root)
        //{

        //    if (root == null) return;
        //    InorderTraversal(root.left);
        //    results.Add(root.val);
        //    InorderTraversal(root.right);
        //}

    }

    // Definition for a binary tree node.
    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
                 }
  }

}
