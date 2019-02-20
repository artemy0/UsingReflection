using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 4;

            TypeInfo typeInfo = new TypeInfo(a);

            typeInfo.ShowType();
            typeInfo.ShowShortInformation();


            string str = "Hello World!";

            TypeInfo typeInfo2 = new TypeInfo(str);

            typeInfo2.ShowType();
            typeInfo2.ShowShortInformation();

            Console.ReadKey();
        }
    }
}
