using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_лр_1_задание_1_ур
{
    //Объявление структуры вне класса 
    struct member
    {
        public string surname;
        public string society;
        public int attempt1;
        public int attempt2;
        public member(string sur, string soc, int a1, int a2)
        {
            surname = sur;
            society = soc;
            attempt1 = a1;
            attempt2 = a2;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            const int N = 3;

            member[] members = new member[N];
            for (int i = 0; i < N; i++)
            {

                Console.WriteLine("enter surname for member number:" + (i + 1));
                string sur = Console.ReadLine();
                Console.WriteLine("enter society for member number:" + (i + 1));
                string soc = Console.ReadLine();
                Console.WriteLine("enter attempt1 for member number:" + (i + 1));
                int a1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("enter attempt2 for member number:" + (i + 1));
                int a2 = Convert.ToInt32(Console.ReadLine());
                members[i] = new member(sur, soc, a1, a2);
            }
            /*for(int i = 0; i < N; i++)
            {
                Console.WriteLine(members[i].surname + " " + members[i].society + " " + members[i].rez1 + " " + members[i].rez2);
            }
            */
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < N - 1; i++)
                {
                    if ((members[i].getRez1() + members[i].getRez2()) < (members[i + 1].getRez1() + members[i + 1].getRez2()))
                    {
                        member buf = members[i];
                        members[i] = members[i + 1];
                        members[i + 1] = buf;
                        flag = true;
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("surname society attempt1 attempt2");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(members[i].getSurname() + " " + members[i].getSociety() + " " + members[i].getRez1() + " " + members[i].getRez2());
            }
        }
        //Объявление структуры внутри класса
        struct member
        {

            private string society;
            private string surname;
            private double rez1;
            private double rez2;

            public string getSociety()
            {
                return society;
            }
            public string getSurname()
            {
                return surname;
            }

            public double getRez1()
            {
                return rez1;
            }
            public double getRez2()
            {
                return rez2;
            }

            public member(string sur, string soc, int a1, int a2)
            {
                surname = sur;
                society = soc;
                rez1 = a1;
                rez2 = a2;
            }
        }



    }

}
