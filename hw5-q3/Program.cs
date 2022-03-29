// See https://aka.ms/new-console-template for more information
using hw5_q3;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
bool flag = true;
string name, family, newName, newFamily,address;
int nationalId, age;
DateTime birthDate;
PersonRepository pr = new PersonRepository();
while (flag == true)
{
    Console.WriteLine("Would You Like To Continue? y / n");
    var ans = Console.ReadKey().Key;
    if (ans == ConsoleKey.Y)
    {
        Console.WriteLine();
        Console.WriteLine("Choose Operation   M-Insert N-GetAll P-Find R-Remove U-Update A-Age>20 B-Birthdate<1999 C-Same Birthdate" +
            " D-4th Element E-Range(50,80) F-Max Age H-Tehran" +
            "G-Repeated NationalId Address K-Age>25 J-NationalId=123");
        var operaton = Console.ReadKey().Key;
        Console.WriteLine();
        if (operaton == ConsoleKey.M)
        {
            var testData = Person.FakeData.Generate(100).ToList();
            foreach(var t in testData)
            {
                //Console.WriteLine(t.Name);
                pr.InsertPerson(t);
            }
            //Console.WriteLine(JsonConvert.SerializeObject(testData,Formatting.Indented));
        }
        else if (operaton == ConsoleKey.N)
        {
            var items = pr.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine($"ID:{item.Id} NationalId:{item.NationalId} Name: {item.Name} {item.Family} Age : {item.Age} Address : {item.Address}");
            }
        }
        else if (operaton == ConsoleKey.P)
        {

            Console.WriteLine("Enter Your Name To Find:");
            name = Console.ReadLine();
            pr.FindPerson(name);
        }
        else if (operaton == ConsoleKey.R)
        {
            Console.WriteLine("Enter Your Name To Delete:");
            name = Console.ReadLine();
            pr.DeletePerson(name);
        }
        else if (operaton == ConsoleKey.U)
        {
            Console.WriteLine("Enter Your Name To Update:");
            name = Console.ReadLine();

            Console.WriteLine("Enter Your New Name ");
            newName = Console.ReadLine();
            Console.WriteLine("Enter Your New Family ");
            newFamily = Console.ReadLine();
            pr.UpdatePerson(name, newName, newFamily);
        }
        else if(operaton == ConsoleKey.A)
        {
            var data = DataSource._person.OrderBy(s=>s.Name).Where(x => x.Age > 20);
            foreach(var item in data)
            {
                Console.WriteLine($"{item.Name} {item.Family} : {item.Age}");
            }
        }

        else if (operaton == ConsoleKey.B)
        {
            var data = DataSource._person.Where(x => x.BirthDate.Year < 1999);
            foreach (var d in data)
            {
                Console.WriteLine($"{d.Id} : {d.Name} {d.Family} {d.BirthDate}");
            }
        }

        else if (operaton == ConsoleKey.C)
        {
            var data = DataSource._person.GroupBy(x => x.BirthDate).Where(x => x.Count() > 1).SelectMany(x => x);
            foreach (var d in data)
            {
                Console.WriteLine($"{d.Id} : {d.Name} {d.Family} {d.BirthDate}");
            }
        }

        else if (operaton == ConsoleKey.D)
        {
            var data = DataSource._person.OrderBy(x => x.Id).ElementAtOrDefault(3);
            if (data != null)
            {
                Console.WriteLine($"{data.Name} {data.Family} : {data.Age}");
            }
        }

        else if (operaton == ConsoleKey.E)
        {
            var data = DataSource._person.GetRange(50,30).OrderBy(x => x.Id);
            foreach(var d in data)
            {
                Console.WriteLine($"{d.Name} {d.Family} : {d.Age}");
            }
            
         
        }

        else if (operaton == ConsoleKey.F)
        {
            var data = DataSource._person.OrderByDescending(s => s.Age).FirstOrDefault();
            Console.WriteLine($"{data.Name} {data.Family} : {data.Age}");
        }

        else if (operaton == ConsoleKey.G)
        {
            var data = DataSource._person.GroupBy(x=>x.NationalId).Where(x=>x.Count()>1).SelectMany(x=>x);
            foreach (var d in data)
            {
                Console.WriteLine($"{d.NationalId} : {d.Name} {d.Family}");
            }
        }

        else if (operaton == ConsoleKey.H)
        {
            var data = DataSource._person.Where(x => x.Address.Contains("tehran"));

            foreach (var d in data)
            {
                Console.WriteLine($"{d.Name} {d.Family} : {d.Address}");
            }
        }
        else if (operaton == ConsoleKey.J)
        {
            var data = DataSource._person.Where(x => x.NationalId==123);
            foreach (var item in data)
            {
                Console.WriteLine($"{item.NationalId} {item.Address}");
            }
        }
        else if (operaton == ConsoleKey.K)
        {
            var data = DataSource._person.Where(x => x.Age > 25);
            foreach (var item in data)
            {
                Console.WriteLine($"{item.NationalId} {item.Address}");
            }
        }
    }
    else if (ans == ConsoleKey.N)
    {
        Console.WriteLine("\t");
        flag = false;
    }
    else
    {
        Console.WriteLine("Enter Valid Answer!!!");
        flag = false;
    }
}





