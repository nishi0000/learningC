// See https://aka.ms/new-console-template for more information
using System.ComponentModel;

Console.WriteLine("nishi1000!");

int a=42;
Console.WriteLine(a);

bool i=true;
Console.WriteLine(i);

double b=3.14;
Console.WriteLine(b);

string c="こんにちは";
Console.WriteLine(c);

decimal d=0.1m;
Console.WriteLine(d);

var e = "すとりんぐ";
Console.WriteLine(e);

string name = "Nishi";
Console.WriteLine($"名前は{name}です");

Console.WriteLine($"あなたの名前を入力してください。");
var f = Console.ReadLine();

Console.WriteLine($"こんにちは、{f}！");

Console.WriteLine($"数字を2つ入力してください。");

int g;
int h;
Console.Write("ひとつめ:");
if(int.TryParse(Console.ReadLine(), out g))
{
    Console.Write("ふたつめ:");
    if(int.TryParse(Console.ReadLine(), out h))
    {
        Console.WriteLine(g+h);
    }
    else
    {
        Console.WriteLine("数字を入力してください。");
    }
}else{
    Console.WriteLine("数字を入力してください。");
};
