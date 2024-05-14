using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_лаб_3_ур_1_зад_е
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 3;
            const int marksNumber = 3;
            Console.WriteLine("Hello, World!");
            session sess = new session();
            sess.groups = new group[N];
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("enter group name : " + (i + 1));
                string groupName = Console.ReadLine();
                Console.WriteLine("enter marks");
                int[] marks = new int[marksNumber];
                for (int j = 0; j < marksNumber; j++)

                    marks[j] = Convert.ToInt32(Console.ReadLine());
                sess.groups[i] = new group(marks, groupName);




            }
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if (sess.groups[i].getAverageMark() < sess.groups[i + 1].getAverageMark())
                    {
                        group buf = sess.groups[i];
                        sess.groups[i] = sess.groups[i + 1];
                        sess.groups[i + 1] = buf;
                        flag = true;

                    }
                }

            }
            Console.WriteLine("Average marks for groups");
            for (int i = 0; i < N; i++)
                Console.WriteLine(sess.groups[i].getGroupName() + " " + sess.groups[i].getAverageMark());
        }


        struct session
        {
            public group[] groups;
        }
        struct group
        {
            private int[] marks;
            private string groupName;
            private double averageMark;

            public int[] getMarks()
            {
                return marks;
            }
            public string getGroupName()
            {
                return groupName;
            }

            public double getAverageMark()
            {
                return averageMark;
            }

            public group(int[] m, string n)
            {
                marks = m;
                groupName = n;
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
