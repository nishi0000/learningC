// See https://aka.ms/new-console-template for more information
using System.ComponentModel;


string name = "Nishi";
Console.WriteLine($"名前は{name}です");

int count = 0;

for (int i = 0; i < 10; i++)
{
    count ++;
}

Console.WriteLine($"合計は{count}です。");

for (int i = 1; i < 10; i++)
{
    for (int j = 1; j < 10; j++)
    {
        // Console.WriteLine($"iは{i}です。");
        // Console.WriteLine($"jは{j}です。");
        Console.Write($"{i * j,3}");
    }
    Console.WriteLine();
}

string[] names = { "Alice", "Bob", "Charlie" };

foreach (string name1 in names)
{
    Console.WriteLine($"{name1}さん、こんにちは！");
}


string? userString = "";

while (userString != "exit")
{
   userString = Console.ReadLine();
}

for (int i = 0; i < 100; i++)
{
    if (i % 3 != 0 || i == 0)
    {
        continue;
    }
    Console.WriteLine(i);
}