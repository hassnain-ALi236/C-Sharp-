/*using System;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Remoting.Services;

namespace mids
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @" E:\Hassnain BSCS\oop class.txt";
            string[] name = new string[500];
            string[] password = new string[500];
            int option;
            do
            {
                readdata(path, name, password);
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string p = Console.ReadLine();
                    signIn(n, p, name, password);
                    Console.ReadKey();
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name ");
                    string x = Console.ReadLine();
                    Console.WriteLine("Enter New Password ");
                    string P = Console.ReadLine();
                    bool check = sign_up(path, x, P);
                    if (check)
                        Console.WriteLine("SIGN UP SUCCESSFULL ");
                    else
                        Console.WriteLine("SIGN UP  NOT SUCCESS FULL ");
                    Console.ReadKey();
                }
            }
            while(option < 3);
            }
    
        

        static void readdata(string path, string[] name, string[] password)
        {
            int x = 0;

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string record;
                    while ((record = sr.ReadLine()) != null)
                    {
                        name[x] = parseData(record, 1);
                        password[x] = parseData(record, 2);
                        x++;

                        if (x >= 500)
                        {
                            break;
                        }
                    }
                }
            }
        }

        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";

            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item += record[x];
                }
            }

            return item;
        }
        static bool signIn(string n, string p ,string[] name , string[] password)
        {
            for (int x=0;x<5; x++ )
            {
                if (n == name[x] && p == password[x])
                    return true;
            }
            return false;
            Console.ReadKey();
        }
        static bool sign_up(string path, string n, string p)
        {
            using (StreamWriter file = new StreamWriter(path, true))
            {
                file.WriteLine(n + "," + p);
            }
            return true;
            Console.ReadKey();
        }
        static int menu ()
        {
            int option;
            Console.WriteLine("1-Sign in ");
            Console.WriteLine("2-Sign up ");
            Console.WriteLine("3- Exit ");
            Console.WriteLine("Enter Option ");
            option = int.Parse(Console.ReadLine());
            return option;

        }
    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace shallow
{
    internal class Program
    {

        class Student
        {


            public string name;

            public int age;
            public Student(string n, int a)
            {
                name = n;

                age = a;

            }




        }
        static void Main(string[] args)
        {
            Student s = new Student("ahmad", 19);



            Student s1 = s;


            Console.WriteLine(s1.name);

            Console.WriteLine(s.name);


            s1.name = "ali";

            Console.WriteLine(s1.name);

            Console.WriteLine(s.name);



        }
    }
}
*shallow copy */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace parameterized
{
    internal class Program
    {

        class Student
        {


            /*   public string name;

               public int age;
               public Student(string n, int a)
               {
                   name = n;

                   age = a;

               }

               public Student(Student s)
               {
                   name = s.name;

                   age = s.age;
               }


           }
           static void Main(string[] args)
           {
               Student s = new Student("ahmad", 19);

               Console.WriteLine(s.name);

               Console.WriteLine(s.age);

               Student s1 = new Student(s);

               s1.name = "ali";

               Console.WriteLine(s1.name);

               Console.WriteLine(s1.age);*/

            class Car
            {
                public string Brand = "Civic";
                public int Year = 2026;
                public string Model = "New";

                public void CarInfo()
                {
                    Console.WriteLine("Brand: " + Brand);
                    Console.WriteLine("Model: " + Model);
                    Console.WriteLine("Year: " + Year);
                }
            }

            class Program
            {
                static void Main()
                {
                    Car car1 = new Car();
                    car1.CarInfo();
                }
            }

        }
    }
}
