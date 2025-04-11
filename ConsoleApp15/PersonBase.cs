using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15;

abstract class PersonBase : IPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Gender GenderEnum { get; set; }
    public int Age { get; set; }


    public string GetFullName()
    {
        return $"{Name} {Surname}";
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"{Id} , {Name} , {Surname} ,{GenderEnum},{Age}");
    }

}
