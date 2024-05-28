using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ConsoleApp22
{
    struct session
    {
        public Student[] students;
    }
    class Human
    {
        private string fullName;
        private double averageMark;
        private int[] marks;
        public Human(string fullName, int[] m)
        {
            this.fullName = fullName;
            marks = m;
            this.averageMark = calculateAverageMark();
        }
        public string getFullName()
        {
            return fullName;
        }

        public double getAverageMark()
        {
            return averageMark;
        }
        double calculateAverageMark()
        {
            double a = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                a += marks[i];
            }
            a = a / marks.Length;
            return a;
        }
    }

    class Student : Human
    {
        private int studentID;
        public Student(int[] m, string n, int s) : base(n, m)
        {
            studentID = s;
        }
        public int getStudentID()
        {
            return studentID;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 3;
            session sess = new session();
            sess.students = new Student[N];
            int studentID = 1;
            for (int i = 0; i < N; i++)
            {
                int[] marks = new int[4];
                Console.WriteLine("enter marks for the student" + (i + 1));
                for (int j = 0; j < 4; j++)
                    marks[j] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter fullName");
                string name = Console.ReadLine();
                sess.students[i] = new Student(marks, name, studentID);
                studentID++;

            }

            Console.WriteLine();
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (sess.students[i].getAverageMark() < sess.students[i + 1].getAverageMark())
                    {
                        Student buf = sess.students[i];
                        sess.students[i] = sess.students[i + 1];
                        sess.students[i + 1] = buf;
                        flag = true;

                    }
                }

            }
            Console.WriteLine(" fullName " + " studentID " + " averageMark ");
            for (int i = 0; i < N; i++)
            {
                if (sess.students[i].getAverageMark() > 4)
                    Console.WriteLine(sess.students[i].getFullName() + " studentID " + sess.students[i].getStudentID() + " average " + sess.students[i].getAverageMark());
            }
        }

    }

}
