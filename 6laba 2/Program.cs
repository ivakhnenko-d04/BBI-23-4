using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6laba_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 5;
            Console.WriteLine("Hello, World!");
            session sess = new session();
            sess.students = new student[N];
            for (int i = 0; i < N; i++)
            {
                int[] marks = new int[4];
                Console.WriteLine("enter marks for the student" + (i + 1));
                for (int j = 0; j < 4; j++)
                    marks[j] = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter name");
                string name = Console.ReadLine();
                sess.students[i] = new student(marks, name);

            }
            /* for (int i = 0; i < N; i++)
             {
                 Console.WriteLine(sess.students[i].name + " " + sess.students[i].marks[0] + " " + sess.students[i].marks[1] + " " + sess.students[i].marks[2] + " " + sess.students[i].marks[3] + " average " + sess.students[i].averageMark );
             }
            */
            Console.WriteLine();
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (sess.students[i].getAverageMark() < sess.students[i + 1].getAverageMark())
                    {
                        student buf = sess.students[i];
                        sess.students[i] = sess.students[i + 1];
                        sess.students[i + 1] = buf;
                        flag = true;

                    }
                }

            }
            Console.WriteLine("name" + " mark1 " + " mark2 " + " mark3 " + " mark3 " + " mark4 " + " averageMark ");
            for (int i = 0; i < N; i++)
            {
                if (sess.students[i].getAverageMark() > 4)
                    Console.WriteLine(sess.students[i].getName() + " " + sess.students[i].getMarks()[0] + " " + sess.students[i].getMarks()[1] + " " + sess.students[i].getMarks()[2] + " " + sess.students[i].getMarks()[3] + " average " + sess.students[i].getAverageMark());
            }


        }
        struct session
        {
            public student[] students;
        }
        struct student
        {
            private int[] marks;
            private string name;
            private double averageMark;

            public int[] getMarks()
            {
                return marks;
            }
            public string getName()
            {
                return name;
            }

            public double getAverageMark()
            {
                return averageMark;
            }

            public student(int[] m, string n)
            {
                marks = m;
                name = n;
                averageMark = 0;
                averageMark = calculateAverageMark();
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

    }

}


