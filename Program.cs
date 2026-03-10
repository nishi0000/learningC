// See https://aka.ms/new-console-template for more information
using System.ComponentModel;


string name = "Nishi";
Console.WriteLine($"名前は{name}です");

Console.WriteLine($"あなたの年齢を入力してください。");
var a = Console.ReadLine();

if (!int.TryParse(a, out int age))
{
    Console.WriteLine("入力が無効です。");
    return;
}else if (age < 18)
{
    Console.WriteLine("未成年です。");
}else if (age >= 18 && age < 65)
{
    Console.WriteLine("成人です。");
}else
{
    Console.WriteLine("シニアです。");
}

Console.WriteLine($"曜日を入力してください。");
var b = Console.ReadLine();

switch (b)
{
    case "月":
    case "火":
    case "水":
    case "木":
    case "金":
        Console.WriteLine("平日です。");
        break;
    case "土":
    case "日":
        Console.WriteLine("休日です。");
        break;
    case "水曜日":
        Console.WriteLine("今日は水曜日です。");
        break;
    default:
        Console.WriteLine("正しい曜日を入力してください。");
        break;
}


Console.WriteLine($"点数を入力してください。");
var c = Console.ReadLine();

if (!int.TryParse(c, out int score))
{
    Console.WriteLine("入力が無効です。");
    return;
}else if (score >= 90)
{
    Console.WriteLine("評価はAです。");
}else if (score >= 80)
{
    Console.WriteLine("評価はBです。"); 
}else if (score >= 70)
{
    Console.WriteLine("評価はCです。");
}else if (score >= 60)
{
    Console.WriteLine("評価はDです。"); 

}else
{
    Console.WriteLine("評価はFです。");
}

