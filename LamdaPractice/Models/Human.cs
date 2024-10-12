namespace LamdaPractice.Models;

public class Human
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Name} {Surname} {Age}";
    }
}