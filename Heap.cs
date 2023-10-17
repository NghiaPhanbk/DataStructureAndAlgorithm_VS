using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    public class Heap
    {
        private int[] Arr;
        private int Size;
        private int Count;
        // Constructure: Create a null Heap
        public Heap(int theSize)
        {
            Arr = new int[theSize];
            Size = theSize;
            Count = 0;
        }
        
        // Check Null
        // Null -> True, Not null -> false
        public bool IsEmpty()
        {
            bool result = Count == 0;
            return result;
        }

        // Check Heap is Full

        public bool IsFull()
        {
            bool result = Count == Size;
            return result;
        }

        #region Create Heap From Array
        // Copy array a[] n item to Heap
        public void Copy(int[] a, int n)
        {
            Arr = new int[n]; // Create a Heap n item
            // Copy a[] to Heap
            for (int i = 0; i < n; i++)
            {
                Arr[i] = a[i];
            }
            Count = n;
            Size = n;
        }

        // Create Heap from i node to root node using Shift Up - Loop
        // Input: Arr[0]..Arr[i-1] is heap
        // Output: Arr[0]..Arr[i] is heap
        private void ShiftUpLoop(int i)
        {
            int parent; // parent of i node
            int theKey = Arr[i]; // copy i to the Key
            bool cont = true; // condition to continue
            while ((i>0)&&cont)
            {
                parent = (i - 1) / 2;
                if (Arr[parent]<theKey)
                {
                    // copy parent to i node
                    Arr[i] = Arr[parent];
                    i = (i-1) / 2;
                }
                else
                {
                    cont = false; // stop
                }
                Arr[i] = theKey; // copy theKey to i node 
            }
        }

        //-------------------------------------------------
        // swap x and y
        private void Swap(ref int x,ref int y)
        {
            int temp = x;
            x = y; 
            y = temp;
        }

        //-------------------------------------------------
        // Create Heap from i node to root node using Shift Up -Recursion
        // Input: Arr[0]..Arr[i-1] is heap
        // Output: Arr[0]..Arr[i] is heap
        private void ShipUpRecursion(int i)
        {
            if (i > 0)
            {
                int parent = (i - 1) / 2;
                if (Arr[parent] < Arr[i])
                {
                    Swap(ref Arr[i], ref Arr[parent]);
                    ShipUpRecursion(parent);
                }
            }
        }

        //-------------------------------------------------
        // Create Heap using Shift Up -Recursion
        // Input: Arr[] is not Heap
        // Output: Arr[] is Heap

        public void CreateHeapShiftUp()
        {
            for (int i =1; i < Count; i++)
            {
                ShipUpRecursion(i);
            }
        }

        //-------------------------------------------------
        // Create Heap from p node to q node using Shift Down
        // Input: Arr[p+1]..Arr[q] is Heap
        // Output: Arr[p]..Arr[q] is Heap
        public void ShiftDown(int p, int q)
        {
            int i = p; 
            int theKey = Arr[i];
            int j = 2 * i + 1; // j is the left node of i node
            bool cont = true;

            while ((j <= q) && cont)
            {
                // Find j node is max node
                if (j < q)
                {
                    // left node < right node
                    if (Arr[j] < Arr[j+1])
                    {
                        j = j + 1; // j node is right node
                    }    
                }
                // Compare theKey with the key of J node
                if (theKey < Arr[j]) // theKey < key of j node
                {
                    Arr[i] = Arr[j]; // copy j node to i node
                    i = j; // i to j
                    j = j * 2 + 1; // // j move to left subnode of i node
                }
                else
                {
                    cont = false; 
                }
            }
            Arr[i] = theKey;   // copy theKey to i node         
        }

        //-------------------------------------------------
        // Create Heap using Shift Down
        // Input: Arr[] is not Heap
        // Output: Arr[] is Heap
        public void CreateHeapShifDown()
        {
            // the last haft of array Arr[k+1]..Arr[n-1] is Heap
            int k = (Count / 2 - 1);
            // Consider nodes Arr[k]..Arr[0]
            for (int i = k; i >= 0; i--)
            {
                // Create array Arr[i]..Arr[n-1] is Heap
                ShiftDown(i, Count-1);
            }
        }
        #endregion

        #region Add Key to Heap
        // Add the Key to Heap
        // parameter
        // - error: false - successful (Heap is not full)
        //          true (Heap is full)
        public void Insert(int theKey, out bool error)
        {
            if (IsFull())
                error = true;
            else
            {
                error = false;
                // copy theKey to the end of Heap
                Arr[Count] = theKey;
                // Create Heap from end node to root node
                ShipUpRecursion(Count);
                Count++;
            }
        }
        #endregion

        #region Get Max Key from Heap
        // return: max key of heap, 0 if heap is null
        // parameter:
        // error: false if sucessful, true if heap is null
        public int GetMaxValueAndRemove(out bool error)
        {
            int theKey;
            if (IsEmpty())
            {
                error = true;
                theKey = 0;
            }
            else
            {
                error = false;
                theKey = Arr[0];
                Arr[0] = Arr[Count - 1];
                Count--;
                CreateHeapShifDown();
            }
            return theKey;
        }
        #endregion

        #region Show the k lagest number
        // return: key of k lagest number, 0 if not exist
        // parameter: 
        // - error: false if exist, true if not exist

        public int Peek(int k, out bool error)
        {
            int theKey;
            if (IsEmpty() || (k<0) || (k > Count))
            {
                error=true;
                theKey=0;
            }
            else
            {
                error=false;
                // Create array a[] have number of item is the number of current heap node
                int[] a = new int[Count];
                // Ket k Key from Heap
                int n = 0;
                for (int i = 1; i <= k; i++)
                {
                    // Get node 0 largest of heap copy to the end of arrar a[]
                    a[n] = GetMaxValueAndRemove(out error);
                    n++; // Increase number of item os array a
                }
                // add k Key to Heap
                for (int i = 0; i < n; i++)
                {
                    Insert(a[i], out error);
                }
                // The end Item of array a[] have key kth lagest number
                theKey = a[n - 1];
            }
            return theKey;
        }
        #endregion

        #region Display Heap
        public void Display()
        {
            if (IsEmpty())
                Console.WriteLine("Heap is null");
            else
            {
                Console.WriteLine("Heap: ");
                for (int i = 0;i < Count;i++)
                {
                    Console.WriteLine("{0} ", Arr[i]);
                }
                Console.WriteLine();
                Console.WriteLine("Number of Heap Node: {0}", Count);
                Console.WriteLine("Max node of Heap: {0}", Size);
            }
        }
        #endregion

        #region Clear Heap
        public void Clear()
        {
            Size = 0;
            Count = 0;
        }

        // Destructor
        ~Heap()
        {
            Clear();
        }
        #endregion
    }
}
