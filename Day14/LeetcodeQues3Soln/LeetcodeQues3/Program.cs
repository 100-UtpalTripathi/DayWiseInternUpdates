using System;

namespace LeetcodeQues3
{
    internal class MinimumDepthOfBinaryTree
    {
        // Creating the TreeNode class
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) 
            { 
                val = x; 
            }
        }

        // helper function to calculate the minimum depth of the binary tree
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            // checking if the node is a leaf node
            if (root.left == null && root.right == null)
                return 1;

            int leftDepth = root.left != null ? MinDepth(root.left) : int.MaxValue;
            int rightDepth = root.right != null ? MinDepth(root.right) : int.MaxValue;

            return Math.Min(leftDepth, rightDepth) + 1;
        }

        public static void Main(string[] args)
        {
            // Constructing the temporary binary tree 
            TreeNode root = new TreeNode(3);        // root
            root.left = new TreeNode(9);           // left child
            root.right = new TreeNode(20);        // right child
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);

            MinimumDepthOfBinaryTree solution = new MinimumDepthOfBinaryTree();

            int minDepth = solution.MinDepth(root);

            Console.WriteLine("Minimum depth of the binary tree: " + minDepth);
        }
    }
}
