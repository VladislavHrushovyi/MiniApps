
using LambdaPractice;
using LambdaPractice.Models;

var humans = Enumerable.Range(1, 100).Select(x => new Human()
{
    Name = "Name" + x,
    Surname = "Surname" + x,
    Age = x + 1,
}).Concat(Enumerable.Range(1,100).Select(x => new Human()
{
    Name = "Name" + x,
    Surname = "Surname" + x,
    Age = x + 1,
}));

var result = humans.MyWhere(x => x.Age < 10).Select(x => $"{x.Name} {x.Surname} {x.Age}");

foreach (var human in result)
{
    Console.WriteLine(human);
}

var firstResult = humans.MyFirst();
Console.WriteLine($"\n{firstResult}");

var lastResult = humans.MyLast();
Console.WriteLine($"\n{lastResult}");

var firstCond = humans.MyFirst(x => x.Age == 50);
Console.WriteLine($"\n{firstCond}");

var lastCond = humans.MyLast(x => x.Age > 50);
Console.WriteLine($"\n{lastCond}");

Console.WriteLine($"All humans has age more than 0: {humans.MyAll(x => x.Age >= 30)}");
Console.WriteLine($"One human has age more than 45: {humans.MyAny(x => x.Age > 102)}");

Console.WriteLine($"\nSum of each human's age: {humans.MySum(x => x.Age)}");

Console.WriteLine($"\nAverage human's age: {humans.MyAverage(x => x.Age)}");

Console.WriteLine($"\nAmount of distinct humans: {humans.MySelect(x => x.Age).MyDistinct().Count()} -- Total humans: {humans.Count()}");
Console.WriteLine($"\nContains a human {humans.MySelect(x => x.Age).MyContains(humans.MyFirst(x => x.Age < 30).Age)}");

Console.WriteLine($"\nCount of humans {humans.MyCount()}");

Console.WriteLine($"Skip 20 items {humans.MySkip(20).MyCount()}");

Console.WriteLine($"Take 20 humans {humans.MyTake(20).MyCount()}");