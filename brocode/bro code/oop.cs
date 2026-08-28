using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bro_code
{
    internal class oop
    {
      public static void hello()
        {
            Console.WriteLine("Hello how are you : ");
        }
        public static void eat()
        {
            Console.WriteLine("which vegetable you most like");
        }
        int a, b;
        string c, d;
        public oop ( int age,int rno,string name,string cnic)
        {
            a = age;
            b = rno;
            c = name;
            d = cnic;
           // Console.WriteLine($"Age: {a}, RollNo: {b}, Name: {c}, CNIC: {d}");
        }
    }
    }

