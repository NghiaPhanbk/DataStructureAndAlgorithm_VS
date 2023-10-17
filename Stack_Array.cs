using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    public class Stack_Array
    {
        // --Atribute
        private int[] StackArray;
        private int StackPointer;
        private int Size;
        private int Count;

        // -- Method
        
        // Constructure: Create null stack
        public Stack_Array(int theSize)
        {
            StackArray = new int[theSize];
            StackPointer = -1;
            Size = theSize;
            Count = 0;
        }

        #region Check Stack null or notnull
        public bool IsEmpty()
        {
            bool result = StackPointer == -1;
            return result;
        }
        #endregion

        #region Check Stack is full or not full
        bool IsFull()
        {
            bool result = StackPointer == Size-1;
            return result;
        }
        #endregion

        #region Add the Key to stack
        // Add error to stack
        // error: return false if stack is not full
        //      : return true if is full
        public void Push(int theInfo, out bool error)
        {
            if(IsFull())
            {
                error = true;
            }
            else
            {
                error = false;
                StackPointer++;
                StackArray[StackPointer] = theInfo;
                Count++;
            }    
        }
        #endregion

        #region Get the Key from stack
        // Return: Key from top of the Stack (stack is not null)
        //        0 (Stack is null)
        // Reference parameter
        // - error: false if success
        //         : true if failure 
        public int Pop(out bool error)
        {
            int result;
            if(IsEmpty())
            {
                error = true;
                return  0;
            }
            else
            {
                error = false;
                result = StackArray[StackPointer];
                Count--;
                StackPointer--;
            }    
            return result;
        }
        #endregion

        #region Show the Key from top of the Stack 
        // return : Key from top of the Stack (stack is not null)
        //          0 (stack is null)
        // - error: false if success
        //         : true if failure 
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
                result = StackArray[StackPointer];
            }    
            return result;
            
        }
        #endregion

        #region Show the stack
        public void Display()
        {
            if (IsEmpty())
                Console.WriteLine("Stack is null");
            else
            {
                Console.WriteLine("Contents of the stack:");
                for (int i = StackPointer; i>= 0; i--)
                {
                    Console.WriteLine(StackArray[i]);
                }
                Console.WriteLine("Number of current item: " + Count);
                Console.WriteLine("Size of stack: " + Size);
            }
        }
        #endregion

        #region Clear Stack
        public void Clear()
        {
            StackPointer = -1;
            Count = 0;
        }
        ~ Stack_Array()
        {
            Clear();
        }
        #endregion

    }
}
