using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9
{
    internal class Program
    {
        static List<student> studentList = new List<student>(); static List<student> sortedStudentList = new List<student>(); static List<degreeprogram> programList = new List<degreeprogram>(); static void Main(string[] args)
        {
            int option; do
            {
                option = Menu();
                Console.Clear();

                if (option == 1)
                {
                    if (programList.Count > 0)
                    {
                        student s = takeInputForStudent(); studentList.Add(s);
                    }
                    else
                    {
                        Console.WriteLine("Add degree programs first!");
                    }
                }
                else if (option == 2)
                {
                    degreeprogram d = takeInputForDegree(); programList.Add(d);
                }
                else if (option == 3)
                {
                    sortStudentsByMerit();
                    giveAdmission(); printStudents();
                }
                else if (option == 4)
                {
                    viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    Console.Write("Enter Degree Name: "); string degName = Console.ReadLine(); viewStudentsInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter Student Name: "); string name = Console.ReadLine(); student s = studentPresent(name);
                    if (s != null)
                    {
                        viewSubjects(s); registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    calculateFee();
                }

                Console.WriteLine("\nPress any key...");
                Console.ReadKey();

            } while (option != 8);
        }

        static int Menu()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit & Admissions");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Degree");
            Console.WriteLine("6. Register Subjects");
            Console.WriteLine("7. Calculate Fee");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Option: "); return int.Parse(Console.ReadLine());
        }

        static student takeInputForStudent()
        {
            Console.Write("Name: "); string name = Console.ReadLine();

            Console.Write("Age: "); int age = int.Parse(Console.ReadLine()); Console.Write("FSC Marks: "); double fsc = double.Parse(Console.ReadLine());

            Console.Write("ECAT Marks: "); double ecat = double.Parse(Console.ReadLine());

            List<degreeprogram> pref = new List<degreeprogram>();

            Console.WriteLine("Available Programs:"); foreach (degreeprogram d in programList)
            {
                Console.WriteLine(d.degreename);
            }

            Console.Write("Enter preference (degree name): "); string pname = Console.ReadLine();

            foreach (degreeprogram d in programList)
            {
                if (d.degreename == pname)
                {
                    pref.Add(d);
                }
            }

            student s = new student(name, age, fsc, ecat, pref);
            s.calculateMerit(); return s;
        }

        static degreeprogram takeInputForDegree()
        {
            Console.Write("Degree Name: "); string name = Console.ReadLine();

            Console.Write("Duration: "); float duration = float.Parse(Console.ReadLine());

            Console.Write("Seats: "); int seats = int.Parse(Console.ReadLine());

            return new degreeprogram(name, duration, seats);
        }

        static void sortStudentsByMerit()
        {
            sortedStudentList = studentList.OrderByDescending(s => s.merit).ToList();
        }

        static void giveAdmission()
        {
            foreach (student s in sortedStudentList)
            {
                foreach (degreeprogram d in s.preferences)
                {
                    if (d.seats > 0)
                    {
                        s.regdegree = d;
                        d.seats--; break;
                    }
                }
            }
        }

        static void printStudents()
        {
            foreach (student s in studentList)
            {
                Console.WriteLine(s.name + " -> " +
                    (s.regdegree != null ? s.regdegree.degreename : "Not Selected"));
            }
        }

        static student studentPresent(string name)
        {
            return studentList.Find(s => s.name == name);
        }

        static void viewRegisteredStudents()
        {
            foreach (student s in studentList)
            {
                if (s.regdegree != null)
                {
                    Console.WriteLine(s.name);
                }
            }
        }

        static void viewStudentsInDegree(string degName)
        {
            foreach (student s in studentList)
            {
                if (s.regdegree != null && s.regdegree.degreename == degName)
                {
                    Console.WriteLine(s.name);
                }
            }
        }

        static void viewSubjects(student s)
        {
            if (s.regdegree != null)
            {
                foreach (subject sub in s.regdegree.subjects)
                {
                    Console.WriteLine(sub.code);
                }
            }
        }

        static void registerSubjects(student s)
        {
            Console.Write("Enter subject code: ");
            string code = Console.ReadLine();

            foreach (subject sub in s.regdegree.subjects)
            {
                if (sub.code == code)
                {
                    s.registerSubject(sub);
                }
            }
        }

        static void calculateFee()
        {
            foreach (student s in studentList)
            {
                Console.WriteLine(s.name + " Fee: " + s.calculateFee());
            }
        }

        class student
        {
            public string name; public int age; public double fscmarks; public double ecatmarks; public double merit;

            public List<degreeprogram> preferences; public List<subject> regsubject;

            public degreeprogram regdegree;

            public student(string name, int age, double fscmarks, double ecatmarks, List<degreeprogram> preferences)
            {
                this.name = name; this.age = age; this.fscmarks = fscmarks; this.ecatmarks = ecatmarks; this.preferences = preferences; regsubject = new List<subject>();
            }

            public void calculateMerit()
            {
                merit = (fscmarks * 0.5) + (ecatmarks * 0.5);
            }

            public int getCreditHours()
            {
                int total = 0; foreach (subject s in regsubject)
                {
                    total += s.credithours;
                }
                return total;
            }

            public float calculateFee()
            {
                float total = 0; foreach (subject s in regsubject)
                {
                    total += s.subjectfees;
                }
                return total;
            }

            public void registerSubject(subject s)
            {
                int stch = getCreditHours();

                if (regdegree != null && regdegree.isSubjectExists(s) && stch + s.credithours <= 9)
                {
                    regsubject.Add(s);
                }
                else
                {
                    Console.WriteLine("Invalid subject or credit limit exceeded");
                }
            }
        }

        class subject
        {
            public string code; public string type; public int credithours; public int subjectfees;

            public subject(string code, string type, int credithours, int subjectfees)
            {
                this.code = code; this.type = type; this.credithours = credithours; this.subjectfees = subjectfees;
            }
        }

        class degreeprogram
        {
            public string degreename; public float degreeduration; public int seats;

            public List<subject> subjects;

            public degreeprogram(string degreename, float degreeduration, int seats)
            {
                this.degreename = degreename; this.degreeduration = degreeduration; this.seats = seats; subjects = new List<subject>();

                subjects.Add(new subject("CS101", "Core", 3, 1000)); subjects.Add(new subject("MTH101", "Core", 3, 1200));
            }

            public int calculateCreditHours()
            {
                int total = 0; foreach (subject s in subjects)
                {
                    total += s.credithours;
                }
                return total;
            }

            public bool isSubjectExists(subject sub)
            {
                foreach (subject s in subjects)
                {
                    if (s.code == sub.code) return true;
                }
                return false;
            }
        }
    }
}