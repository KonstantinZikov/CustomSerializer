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
            s s1 = new s();
            s1.Hello = "OLOLO";
            B b1 = new B();
            b1.a = 42;
            b1.c = 333;
            b1.t = new T();
            b1.e = s1;


            Console.WriteLine(b1.GetType().FullName);
            Console.WriteLine(b1.Get());
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(b1, ms);
                ms.Seek(0, SeekOrigin.Begin);
                B b2 = Serializer.Deserialize(ms) as B;
                Console.WriteLine(b2.Get());
            }
            Console.ReadKey();    


        }
    }
}
