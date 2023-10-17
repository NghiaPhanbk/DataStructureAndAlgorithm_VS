using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    internal class LinkedList
    {
        private Item First; // Pointer to the first Linked List
        private int Count; // Number of current item

        // Constructure: create Linked List null
        public LinkedList()
        {
            First = null;
            Count = 0;                 
        }

        // check null for linked list:
        // True: null, False: not null
        public bool IsEmpty()
        {
            bool result = First == null;
            return result;
        }
        #region Thêm key vào LinkedList
        // Thêm theInfor vào đầu danh sách
        public void InsertFirst(int theInfo)
        {
            // Tạo phần tử mới q có key là theInfo
            Item q = new Item(theInfo);
            // thêm phần tử q vào đầu danh sách
            q.Next = First; // q trỏ đến phần tử đầu tiên
            First = q; 
            Count++; // tăng số phần tử
        }

        //----------------------------------------------------------------------------

        // Thêm theInfo vào danh sách có thứ tự tăng dần
        public void InertOrder(int theInfo)
        {
            // Tìm vị trí thêm theInfo vào danh sách
            bool continueProcess = true;
            Item before_p = null;
            Item p = First;
            // p là phần tử của danh sách và còn tiếp tục
            while ((p != null) && continueProcess)
            {
                if (p.Info < theInfo)
                {
                    before_p = p;
                    p = p.Next;
                }
                else
                    continueProcess = false;
            }
            // Tạo phần tử mới q có từ khóa là theInfo
            Item q = new Item(theInfo);
            if (p == First)
            {
                // Thêm phần tử vào đầu danh sách
                First = q;
            }
            else
            {
                // thêm phần tử q vào giữa before_p và p
                before_p.Next = q;
            }
            q.Next = p;
            Count++;      
            }
        #endregion

        #region Tìm key trong LinkedList

        //Tìm theInfo trong danh sách chưa có thứ tự
        //Trả về: địa chỉ của phần tử, không có trả null

        public Item Find(int theInfo)
        {
            bool found = false;  // cờ tìm thấy chưa
            Item p = First; // p là phần tử đầu tiên
            // p là phần tử của danh sách và chưa tìm thấy
            while ((p != null) && !found)
            {
                if (p.Info == theInfo)
                {
                    found = true;
                }
                else
                    p = p.Next;
            }
            return p;
        }
        //------------------------------------------------------------

        //Tìm theInfo trong danh sách chưa có thứ tự
        //Trả về: true nếu có, không có trả false

        public bool Find_bool(int theInfo)
        {
            bool found = false;  // cờ tìm thấy chưa
            Item p = First; // p là phần tử đầu tiên
            // p là phần tử của danh sách và chưa tìm thấy
            while ((p != null) && !found)
            {
                if (p.Info == theInfo)
                {
                    found = true;
                }    
                else
                    p = p.Next;
            }
            return found;
        }

        //------------------------------------------------
        //Tìm theInfo trong danh sách có thứ tự tăng dần
        //Trả về: địa chỉ của phần tử, không có trả null

        public Item FindOrder(int theInfo)
        {
            bool found = false;  // cờ tìm thấy chưa
            Item p = First; // p là phần tử đầu tiên
            // p là phần tử của danh sách và chưa tìm thấy
            while ((p != null) && !found)
            {
                if (p.Info < theInfo)
                {
                    p = p.Next;

                }
                else if (p.Info == theInfo)
                    found = true;
                else
                    p = null;                    
            }
            return p;
        }

        //-------------------------------------------------------
        //------------------------------------------------
        //Tìm theInfo trong danh sách có thứ tự tăng dần
        //Trả về: true nếu có, không có trả false

        public bool FindOrder_bool(int theInfo)
        {
            bool found = false;  // cờ tìm thấy chưa
            Item p = First; // p là phần tử đầu tiên
            // p là phần tử của danh sách và chưa tìm thấy
            while ((p != null) && !found)
            {
                if (p.Info < theInfo)
                {
                    p = p.Next;

                }
                else if (p.Info == theInfo)
                    found = true;
                else
                    p = null;
            }
            return found;
        }
        #endregion

        #region Loại bỏ key trong LinkedList
        // Loại bỏ theInfo trong danh sách chưa có thứ tự
        // Tham số tham khảo:
        //  - error: false nếu theInfo được tìm thấy
        //          : true nếu theInfo không được tìm thấy
        public void Remove(int  theInfo, out bool error)
        {
            // Tìm theInfor trong danh sách 
            bool found = false;
            Item p = First;
            Item before_p = null;
            while ((p != null) && !found)
            {
                if (p.Info == theInfo)
                {
                    found = true;
                }
                else
                {
                    before_p = p;
                    p = p.Next;
                }    
            }    
            if (found)
            {
                // loại bỏ p
                if (p == First)
                    First = p.Next;
                else
                    before_p.Next = p.Next;
                p = null;
                Count--;
            }    
            error = !found;
        }

        //---------------------------------------------------
        // Loại bỏ theInfo trong danh sách có thứ tự tăng dần
        // Tham số tham khảo:
        //  - error: false nếu theInfo được tìm thấy
        //          : true nếu theInfo không được tìm thấy
        public void RemoveOrder(int theInfo, out bool error)
        {
            // Tìm theInfor trong danh sách 
            bool found = false;
            Item p = First;
            Item before_p = null;
            while ((p != null) && !found)
            {
                if (p.Info == theInfo)
                {
                    found = true;
                }
                else if (p.Info < theInfo)
                {
                    before_p = p;
                    p = p.Next;
                }   
                else
                {
                    p = null;
                }
            }
            if (found)
            {
                // loại bỏ p
                if (p == First)
                    First = p.Next;
                else
                    before_p.Next = p.Next;
                p = null;
                Count--;
            }
            error = !found;
        }
        #endregion

        #region Hiển thị danh sách
        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Danh sach rong");
            }    
            else
            {
                Console.WriteLine("Noi dung cua danh sach:");
                Item p = First;
                while (p != null)
                {
                    p.Display();
                    p = p.Next;
                }
                Console.WriteLine("So phan tu: " + Count);
            }    
        }
        #endregion

        #region Hủy bỏ danh sách
        public void Clear()
        {
            Item p = null;
            while (First != null)
            {
                p = First;
                First = p.Next;
                p = null;
            }
            Count = 0;
        }
        ~LinkedList()
        {
            Clear();
        }
        #endregion
    }

    class Item
    {
        public int Info; // content of item
        public Item Next; // pointer to the next item

        // Constructure: create the item with content is theInfo
        public Item(int theInfo)
        {
            Info = theInfo;
            Next = null;
        }

        // Constructure: Create Item null
        public Item()
        {             
        }

        // Display the Linked List
        public void Display()
        {
            Console.WriteLine(Info);
        }

    }
}
