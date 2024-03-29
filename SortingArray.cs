﻿using System;
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
        public SortingArray(int N)
        {
            arr = new ItemSort[N];
            for (int i = 0; i < N; i++)
                arr[i] = new ItemSort();
            n = N;
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
                        arr[j + 1] = arr[j];
                        j--;
                    }
                    else
                    {
                        cont = false;
                    }
                    arr[j + 1] = x;
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
            for (int r = m - 1; r >= 0; r--)
            {
                int k = h[r];
                // using insertion sorting
                for (int i = k; i < n; i++)
                {
                    ItemSort x = arr[i];
                    int j = i - k;
                    bool cont = true;
                    while ((j >= 0) && cont)
                    {
                        if (arr[j].key > x.key)
                        {
                            arr[j + k] = arr[j];
                            j = j - k;
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
            for (int i = 0; i < n - 1; i++)
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

        private void ShiftDown(int p, int q)
        {
            int i = p;
            ItemSort x = arr[i];
            int j = 2 * i + 1; // j is the left node of i node
            bool cont = true;

            while ((j <= q) && cont)
            {
                // Find j node is max node
                if (j < q)
                {
                    // left node < right node
                    if (arr[j].key < arr[j + 1].key)
                    {
                        j = j + 1; // j node is right node
                    }
                }
                // Compare theKey with the key of J node
                if (x.key < arr[j].key) // theKey < key of j node
                {
                    arr[i] = arr[j]; // copy j node to i node
                    i = j; // i to j
                    j = j * 2 + 1; // // j move to left subnode of i node
                }
                else
                {
                    cont = false;
                }
            }
            arr[i] = x;   // copy theKey to i node         
        }

        public void HeapSort()
        {
            // First process
            int k = n / 2 - 1;
            for (int i = k; i >= 0; i--)
                ShiftDown(i, n - 1);
            // Second process
            for (int i = n - 1; i > 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                ShiftDown(0, i - 1);
            }
        }

        public void BubbleSortNoFlag()
        {
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = n - 1; j > i; j--)
                {
                    if (arr[j].key < arr[j - 1].key)
                    {
                        Swap(ref arr[j], ref arr[j - 1]);
                    }
                }
            }
        }

        public void BubbleSortWithFlag()
        {
            int i = 0;
            bool flag;
            do
            {
                flag = false;
                for (int j = n-1; j >i; j--)
                {
                    if (arr[j].key < arr[j - 1].key)
                    {
                        Swap(ref arr[j], ref arr[j - 1]);
                    }
                    flag = true;                   
                }
                i++;
            } while (flag);
        }

        public void ShakerSort()
        {
            int p = 1;
            int q = n - 1;
            int k = n - 1;
            while (p <= q)
            {
                // Down to up
                for (int i = q; i >= p; i--)
                {
                    if (arr[i].key < arr[i - 1].key)
                    {
                        Swap(ref arr[i], ref arr[i - 1]);
                        k = i;
                    }
                }
                p = k + 1;
                // Up to down
                for (int i = p; i <= q; i++)
                {
                    if (arr[i].key < arr[i - 1].key)
                    {
                        Swap(ref arr[i], ref arr[i - 1]);
                        k = i;
                    }
                }
                q = k - 1;
            }    
        }

        // Lomuto method
        private int LomutoPartition(int start, int end)
        {
            int pivot = arr[end].key;
            int i = start;
            for (int j = start; j <= end-1;  j++)
            {
                if (arr[j].key < pivot)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                }
            }
            Swap(ref arr[i], ref arr[end]);
            return i;
        }

        private void Sort(int start, int end)
        {
            if (start < end)
            {
                int k = LomutoPartition(start, end);
                Sort(start, k-1);
                Sort(k + 1, end);
            }
        }
        public void QuickSort()
        {
            Sort(0, n-1);
        }

        // Merge Sort - recursion
        private void Merge(ItemSort[] temp, int p, int t, int q)
        {
            int k = t - 1; // the end index of array 1
            int i = p; // index of array 1
            int j = t; // index of array 2
            int m = 0; // index of temp
            while ((i <= k) && (j <= q))
            {
                if (arr[i].key <= arr[j].key)
                {
                    temp[m] = arr[i];
                    i++;
                }
                else
                {
                    temp[m] = arr[j];
                    j++;
                }
                m++;
            }
            // copy the remaining element of arr 1 to arr temp
            for (int r = i; r <= k; r++)
            {
                temp[m] = arr[r];
                m++;
            }
            // copy the remaining element of arr 2 to arr temp
            for (int r = j; r <=q; r++)
            {
                temp[m] = arr[r];
                m++;
            }
            // copy arr temp to main arr
            for (int r=0; r < m; r++)
            {
                arr[p + r] = temp[r];
            }    
        }

        private void SortRun(ItemSort[] temp, int p, int q)
        {
            if (p < q)
            {
                int k = (p + q) / 2;
                SortRun(temp, p, k);
                SortRun(temp,k + 1, q);
                Merge(temp, p, k + 1, q);
            }
        }

        public void MergeSort()
        {
            ItemSort[] temp = new ItemSort[n];
            SortRun(temp, 0, n - 1);
        }

        //  RAdix Sort 

        public void RadixSort()
        {
            const int BASE = 10;
            int[] bucket = new int[BASE];
            ItemSort[] b = new ItemSort[n];
            // Find the max value to estimate the number of loop
            int maxVal = arr[0].key;
            for (int i = 1; i < n; i++)
            {
                if (arr[i].key > maxVal)
                {
                    maxVal = arr[i].key;
                }    
            }

            // Alnalys weight
            int weight = 1;
            while (maxVal/weight > 0)
            {
                // create the first array bucket 
                for (int i = 0; i < BASE; i++)
                {
                    bucket[i] = 0;
                }

                // Calculate number item of bucket
                for (int i = 0; i<n ; i++)
                {
                    bucket[(arr[i].key/weight)%BASE]++;
                }
                for (int i = 1; i < BASE; i++)
                {
                    bucket[i] = bucket[i] + bucket[i - 1];
                }    

                // Copy arr[i] to bucket of b[]
                for (int i = n-1; i >= 0; i--)
                {
                    bucket[(arr[i].key / weight) % BASE]--;
                    b[bucket[(arr[i].key / weight) % BASE]] = arr[i];
                }

                // copy bucket b[] to arr[]
                for (int i = 0; i < n; i++)
                {
                    arr[i] = b[i];
                }
                weight = weight * BASE;
            }
        }

    }

    public class ItemSort
    {
        public int key;
        public int info;
    }
}
