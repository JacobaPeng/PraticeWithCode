using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorthms
{
    internal class BinaryTreeLevelOrderTravarsal
    {
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
    }
}
