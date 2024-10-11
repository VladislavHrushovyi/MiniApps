
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
