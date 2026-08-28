using System;
using System.Collections.Concurrent;

namespace CircleAssessment
{
    internal class Program
    {
        class Circle
        {
            public double radius;
            public string colour;
            public double length;

            // 1. Default Constructor
            public Circle()
            {
                radius = 1.0;
                colour = "red";
            }

            // 2. Only radius
            public Circle(double radius)
            {
                this.radius = radius;
                this.colour = "red"; // default
            }

            // 3. Radius + Color
            public Circle(double radius, string colour)
            {
                this.radius = radius;
                this.colour = colour;
            }

            // 4. Copy Constructor (Deep Copy)
            public Circle(Circle c)
            {
                this.radius = c.radius;
                this.colour = c.colour;
            }
            public double getarea()
            {
                double area = radius * radius;
                return area;
            }
            public double getdiameter()
            {
                double diameter = 2 * radius;
                return diameter;
            }
            public double getcirc()
            {
                double circ = 2 * Math.PI * radius;
                return circ;

            }
            /*public double Values()
            {
                
                {
                    if (radius == 22 && length == 15)
                    {
                        return getarea();
                    }
                    if (radius == 33.14 && length == 30)
                    {
                        return getdiameter();
                    }
                    if (radius == 10 && length == 45)
                    {
                        return getcirc();
                    }
                    return getcirc();
                }
            }
        }*/

            static void Main(string[] args)
            {
                Circle c1 = new Circle();               // default
                Circle c2 = new Circle(5.0);            // radius only
                Circle c3 = new Circle(3.5, "Blue");    // radius + color
                Circle c4 = new Circle(c3);             // copy constructor

                Console.WriteLine($"c1: {c1.radius}, {c1.colour}");
                Console.WriteLine($"c2: {c2.radius}, {c2.colour}");
                Console.WriteLine($"c3: {c3.radius}, {c3.colour}");

                // Deep copy test
                c4.colour = "Green";
                Console.WriteLine($"c3 after change: {c3.colour}"); // Blue (unchanged)
                Console.WriteLine($"c4 after change: {c4.colour}"); // Green

                Circle p = new Circle();
                p.radius = 22;
                p.length = 15;
                Console.WriteLine($" AREA IS :  { p.getarea()}");
                Circle p2 = new Circle();
                p.radius = 22.3;
                p.length = 30;
                Console.WriteLine($" DIAMETER IS : {p.getdiameter()}");
                Circle p3 = new Circle();
                p.radius = 33.13;
                p.length = 50;
                Console.WriteLine($" Circumference is : {p.getcirc()}");
            }
        }
    }
}

// SOME SHORT TRICKS 

// string name = "Ali Hassnain";
//string phone = "0328-002200-7";
//name=name.ToUpper();
// name=name.ToLower();
//phone = phone.Replace("-" , "/");

//Console.WriteLine(name.Length);
// string fullname=name. Insert(0," @");
//Console.WriteLine(fullname);
// string firstname=name.Substring(0,3);
//string lastname = name.Substring(4, 8);
// Console.WriteLine(firstname);
//Console.WriteLine(lastname);
//Console.WriteLine(name);
//Console.WriteLine(phone);
/* Console.WriteLine("Enter number of rows : ");
 int r = int.Parse(Console.ReadLine());
 Console.WriteLine("Enter number of coloumns : ");
 int c=int.Parse(Console.ReadLine());
 Console.WriteLine("Enter symbol which you want ");
 char s=char.Parse(Console.ReadLine());
 for (int i = 0; i < r; i++)
 {
     for (int j = 0; j < c; j++)
     {
         Console.Write(s);
         }
     Console.WriteLine();*/
//}



// ARRAYS CONCEPTS LITTLE BIT 
/*string[] cars = new string[5];
for (int i = 0; i < 5; i++)
{
    Console.ReadLine();

}
Console.ReadLine();*/
/* string[] car = { "BMW", "COROLLA", "CIVIC", "FERRARI" };
 for (int i = 0; i < car.Length; i++)
 {
     Console.WriteLine(car[i]);
 }*/



/* foreach loop less useable as compared to for loop but more usefull in list 
string[] car = { "BMW", "COROLLA", "CIVIC", "FERRARI" };
foreach (string s in car)
{
    Console.WriteLine(s);
}*/
// method  = performs a section of code, whenever it's called "invoked".
//           benefit = Let's us reuse code w/o writing it multiple times
//           Good practice is to capitalize method names (I forgot in this video)



/* VOID STATEMENTS IN C#
String name = "Bro";
int age = 21;

SingHappyBirthday(name, age);

Console.ReadKey();
}
static void SingHappyBirthday(String birthdayBoy, int yearsOld)
{
Console.WriteLine("Happy birthday to you!");
Console.WriteLine("Happy birthday to you!");
Console.WriteLine("Happy birthday dear " + birthdayBoy);
Console.WriteLine("You are " + yearsOld + " years old!");
Console.WriteLine("Happy birthday to you!");
Console.WriteLine();
}*/


//params keyword it is used when multiple paramteres have to passs.

//double price = check(42, 3.33, 22, 11);
//Console.WriteLine(price);
//Console.ReadKey();


// handle exceution errors 
/*try
{
    Console.WriteLine("Enter first  number ");
    double a = double.Parse(Console.ReadLine());

    Console.WriteLine("Enter second  number ");
    double b = double.Parse(Console.ReadLine());

    double y = a / b;
    Console.WriteLine($"Your Answer is : {y}");
}
catch(FormatException)   //only use when we use other type of datatype eg:string ,char,bool.
{
    Console.WriteLine(" You cn only use values");
    }
catch(DivideByZeroException)    //only use when we divide by zero 
{
    Console.WriteLine("You cannot be divide by zero");
}
catch(Exception)    //it can handle all excuetion errors
{
    Console.WriteLine("Somethimg went wrong ");

}

finally             // to show msg on the last of the program
{
    Console.WriteLine("Thanks for using our system");
}


}*/
// 2D arrays

/* String[,] parkingLot = { { "Mustang", "F-150", "Explorer" },
                                     { "Corvette", "Camaro", "Silverado" },
                                     { "Corolla", "Camry", "Rav4" }
                                   };

  parkingLot[0, 2] = "Fusion";
  parkingLot[2, 0] = "Tacoma";
  /*
  foreach(String car in parkingLot)
  {
      Console.WriteLine(car);
  }

  for (int i = 0; i < parkingLot.GetLength(0); i++)
  {
      for (int j = 0; j < parkingLot.GetLength(1); j++)
      {
          Console.Write(parkingLot[i, j] + " ");
      }
      Console.WriteLine();
  }*/
//  oop obj = new oop(12, 1208, "AliHassnain", "33104"); //parameterized constructor 
// oop.hello(); // directly called by class
// oop.eat();   // directly called by class
//  Console.ReadKey();


// List = data structure that represents a list of objects that can be accessed by index.
//        Similar to array, but can dynamically increase/decrease in size 
//        using System.Collections.Generic;

/* List<String> food = new List<String>();

 food.Add("pizza");
 food.Add("hamburger");
 food.Add("hotdog");
 food.Add("fries");*/

//Console.WriteLine(food[0]);
//Console.WriteLine(food[1]);
//Console.WriteLine(food[2]);
//Console.WriteLine(food[3]);

//food.Remove("fries");
//food.Insert(0, "sushi");
//Console.WriteLine(food.Count);
//Console.WriteLine(food.IndexOf("pizza"));
//Console.WriteLine(food.LastIndexOf("fries"));
//Console.WriteLine(food.Contains("pizza"));
//food.Sort();
//food.Reverse();
//food.Clear();
//String[] foodArray = food.ToArray();

//  foreach (String item in food)
//   {
//Console.WriteLine(item);
//   }

// Console.ReadKey();



/*static double check(params double[] x)
{
    double total = 0;
    foreach (double d in x)
    {
        total += d;
    }
    return total;
}*/




