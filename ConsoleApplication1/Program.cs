using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomSerializer;
using System.IO;
using System.Reflection;

namespace ConsoleApplication1
{
    class Program
    {
        [Serializable]
        class T
        {
            bool t = true;

            public bool Get()
            {
                return t;
            }
        }

        [Serializable]
        struct s
        {
            public string Hello;
        }

        [Serializable]
        class A
        {
            public int a;
            public T t;
        }

        [Serializable]
        class B : A
        {
            public decimal c;

            public s e;

            public string Get()
            {
                return "" + c + " " + a + " " + t.Get() + " " + e.Hello;
            }
                
        }


        static void Main(string[] args)
        {
            int[] arr = new int[]
            {
                5,4,3,2,1
            };
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(arr, ms);
                ms.Seek(0, SeekOrigin.Begin);
                var arr2 = Serializer.Deserialize(ms) as int[];
                foreach(int i in arr2)
                {
                    Console.WriteLine(i);
                }
            }
            Console.ReadKey();    


        }
    }
}
