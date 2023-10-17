using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    internal class BinarySearchTree
    {
        private NodeBST Root;

        #region Create null Binary Tree
        public BinarySearchTree()
        {
            Root = null;
        }
        #endregion

        #region Check null
        public bool IsEmpty()
        {
            bool result = Root == null;
            return result;
        }
        #endregion

        #region Add Key to Binary Search Tree
        private void InsertBSTRecursion(ref NodeBST p, int theKey)
        {
            if (p == null)
            {
                p = new NodeBST(theKey);
            }
            else if (theKey < p.Key)
            {
                InsertBSTRecursion(ref p.Left, theKey);
            }
            else if (p.Key == theKey)
            {
                p.Count++;
            }
            else
            {
                InsertBSTRecursion(ref p.Right, theKey);
            }
        }

        private void InsertBSTLoop(ref NodeBST root, int theKey)
        {
            NodeBST q = new NodeBST(theKey);
            if (root == null)
                root = q;
            else
            {
                NodeBST parent = null;
                NodeBST p = root;
                while (p != null)
                {
                    parent = p;
                    if (theKey < p.Key)
                    {
                        p = p.Left;
                    }
                    else if ( theKey > p.Key)
                    {
                        p = p.Right;
                    }
                    else
                    {
                        p.Count++;
                    }
                }
                if (theKey < parent.Key)
                {
                    parent.Left = q;
                }
                else
                { 
                    parent.Right = q; 
                }
            }
        }

        public void Insert(int theKey)
        {
            InsertBSTRecursion(ref Root, theKey);
        }
        #endregion

        #region Search Key in Binary Search Tree
        // Search theKey using Loop
        public NodeBST FindBSTLoop(int theKey)
        {
            NodeBST p = Root;
            bool found = false;
            while ((p != null) && !found)
            {
                if (theKey < p.Key)
                {
                    p = p.Left;
                }
                else if (theKey == p.Key)
                {
                    found = true;
                }
                else
                {
                    p = p.Right;
                }
            }
            return p;
        }

        // Search theKey using Recursion
        private NodeBST FindBSTRecursion(NodeBST p, int theKey)
        {
            NodeBST result = null;
            if (p != null)
            {
                if (theKey < p.Key)
                    result = FindBSTRecursion(p.Left, theKey);
                else if (theKey == p.Key)
                    result = p;
                else
                    result = FindBSTRecursion(p.Right, theKey);
            }
            return result;
        }

        public NodeBST FindKeyRecursion(int theKey)
        {
            NodeBST result = FindBSTRecursion(Root, theKey);
            return result;
        }
        #endregion

        #region Remove Key from Binary Search Tree
        // Remove Key using Recursion
        // remve right most node
        // - q is remove node
        // - r is most node right
        private void RemoveRightMostNode(ref NodeBST r, ref NodeBST q)
        {
            if (r.Right != null)
                RemoveRightMostNode(ref r.Right, ref q);
            else
            {
                // copy right most node to q
                q.Key = r.Key;
                q.Count = r.Count;
                q = r;
                // move r to Left and attach the left subtree to parent node
                r = r.Left;
            }
        }

        // Remove Key in tree p using Recursion
        // parameter:
        // - p is changed after remove the Key
        // - error: false if sucessful, true if not found

        private void RemoveBSTRecursion(ref  NodeBST p, int theKey, out bool error)
        {
            error = true;
            if (p != null)
            {
                if (theKey < p.Key)
                {
                    RemoveBSTRecursion(ref p.Left, theKey, out error);
                }    
                else if (theKey > p.Key)
                {
                    RemoveBSTRecursion(ref p.Right, theKey, out error);
                }
                else
                {
                    error = false;
                    NodeBST q = p;
                    if ((p.Left == null) && (p.Right == null))
                    {
                        p = null;
                    }
                    else if ((p.Right == null) && (q.Left != null))
                    {
                        p = p.Left;
                    }
                    else if ((p.Left == null) && (p.Right != null))
                    {
                        p = p.Right;
                    }
                    else
                    {
                        RemoveRightMostNode(ref p.Left, ref q);
                    }
                    q = null;
                }    
            }
        }

        public void RemoveKeyRecursion(int theKey, out bool error)
        {
            RemoveBSTRecursion(ref Root, theKey, out error);
        }


        // remove Key using loop
        public void RemoveKeyLoop(int theKey, out bool error)
        {
            error = true;
            bool found = false;
            bool isLeftChild = false;
            NodeBST parent = null;
            NodeBST p = Root;
            while ((p != null) && (!found))
            {
                if (theKey == p.Key)
                {
                    found = true;
                }
                else if (theKey < p.Key)
                {
                    parent = p;
                    p = p.Left;
                    isLeftChild = true;
                }
                else
                {
                    parent = p;
                    p = p.Right;
                    isLeftChild = false;
                }
            }

            if (found)
            {
                error = false;
                if ((p.Left == null) && (p.Right == null))
                {
                    if (p == Root)
                        Root = null;
                    else if (isLeftChild)
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                else if ((p.Right == null) && (p.Left != null))
                {
                    if (p == Root)
                    {
                        Root = p.Left;
                    }
                    else if (isLeftChild)
                    {
                        parent.Left = p.Left;
                    }
                    else
                        parent.Right = p.Left;
                }
                else if ((p.Right != null) && (p.Left == null))
                {
                    if (p == Root)
                    {
                        Root = p.Right;
                    }
                    else if (isLeftChild)
                    {
                        parent.Left = p.Right;
                    }
                    else
                        parent.Right = p.Right;
                }
                else
                {
                    NodeBST r = p.Left;
                    while (r.Right != null)
                    {
                        parent = r;
                        r = r.Right;
                    }
                    p.Key = r.Key;
                    p.Count = r.Count;
                    if (r == p.Left)
                    {
                        p.Left = r.Left;
                    }
                    else
                    {
                        parent.Right = r.Left;
                    }
                    p = r;
                }
                p = null;
            }
        }
        #endregion

        #region Tree traversal NLR
        // Tree p traversal NLR (Recursion)
        private void NLR_BST(NodeBST p, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(" "); //indent at the beginning of the line
            }
            if (p != null)
            {
                p.Display(); // Display content of p
                NLR_BST(p.Left, n + 3); // traverse Left subtree
                NLR_BST(p.Right, n + 3); // traverse right subtree
            }
            else
                Console.WriteLine("0:0"); // p null
        }

        // Tree Root Traversal NLR (Recursion)

        public void TraverseNLR_BST()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Tree is null");
            }
            else
            {
                Console.WriteLine("Tree BST is ");
                NLR_BST(Root, 0);
            }
        }

        #endregion

        #region Check Tree is Binary search tree
        private void CreateTree(ref NodeBST p, int[] a, ref int i)
        {
            if (a[i]==0)
            {
                p = null;
            }
            else
            {
                p = new NodeBST(a[i]);
                i++;
                CreateTree(ref p.Left, a, ref i);
                i++;
                CreateTree(ref p.Right, a, ref i);
            }
        }

        // Create Root from array A

        public void Create(int[] a)
        {
            int i = 0;
            CreateTree(ref Root, a, ref i);
        }

        private bool IsBSTTree(NodeBST p, ref int key, ref bool firstTime)
        {
            bool isBST = true;
            if (p != null)
            {
                isBST = IsBSTTree(p.Left, ref key, ref firstTime);
                if (isBST)
                {
                    if (firstTime)
                        firstTime = false; 
                    else if (key >= p.Key)
                        isBST = false;
                    key = p.Key;
                }
                if (isBST)
                {
                    isBST = IsBSTTree(p.Right, ref key, ref firstTime);
                }
            }
            return isBST;
        }
        public bool IsBST()
        {
            int key = 0;
            bool firstTime = true;
            bool isBST = IsBSTTree(Root, ref key, ref firstTime);
            return isBST;
        }

        #endregion

        #region Clear tree
        private void ClearLRN(ref NodeBST p)
        {
            if (p != null)
            {
                ClearLRN(ref p.Left);
                ClearLRN(ref p.Right);
                p = null;
            }
        }
        public void Clear()
        {
            ClearLRN(ref Root);
        }
        ~BinarySearchTree()
        {
            Clear();
        }
        #endregion
    }


    public class NodeBST
    {
        public int Key; // Content of node
        public int Count; // number of times the node appears
        public NodeBST Left; // pointer to left node
        public NodeBST Right; // pointer to right node

        // Constructure: create a node with content is theKey
        public NodeBST(int theKey)
        {
            Key = theKey;
            Count = 1;
            Left = null;
            Right = null;
        }

        // Display content of node
        public void Display()
        {
            Console.WriteLine(Key);
        }

    }

}
