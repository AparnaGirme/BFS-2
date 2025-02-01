/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        if (root == null)
        {
            return false;
        }

        bool xFound = false, yFound = false;
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode node = queue.Dequeue();
                if (node.left != null && node.right != null)
                {
                    if ((node.left.val == x && node.right.val == y) || (node.left.val == y && node.right.val == x))
                    {
                        return false;
                    }
                }
                if (node.val == x)
                {
                    xFound = true;
                }
                if (node.val == y)
                {
                    yFound = true;
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if (node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
            if (xFound && yFound)
            {
                return true;
            }
            if (xFound || yFound)
            {
                return false;
            }
        }
        return false;
    }
}