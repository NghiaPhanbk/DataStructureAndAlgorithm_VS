using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace Exsecises
{
    public class BinaryTree
    {
        private Node Root;

        #region Create null Binary Tree
        public BinaryTree()
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

        #region Tree traversal NLR
        // Tree p traversal NLR (Recursion)
        private void NLR(Node p, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(" "); //indent at the beginning of the line
            }
            if (p != null)
            {
                p.Display(); // Display content of p
                NLR(p.Left, n + 3); // traverse Left subtree
                NLR(p.Right, n + 3); // traverse right subtree
            }
            else
                Console.WriteLine("o"); // p null
        }

        // Tree Root Traversal NLR (Recursion)

        public void TraverseNLR_Recursion()
        {
            NLR(Root, 0); // traverse Root tree
        }

        //----------------------------------------
        // Stack Item
        class Item
        {
            public Node Info;
            public Item Next;

            // constructure: Create new item cotent is p
            public Item(Node p)
            {
                Info = p;  // content is p
                Next = null;
            }
        }

        class Stack
        {
            private Item Sp;

            // constructure: create null stac
            public Stack()
            {
                Sp = null;
            }

            // Check stack null
            public bool IsEmpty()
            { return Sp == null; }

            // add node p to stack
            public void Push(Node p)
            {
                Item q = new Item(p);
                q.Next = Sp;
                Sp = q;
            }

            // Get node from stack
            public Node Pop()
            {
                Item p = Sp;
                Node result = p.Info;
                Sp = p.Next;
                p = null;
                return result;
            }

            //Show node from top of stack
            public Node Peek()
            {
                return Sp.Info;
            }
        }

        // Traverse Root tree in order NLR (loop)
        public void TraverseNLR_Loop()
        {
            if (Root != null)
            {
                Stack stack = new Stack(); // create null stack
                stack.Push(Root); // Add Root Node to stack
                while (!stack.IsEmpty())
                {
                    Node p = stack.Pop(); // get node p from stack
                    p.Display(); // Display content of p
                    if (p.Right != null) // p have right node
                        stack.Push(p.Right); // Add right node to stack
                    if (p.Left != null) // p have left node
                        stack.Push(p.Left); //add left node to stack
                }
            }
        }
        #endregion

        #region Tree traversal LNR
        // Tree p traversal LNR (Recursion)
        private void LNR(Node p)
        {
            if (p != null)
            {
                LNR(p.Left); // Traverse Left subtree
                p.Display(); // Display content of p
                LNR(p.Right); // Traverse right subtree
            }
        }

        // Tree Root Traversal LNR (Recursion)

        public void TraverseLNR_Recursion()
        {
            LNR(Root); // traverse Root tree
        }

        // Traverse Root tree in order LNR (loop)
        public void TraverseLNR_Loop()
        {
            Node pLNR = Root; //pLNR is Root
            Stack stack = new Stack();
            while ((!stack.IsEmpty()) || (pLNR != null))
            {
                if (pLNR != null)
                {
                    stack.Push(pLNR);
                    pLNR = pLNR.Left;
                }
                else
                {
                    pLNR = stack.Pop();
                    pLNR.Display();
                    pLNR = pLNR.Right;
                } 
                    
            }
                
        }
        #endregion

        #region Tree traversal LRN
        // Tree p traversal LNR (Recursion)
        private void LRN(Node p)
        {
            if (p != null)
            {
                LRN(p.Left); // Traverse Left subtree                
                LRN(p.Right); // Traverse right subtree
                p.Display(); // Display content of p
            }
        }

        // Tree Root Traversal LRN (Recursion)

        public void TraverseLRN_Recursion()
        {
            LRN(Root); // traverse Root tree
        }

        // Traverse Root tree in order LNR (loop)
        public void TraverseLRN_Loop()
        {
            Node pLRN = Root; //pLNR is Root
            Stack stack = new Stack();
            Node lastNode = null; // previous processed node
            while ((!stack.IsEmpty()) || (pLRN != null))
            {
                if (pLRN != null)
                {
                    stack.Push(pLRN);
                    pLRN = pLRN.Left;
                }
                else
                {
                    Node q = stack.Peek(); // q is node from peek stack
                    // if q have right child node and traversed left child node
                    // move to right right child node of q
                    if ((q.Right != null) && (lastNode != q.Right))
                    {
                        pLRN = q.Right;
                    }    
                    else
                    {
                        q.Display();
                        lastNode = stack.Pop();
                    }    
                }

            }

        }
        #endregion

        #region Create Tree from array
        // Create p tree form a[i] item using order traverse NLR
        // return p is pointer to Root node
        //  0 is null
        private Node CreateTreeNLR(int[] a, ref int i)
        {
            Node p;
            if (a[i] == 0)
                p = null; // create p tree is null
            else
            {
                p = new Node(a[i]); // Create p have key a[i]
                i++; // i move to the next item
                p.Left = CreateTreeNLR(a, ref i); // Create left subtree from p
                i++; //move i to the next item
                p.Right = CreateTreeNLR(a, ref i); // Create right subtree from p
            }
            return p;
        }

        // Create Root tree from array a[] using NLR order
        public void CreateTree(int[] a)
        {
            int i = 0; // start foem a[0]
            Root = CreateTreeNLR(a, ref i);
        }
        #endregion

        #region Compute height of tree
        // return height of tree p
        // height of tree p = max (height of left subtree, height of right subtree) + 1
        private int ComputeHeightOfTree(Node p)
        {
            int height;
            if (p == null)
                height = 0;
            else
            {
                // Compute height left subtree
                int leftHeight = ComputeHeightOfTree(p.Left);
                // Compute height right subtree
                int rightHeight = ComputeHeightOfTree(p.Right); 
                // compute height of tree
                if (leftHeight > rightHeight)
                {
                    height = leftHeight+1;
                }
                else
                {
                    height = rightHeight+1;
                }
            }
            return height;
        }
         public int ComputeHeight()
        {
            int height = ComputeHeightOfTree(Root);
            return height;
        }

        #endregion

        #region Compute number of node
        // return number of node of tree p
        // number of node of tree p = number of node of left subtree + number of node of right subtree + 1
        private int ComputeNumberOfNodes(Node p)
        {
            int nodes;
            if (p == null)
                nodes = 0;
            else
            {
                nodes = ComputeNumberOfNodes(p.Left) + ComputeNumberOfNodes(p.Right) + 1;
            }
            return nodes;
        }
        public int ComputeNodes()
        {
            int nodes = ComputeNumberOfNodes(Root);
            return nodes;
        }

        #endregion

        #region Compute number of leaf nodes
        // return number of leaf node of tree p
        // number of leaf node of tree p = number of leaf node of left subtree + number of leaf node of right subtree
        private int ComputeNumberOfLeafNodes(Node p)
        {
            int leafNodes;
            if (p == null)
                leafNodes = 0;
            else if ((p.Left == null) && (p.Right == null))
            {
                leafNodes = 1;
            }
            else
            {
                leafNodes = ComputeNumberOfLeafNodes(p.Left) + ComputeNumberOfLeafNodes(p.Right) ;
            }
            return leafNodes;
        }
        public int ComputeLeafNodes()
        {
            int leafNode = 0;
            if (Root != null)
            {
                if((Root.Left != null) || (Root.Right != null))
                {
                    // Root tree have left subtree or right subtree
                    // Compute leaf node of tree root
                    leafNode = ComputeNumberOfLeafNodes(Root);
                }
            }
            return leafNode;
        }

        #endregion

        #region Compute number of interior nodes
        // return number of interior node of tree p
        // number of interior node of tree p = number of interior node of left subtree + number of interior node of right subtree + 1 (node p)
        private int ComputeNumberOfInteriorNodes(Node p)
        {
            int interiorNodes;
            if (p == null)
                interiorNodes = 0;
            else if ((p.Left == null) && (p.Right == null))
            {
                interiorNodes = 0;
            }
            else
            {
                interiorNodes = ComputeNumberOfInteriorNodes(p.Left) + ComputeNumberOfInteriorNodes(p.Right) +1;
            }
            return interiorNodes;
        }
        public int ComputeInteriorNodes()
        {
            int interiorNode = ComputeNumberOfInteriorNodes(Root);
            if (interiorNode > 0)
            {
                interiorNode--; // Node root is not interior node
            }
            return interiorNode;
        }

        #endregion

        #region Traverse Tree with levels

        class Queue
        {
            private Item front;
            private Item rear;

            public Queue()
            {
                front = null;
                rear = null;
            }

            public bool IsEmpty()
            {
                bool result = front == null;
                return  result;
            }
            public void Enqueue(Node q)
            {
                Item p = new Item(q);
                if (front == null)
                    front = p;
                else
                    rear.Next = p;
                rear = p;
            }

            public Node Dequeue()
            {
                Item p = front;
                Node result = p.Info;
                if (front == rear)
                    rear = null;
                front = p.Next;
                p = null;
                return result;
            }
        }
        public void TraverseLevels()
        {
            if(! IsEmpty())
            {
                Queue queue = new Queue();
                queue.Enqueue(Root);
                while (!queue.IsEmpty())
                {
                    Node p = queue.Dequeue();
                    p.Display();
                    if (p.Left != null)
                        queue.Enqueue(p.Left);
                    if (p.Right != null)
                        queue.Enqueue(p.Right);
                }
            }
        }
        #endregion

        #region Clear tree
        private void ClearLRN(ref Node p)
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
        ~BinaryTree()
        {
            Clear();
        }
        #endregion
    }


    public class Node
    {
        public int Info; // Content of node
        public Node Left; // pointer to left node
        public Node Right; // pointer to right node

        // Constructure: create a node with content is the info
        public Node(int theInfo)
        {
            Info = theInfo;
            Left = null;
            Right = null;
        }

        // Display content of node
        public void Display()
        {
            Console.WriteLine(Info);
        }

    }

}
