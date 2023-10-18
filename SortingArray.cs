using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exsecises
{
    public class SortingArray
    {
        private ItemSort[] arr;
        private int n;
        public SortingArray(int count)
        {
            arr = new ItemSort[n];
            for (int i = 0; i < count; i++)
                arr[i] = new ItemSort();
            n = count;
        }
        // copy array a[] has n item to arr[]
        public void Copy(int[] a, int count)
        {
            for (int i = 0; i < count; i++)
            {
                arr[i].info = 0;
                arr[i].key = a[i];
            }
            n = count;
        }
        // swap x and y
        public void Swap(ref ItemSort x, ref ItemSort y)
        {
            ItemSort temp = x; x = y; y = temp;
        }

        // Display Array
        public void Display()
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(arr[i].key + " ");
            }
            Console.WriteLine();
        }

        public void InsertionSort()
        {
            for (int i = 1; i < n; i++)
            {
                // Find the place to insert arr[i] to arr[0]..arr[i-1]
                ItemSort x = arr[i];
                int j = i - 1;
                bool cont = true;
                while ((j >= 0) && cont) 
                {
                    if (arr[j].key > x.key)
                    {
                        arr[j+1] = arr[j];
                        j--;
                    }
                    else
                    {
                        cont = false;
                    }
                    arr[j+1] = x;
                }
            }
        }
        public void ShellSort()
        {
            int m = 3;  // array containing increments
            int[] h = { 1, 3, 7 }; // array of increments
            // array of increment: 
            // array1: 1 4 13 14 121
            // array2: 1 3 7 15 31
            for (int r = m-1; r >= 0; r--)
            {
                int k = h[r];
                // using insertion sorting
                for (int i = k; i < n; i++)
                {
                    ItemSort x = arr[i];
                    int j = i - k;
                    bool cont = true;
                    while ((i >= 0) && cont)
                    {
                        if (arr[j].key > x.key)
                        {
                            arr[j + k] = arr[j];
                            j = j-k;
                        }
                        else
                        {
                            cont = false;
                        }
                        arr[j + k] = x;
                    }    
                }    
            }
        }

        public void SelectionSort()
        {
            for (int i = 0; i < n-1; i++)
            {
                int kmin = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[kmin].key > arr[j].key)
                    {
                        kmin = j;
                    }    
                }
                Swap(ref arr[i], ref arr[kmin]);
            }    
        }


    }

    public class ItemSort
    {
        public int key;
        public int info;
    }


}
