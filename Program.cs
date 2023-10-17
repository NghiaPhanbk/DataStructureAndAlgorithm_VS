using System;
using System.Xml.Linq;

namespace Exsecises
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi nghiaphan");
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Choose the task to test:");
                Console.WriteLine("1: Test Singly Linked List Firts");
                Console.WriteLine("2: Test Stack Array");
                Console.WriteLine("3: Test Queue Array");
                Console.WriteLine("4: Test Binary tree");
                Console.WriteLine("5: Test Max Heap");
                Console.WriteLine("6: Test Binary Search tree");
                option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        {
                            TestSinglyLinkedListFirst();
                            break;
                        }
                    case 2:
                        {
                            TestStackArray();
                            break;
                        }
                    case 3:
                        {
                            TestQueuekArray();
                            break;
                        }
                    case 4:
                        {
                            TestBinaryTree();
                            break;
                        }
                    case 5:
                        {
                            TestMaxHeap();
                            break;
                        }
                    case 6:
                        {
                            TestBinarySearchTree();
                            break;
                        }
                }
            } while (option != 0);

        }

        #region Test Singly Linked List Firts
        public static void TestSinglyLinkedListFirst()
        {
            LinkedList lkList = new LinkedList(); // Create lkList: null
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for Linked list:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Add Key to Linked list");
                Console.WriteLine("3. Find Key in Linked list");
                Console.WriteLine("4. Remove Key in Linked list");
                Console.WriteLine("5. Display Linked list");
                Console.WriteLine("6. Clear Linked list");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (lkList.IsEmpty())
                                Console.WriteLine("Linked list is empty.");
                            else
                                Console.WriteLine("Linked list is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type the Key to Linked List:");
                            int theInfo = Convert.ToInt32(Console.ReadLine());
                            lkList.InertOrder(theInfo);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Type the Key to find:");
                            int theInfo = Convert.ToInt32(Console.ReadLine());
                            Item p = lkList.FindOrder(theInfo);
                            if (p != null)
                            {
                                Console.WriteLine("Result is " + p.Info);
                            }
                            else
                            {
                                Console.WriteLine("Not Found the Key");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Type the Key to remove:");
                            int theInfo = Convert.ToInt32(Console.ReadLine());
                            bool error;
                            lkList.Remove(theInfo, out error);
                            if (error)
                            {
                                Console.WriteLine(theInfo + "is not Found");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            lkList.Display();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            lkList.Clear();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion

        #region Test Stack Array
        public static void TestStackArray()
        {
            Console.Write("Type size of stack: ");
            int theSize = Convert.ToInt32(Console.ReadLine());
            // Create a null stack with the size is theSize
            Stack_Array stack = new Stack_Array(theSize);
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for stack:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Add Key to stack");
                Console.WriteLine("3. Get Key from top of the stack");
                Console.WriteLine("4. Show Key at top of the stack");
                Console.WriteLine("5. Display stack");
                Console.WriteLine("6. Clear stack");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (stack.IsEmpty())
                                Console.WriteLine("Stack is empty.");
                            else
                                Console.WriteLine("Stack is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type the Key to Stack:");
                            int theInfo = Convert.ToInt32(Console.ReadLine());
                            bool error;
                            stack.Push(theInfo,out error);
                            if (error)
                            {
                                Console.WriteLine("Stack is full");
                            }    
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (stack.IsEmpty())
                                Console.WriteLine("Stack is null");
                            else
                            {
                                bool error;
                                int theInfo = stack.Pop(out error);
                                Console.WriteLine("Item get from top of the stack: " + theInfo);
                            }    
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            if (stack.IsEmpty())
                                Console.WriteLine("Stack is null");
                            else
                            {
                                bool error;
                                int theInfo = stack.Peek(out error);
                                Console.WriteLine("Item at top of the stack: " + theInfo);
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            stack.Display();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            stack.Clear();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion

        #region Test Queue Array
        public static void TestQueuekArray()
        {
            Console.Write("Type size of queue: ");
            int theSize = Convert.ToInt32(Console.ReadLine());
            // Create a null queue with the size is theSize
            Queue_Array queue = new Queue_Array(theSize);
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for queue:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Add Key to queue");
                Console.WriteLine("3. Get Key from front of the queue");
                Console.WriteLine("4. Show Key at front of the queue");
                Console.WriteLine("5. Display queue");
                Console.WriteLine("6. Clear queue");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (queue.IsEmpty())
                                Console.WriteLine("Queue is empty.");
                            else
                                Console.WriteLine("Queue is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Type the Key to Queue:");
                            int theInfo = Convert.ToInt32(Console.ReadLine());
                            bool error;
                            queue.EnqueueTranslation(theInfo, out error);
                            if (error)
                            {
                                Console.WriteLine("Queue is full");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (queue.IsEmpty())
                                Console.WriteLine("Queue is null");
                            else
                            {
                                bool error;
                                int theInfo = queue.DequeueTranslation(out error);
                                Console.WriteLine("Item get from fornt of the queue: " + theInfo);
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            if (queue.IsEmpty())
                                Console.WriteLine("Queue is null");
                            else
                            {
                                bool error;
                                int theInfo = queue.Peek(out error);
                                Console.WriteLine("Item at front of the queue: " + theInfo);
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            queue.Display();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            queue.Clear();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion

        #region Test Binary Tree
        public static void TestBinaryTree()
        {
            BinaryTree tree = new BinaryTree();
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for test Binary Tree:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Create tree from array");
                Console.WriteLine("3. Traverse Tree in order NLR");
                Console.WriteLine("4. Compute nodes of tree");
                Console.WriteLine("5. Compute height of tree");
                Console.WriteLine("6. Compute leaf nodes of tree");
                Console.WriteLine("7. Compute interior nodes of tree");
                Console.WriteLine("8. Traverse tree in levels");
                Console.WriteLine("9. Clear tree");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (tree.IsEmpty())
                                Console.WriteLine("Tree is empty.");
                            else
                                Console.WriteLine("Tree is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            // Traverse tree in NLR. 0 is Null
                            int[] a = { 1, 2, 3, 0, 0, 4, 0, 0, 5, 0, 0 };
                            tree.CreateTree(a);
                            Console.WriteLine("Create Tree Successful");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (tree.IsEmpty())
                                Console.WriteLine("Tree is null");
                            else
                            {         
                                Console.WriteLine("Traverse Tree in order NLR: ");
                                tree.TraverseNLR_Loop();
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            int node = tree.ComputeNodes();
                            Console.WriteLine("Number of nodes: " + node);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            int height = tree.ComputeHeight();
                            Console.WriteLine("Height of tree: " + height);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            int node = tree.ComputeLeafNodes();
                            Console.WriteLine("Number of leaf nodes: " + node);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        {
                            int node = tree.ComputeInteriorNodes();
                            Console.WriteLine("Number of Interior nodes: " + node);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            if (tree.IsEmpty())
                                Console.WriteLine("Tree is null");
                            else
                            {
                                Console.WriteLine("Traverse Tree in levels: ");
                                tree.TraverseLevels();
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            tree.Clear();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion

        #region Test Max Heap
        public static void TestMaxHeap()
        {
            Console.Write("Type the number of Heap Node: ");
            int theSize = Convert.ToInt32(Console.ReadLine());  
            // Create null Heap
            Heap heap = new Heap(theSize);
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for test Max Heap:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Add key to Heap");
                Console.WriteLine("3. Get max value of Heap");
                Console.WriteLine("4. Copy a array to Heap");
                Console.WriteLine("5. Show key kth lagest number");
                Console.WriteLine("6. Create Heap agian");
                Console.WriteLine("7. Display Heap");
                Console.WriteLine("8. Clear Heap");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (heap.IsEmpty())
                                Console.WriteLine("Heap is empty.");
                            else
                                Console.WriteLine("Heap is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            bool error;
                            Console.Write("Add Key: ");
                            int theKey = Convert.ToInt32(Console.ReadLine());   
                            heap.Insert(theKey, out error);
                            if (error)
                            {
                                Console.WriteLine("Heap is full");
                            }
                            else
                            {
                                Console.WriteLine("Add Key sucessful");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (heap.IsEmpty())
                                Console.WriteLine("Heap is null");
                            else
                            {
                                bool error; 
                                int theKey = heap.GetMaxValueAndRemove(out error);
                                Console.WriteLine("Max key is: {0}", theKey);
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            int n = 9;
                            int[] a = { 1, 4, 2, 7, 9, 6, 3, 8, 5 };
                            heap.Copy(a, n);
                            Console.WriteLine("Copy Successful");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            if (heap.IsEmpty())
                                Console.WriteLine("Heap is null");
                            else
                            {
                                Console.Write("Show how big the key is: ");
                                int k = Convert.ToInt32(Console.ReadLine());    
                                bool error;
                                int theKey = heap.Peek(k, out  error);
                                if (error)
                                {
                                    Console.WriteLine("Key is not exist");
                                }
                                else
                                    Console.WriteLine("Key {0}th lagest is {1}", k, theKey);

                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            heap.CreateHeapShifDown();
                            Console.WriteLine("Create successful");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        {
                            heap.Display();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            heap.Clear();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion

        #region Test BinarySearchTree
        public static void TestBinarySearchTree()
        {
            BinarySearchTree bstTree = new BinarySearchTree();
            int option = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Add task for test Binary Search Tree:");
                Console.WriteLine("1. Check null");
                Console.WriteLine("2. Add key to Binary Search Tree");
                Console.WriteLine("3. Get key from Binary Search Tree");
                Console.WriteLine("4. Remove key from Binary Search Tree");
                Console.WriteLine("5. Traverse NLR Binary Search Tree");
                Console.WriteLine("6. Check Binary Search Tree");
                Console.WriteLine("7. Clear Binary Search Tree");
                Console.WriteLine("0. End process");
                Console.Write("Your choice: ");
                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            if (bstTree.IsEmpty())
                                Console.WriteLine("Binary Search Tree is empty.");
                            else
                                Console.WriteLine("Binary Search Tree is not empty.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Add Key: ");
                            int theKey = Convert.ToInt32(Console.ReadLine());
                            bstTree.Insert(theKey);
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            if (bstTree.IsEmpty())
                                Console.WriteLine("Binary Search Tree is null");
                            else
                            {
                                Console.Write("Find Key: ");
                                int theKey = Convert.ToInt32(Console.ReadLine());
                                NodeBST p = bstTree.FindKeyRecursion(theKey);
                                if (p != null)
                                    Console.WriteLine("Find Key {0} sucessful", p.Key);
                                else
                                    Console.WriteLine("Key is not found");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            Console.Write("Type Key to remove");
                            int theKey = Convert.ToInt32(Console.ReadLine());
                            bool error;
                            bstTree.RemoveKeyRecursion(theKey, out error);
                            if (error)
                            {
                                Console.WriteLine("Don't have key {0}", theKey);
                            }
                            Console.WriteLine("Remove Successful");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            if (bstTree.IsEmpty())
                                Console.WriteLine("Binary Search Tree is null");
                            else
                            {
                                Console.Write("Traverse NLR: ");
                                bstTree.TraverseNLR_BST();
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            int[] a = { 2, 1, 0, 0, 4, 3, 0, 0, 0 };
                            bstTree.Create(a);
                            bool isBST = bstTree.IsBST();
                            if (isBST)
                            {
                                Console.WriteLine("It is Binary Search Tree");
                            }
                            else
                            {
                                Console.WriteLine("It is not Binary Search Tree");
                            }
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        {
                            bstTree.Clear();
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                            break;
                        }
                }
            }
            while (option != 0);
        }
        #endregion
    }
}
