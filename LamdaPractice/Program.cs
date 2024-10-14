
using LamdaPractice;
using LamdaPractice.Models;

var humans = Enumerable.Range(1, 100).Select(x => new Human()
{
    Name = "Name" + x,
    Surname = "Surname" + x,
    Age = x + 1,
});

var result = humans.WhereClone(x => x.Age < 10).Select(x => $"{x.Name} {x.Surname} {x.Age}");

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