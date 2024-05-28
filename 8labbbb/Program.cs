using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

abstract class Task
{
    protected string Text { get; set; }

    public Task(string text)
    {
        Text = text;
    }

    public abstract void ParseText();


    public override string ToString()
    {
        return GetType().Name + ": " + Environment.NewLine + GetResult();
    }

    protected abstract string GetResult();

}
class Task_1 : Task
{
    private Dictionary<char, double> _letterFrequencies;

    public Task_1(string text) : base(text) { }

    public override void ParseText()
    {
        _letterFrequencies = new Dictionary<char, double>();
        int totalLetters = 0;

        foreach (char c in Text.ToLower())
        {
            if (char.IsLetter(c))
            {
                if (_letterFrequencies.ContainsKey(c))
                {
                    _letterFrequencies[c]++;
                }
                else
                {
                    _letterFrequencies[c] = 1;
                }
                totalLetters++;
            }
        }


        foreach (char c in _letterFrequencies.Keys.ToList())
        {
            _letterFrequencies[c] /= totalLetters;
        }
    }

    protected override string GetResult()
    {
        StringBuilder result = new StringBuilder();
        foreach (var kvp in _letterFrequencies)
        {
            result.AppendLine($"{kvp.Key}: {kvp.Value:P2}");
        }
        return result.ToString();
    }
}

class Task_3 : Task
{
    private List<string> _lines;
    public Task_3(string text) : base(text) { }

    public override void ParseText()
    {
        _lines = new List<string>();
        StringBuilder currentLine = new StringBuilder();
        foreach (string word in Text.Split(' '))
        {
            if (currentLine.Length + word.Length + 1 <= 50)
            {
                currentLine.Append(word).Append(' ');
            }
            else
            {
                _lines.Add(currentLine.ToString().TrimEnd());
                currentLine.Clear();
                currentLine.Append(word).Append(' ');
            }
        }
        _lines.Add(currentLine.ToString().TrimEnd());
    }
    protected override string GetResult()
    {
        return string.Join(Environment.NewLine, _lines);
    }
}

internal class Task_5 : Task
{
    public Task_5(string text) : base(text)
    {
    }

    public override void ParseText()
    {
        throw new NotImplementedException();
    }

    public string Process(string input)
    {
        Dictionary<char, int> frequencyMap = new Dictionary<char, int>();

        string[] words = input.Split(' ');
        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                char firstLetter = char.ToLower(word[0]);
                if (char.IsLetter(firstLetter))
                {
                    if (frequencyMap.ContainsKey(firstLetter))
                    {
                        frequencyMap[firstLetter]++;
                    }
                    else
                    {
                        frequencyMap.Add(firstLetter, 1);
                    }
                }
            }
        }

        var sortedMap = frequencyMap.OrderByDescending(pair => pair.Value);

        StringBuilder result = new StringBuilder();
        foreach (var pair in sortedMap)
        {
            result.AppendLine($"Буква '{pair.Key}': {pair.Value}");
        }

        return result.ToString();
    }

    protected override string GetResult()
    {
        throw new NotImplementedException();
    }
}
internal class Task_7 : Task
{
    private string root = "";
    private string text;

    public Task_7(string text) : base(text)
    {
        this.text = text;
    }

    public override void ParseText()
    {
        string[] words = text.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            if (word.Contains(root))
                Console.WriteLine(word);
        }
    }

    protected override string GetResult()
    {
        return "Результат обработки Task_7";
    }
}
internal class Task_11 : Task
{
    public Task_11(string text) : base(text)
    {
    }

    public override void ParseText()
    {
        throw new NotImplementedException();
    }

    public void surnamesorter()
    {
        string[] Surname = Text.Split(',', ' ');
        for (int i = 0; i < Surname.Length; i++)
            for (int j = 0; j < Surname.Length - 1; j++)
            {
                if (Surname[i][0] < Surname[j][0])
                {
                    string temp = Surname[i];
                    Surname[i] = Surname[j];
                    Surname[j] = temp;
                }
            }
        foreach (string word in Surname)
        {
            Console.WriteLine(word);
        }

    }

    protected override string GetResult()
    {
        throw new NotImplementedException();
    }
}

internal class Task_14 : Task
{
    public Task_14(string text) : base(text)
    {
    }

    public override void ParseText()
    {
        throw new NotImplementedException();
    }

    public void summer()
    {
        string[] words = Text.Split(new char[] { ' ', ',', '.', '-', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        int k = 0;
        foreach (string word in words)
        {

            foreach (char chars in word)
            {
                if (Char.IsDigit(word[0]))
                {

                    k += int.Parse(word);
                    break;

                }
            }

        }
        Console.WriteLine("Сумма цифр в тексте - {0}", k);


    }

    protected override string GetResult()
    {
        throw new NotImplementedException();
    }
}



class Program
{
    static void Main(string[] args)
    {

        string text = "";

        List<Task> tasks = new List<Task>
        {
            new Task_1(text),
            new Task_3(text),
            new Task_5(text),
            new Task_7(text),
            new Task_11(text),
            new Task_14(text)
        };

        foreach (Task task in tasks)
        {
            task.ParseText();
            Console.WriteLine(task);
            Console.WriteLine("-----");
        }

    }
}
