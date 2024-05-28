using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Subject
{
    public int Mark { get; set; }
}

public class Group
{
    private string _group;
    private string _potok;
    private Subject _hist;
    private Subject _engl;
    private Subject _math;
    private Subject _phys;
    private Subject _progr;

    public Group(string group, string potok, int hist, int engl, int math, int phys, int progr)
    {
        _group = group;
        _potok = potok;
        _hist = new Subject() { Mark = hist };
        _engl = new Subject() { Mark = engl };
        _math = new Subject() { Mark = math };
        _phys = new Subject() { Mark = phys };
        _progr = new Subject() { Mark = progr };
    }

    public string GroupName { get => _group; }

    public string Stream { get => _potok; }

    public void CalculateAverage(ref double average)
    {
        double sum = _hist.Mark + _engl.Mark + _math.Mark + _phys.Mark + _progr.Mark;
        average = sum / 5;
    }

    public virtual void Print(double average)
    {
        Console.WriteLine("Potok: {0, 10} Group: {1, 10} Average: {2, 10} ", _potok, _group, average);
    }
}

public class GroupA : Group
{
    private Subject _additionalSubject1;
    private Subject _additionalSubject2;

    public GroupA(string group, string potok, int hist, int engl, int math, int phys, int progr, int additionalSubject1, int additionalSubject2)
        : base(group, potok, hist, engl, math, phys, progr)
    {
        _additionalSubject1 = new Subject() { Mark = additionalSubject1 };
        _additionalSubject2 = new Subject() { Mark = additionalSubject2 };
    }

    public override void Print(double average)
    {
        Console.WriteLine("Potok: {0, 10} Group: {1, 10} Average: {2, 10} ", Stream, GroupName, average);
    }
}

public class GroupB : Group
{
    private Subject _additionalSubject3;
    private Subject _additionalSubject4;

    public GroupB(string group, string potok, int hist, int engl, int math, int phys, int progr, int additionalSubject3, int additionalSubject4)
        : base(group, potok, hist, engl, math, phys, progr)
    {
        _additionalSubject3 = new Subject() { Mark = additionalSubject3 };
        _additionalSubject4 = new Subject() { Mark = additionalSubject4 };
    }

    public override void Print(double average)
    {
        Console.WriteLine("Potok: {0, 10} Group: {1, 10}  Average: {2, 10} ", Stream, GroupName, average);
    }
}

public class GroupC : Group
{
    private Subject _additionalSubject5;
    private Subject _additionalSubject6;

    public GroupC(string group, string potok, int hist, int engl, int math, int phys, int progr, int additionalSubject5, int additionalSubject6)
        : base(group, potok, hist, engl, math, phys, progr)
    {
        _additionalSubject5 = new Subject() { Mark = additionalSubject5 };
        _additionalSubject6 = new Subject() { Mark = additionalSubject6 };
    }

    public override void Print(double average)
    {
        Console.WriteLine("Potok: {0, 10} Group: {1, 10} Average: {2, 10} ", Stream, GroupName, average);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Group[] groups = new Group[7];
        groups[0] = new Group("1", "pp", 4, 5, 3, 4, 5);
        groups[1] = new GroupA("4", "ty", 5, 5, 4, 3, 4, 4, 5);
        groups[2] = new GroupA("2", "pp", 4, 4, 5, 5, 3, 3, 4);
        groups[3] = new Group("3", "pp", 4, 4, 3, 4, 4);
        groups[4] = new GroupB("1", "ww", 4, 3, 3, 5, 5, 5, 2);
        groups[5] = new GroupB("2", "pp", 3, 3, 4, 4, 5, 4, 3);
        groups[6] = new GroupC("3", "ww", 5, 4, 4, 5, 3, 5, 4);

        double[] averages = new double[groups.Length];

        int index = 0;
        foreach (Group group in groups)
        {
            group.CalculateAverage(ref averages[index]);
            index++;
        }

        Array.Sort(averages, groups);
        foreach (Group group in groups)
        {
            double average = 0;
            group.CalculateAverage(ref average);
            group.Print(average);
        }
    }
}

