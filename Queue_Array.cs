using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    public class Queue_Array
    {
        private int[] QueueArray;
        private int Front; // iteam first to get out
        private int Rear; // iteam first to add in
        private int Count;
        private int Size;

        // constructure: create null queue with size is theSize 
        public Queue_Array(int theSize)
        {
            QueueArray = new int[theSize];
            Front = -1;
            Rear = -1;
            Size = theSize;
            Count = 0;
        }

        #region Check null
        public bool IsEmpty()
        {
            bool result = Front == -1;
            return result;
        }
        #endregion

        #region Check Queue is full or not full
        // return: true if queue is full
        //          false if queue is not full
        bool IsFull()
        {
            // translation motion method
            bool result = (Rear - Front + 1 == Size)
            // around motion method
            || (Rear - Front + 1 == 0);
            return result;

        }
        #endregion

        #region Add Key to Queue
        // Add Key using Translation motion method
        // parameter
        // - error: false (queue is not full)
        //                  true (queue is full)
        public void EnqueueTranslation(int theInfo, out bool error)
        {
            if (IsFull())
            {
                error = true;
            }    
            else
            {
                error = false;
                if (IsEmpty())
                {
                    Front = 0; // Add theInfo to Arr[0]
                }
                else if(Rear == Size-1)
                {
                    // move to the begin of arrray
                    for (int i = Front; i <= Rear; i++)
                    {
                        QueueArray[i-Front] = QueueArray[i];
                    }
                    // Define again Rear and Front
                    Rear = Rear - Front;
                    Front = 0;
                }
                Rear++;
                // Add theInfo to Rear
                QueueArray[Rear] = theInfo;
                Count++;
            }
        }

        // Add Key using Around motion method
        // parameter
        // - error: false (queue is not full)
        //                  true (queue is full)
        public void EnqueueAround(int theInfo, out bool error)
        {
            if (IsFull())
            {
                error = true;
            }
            else
            {
                error = false;
                if (IsEmpty())
                {
                    Front = 0;// Add theInfo to Arr[0]
                }
                Rear++;
                // Rear come to arr[0]
                Rear = Rear % Size;
                QueueArray[Rear] = theInfo;
                Count++;
            }
        }
        #endregion

        #region Get Key from Queue
        // Get Key using Translation motion method
        // return: Key from Front (Queue is not null)
        //          0 (Queue is null)
        // parameter:
        // - error: false (queue is not null)
        //                  true (queue is null)
        public int DequeueTranslation(out bool error)
        {
            int result;
            if (IsEmpty())
            {
                error = true;
                result = 0;
            }
            else
            {
                error = false;
                // Get Key at Front
                result = QueueArray[Front];
                // Remove Item at Front
                if (Front == Rear)
                {
                    Front = -1;
                    Rear = -1;
                }
                else 
                {
                    Front++;
                }
                Count--;
            }
            return result;
        }

        // -----------------------------------------

        // Get Key using Around motion method
        // return: Key from Front (Queue is not null)
        //          0 (Queue is null)
        // parameter:
        // - error: false (queue is not null)
        //                  true (queue is null)
        public int DequeueAround(out bool error)
        {
            int result;
            if (IsEmpty())
            {
                error = true;
                result = 0;
            }
            else
            {
                error = false;
                // Get Key at Front
                result = QueueArray[Front];
                // Remove Key at Front
                if (Front == Rear)
                {
                    Front = -1;
                    Rear = -1;
                }
                else
                {
                    Front++;
                    // Front come to arr[0]
                    Front = Front % Size;
                }
                Count--;
            }
            return result;
        }
        #endregion

        #region Show Key at Front
        // return: Key at Front (Queue is not null)
        //          0 (Queue is null)
        // parameter:
        // - error: false (queue is not null)
        //                  true (queue is null)
        public int Peek(out bool error)
        {
            int result;
            if (IsEmpty())
            {
                error = true;
                result = 0;
            }
            else
            {
                error = false;
                result= QueueArray[Front];
            }
            return result;
        }
        #endregion

        #region Show Queue
        public void Display()
        {
            if (IsEmpty())
                Console.WriteLine("Queue is null");
            else
            {
                Console.WriteLine("Content of Queue is: ");
                int i = Front;
                bool cont = true;
                while (cont)
                {
                    // show item [i]
                    Console.WriteLine(QueueArray[i]);
                    if (i == Rear)
                        cont = false;
                    else
                    {
                        i++;
                        i = i% Size;
                    }
                }
                Console.WriteLine("Number of Item: " + Count);
                Console.WriteLine("Size of queue: ", Size);
            }
        }
        #endregion

        #region Clear Queue
        public void Clear()
        {
            Front = -1;
            Rear = -1;
            Count = 0;
        }

        // Destructure
        ~Queue_Array()
        {
            Clear();
        }
        #endregion
    }
}
