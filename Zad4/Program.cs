using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Zad4
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file1.txt");
            List<People> p = new List<People>();
            try
            {
                while (!sr.EndOfStream)
                {
                    string str = sr.ReadLine();
                    string[] st = str.Split(' ');
                    p.Add(new People() { F = st[0], I = st[1], O = st[2], group = st[3], mark = st[4] });
                }
            }
            catch { Console.WriteLine("Файл содержит неправильный тип данных!"); }

            var groupGroups = from gr in p
                              group gr by gr.@group into g
                              select new
                              {
                                  FIOgm = g.Select(p => p),
                                  groups = g.Key,
                                  Count = g.Count(p=>Convert.ToDouble(p.mark) > 4)
                              };
            foreach (var group in groupGroups)
            {
                Console.WriteLine($"{group.groups} : {group.Count}");
                foreach (People item in group.FIOgm.Where(p => Convert.ToDouble(p.mark) > 4))
                {
                    Console.WriteLine(item.F + " " + item.I + " " + item.O + " " + item.group + " " + item.mark);
                }
            }
        }
    }
}
