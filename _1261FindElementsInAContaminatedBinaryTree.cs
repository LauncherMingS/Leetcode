using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    internal class _1261FindElementsInAContaminatedBinaryTree
    {
        public class FindElements
        {
            private HashSet<int> _valueSet;
            public FindElements(TreeNode root)
            {
                _valueSet = new HashSet<int>();
                Queue<TreeNode> queue = new Queue<TreeNode>();
                root.val = 0;
                queue.Enqueue(root);

                TreeNode node;
                while (queue.Count > 0)
                {
                    node = queue.Dequeue();

                    if (node.left != null)
                    {
                        node.left.val = 2 * node.val + 1;
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        node.right.val = 2 * node.val + 2;
                        queue.Enqueue(node.right);
                    }

                    _valueSet.Add(node.val);
                }
            }
            public bool Find(int target)
            {
                return _valueSet.Contains(target);
            }
        }
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
}