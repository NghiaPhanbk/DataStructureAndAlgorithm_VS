using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exsecises
{
    public class Singleton
    {
        private static Singleton instance; // tạo một thể hiện duy nhất
        public static Singleton Instance
        {
            // có thể đọc giá trị từ bên ngoài lớp
            get {  
                if (instance == null)
                    instance = new Singleton();
                    return Singleton.instance;
            }
            private set { Singleton.instance = value; } // chỉ có thể truy cập trong lớp
        }
        private Singleton() { } // hàm tạo (constructor) set private nên chỉ có thể tạo trong lớp
    }
}
