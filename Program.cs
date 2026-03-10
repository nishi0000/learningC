


string name = "Nishi";
Console.WriteLine($"名前は{name}です");


Console.WriteLine($"5 + 6 = {Add(5, 6)}");
Greet(name);
Console.WriteLine($"5 + 6 + 7 = {Add(5, 6, 7)}");

int Add(int a, int b)
{
    return a + b;
}

int Add(int a, int b,int c)
{
    return a + b + c;
}


void Greet(string name)
{
    Console.WriteLine($"こんにちは、{name}さん！");
}




