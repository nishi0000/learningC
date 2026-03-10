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
        Console.Write(i * j + " ");
    }
    Console.WriteLine();
}