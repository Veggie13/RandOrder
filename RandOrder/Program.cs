using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RandOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string>[] chars = new List<string>[] {
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>(),
                new List<string>() };
            for (int i = 0; i < 24; i++)
            {
                char c = (char)((int)'a' + i);
                chars[0].Add(string.Format("{0}", c));
                chars[1].Add(string.Format("{0}", c));
                chars[2].Add(string.Format("{0}", c));
                chars[3].Add(string.Format("{0}", c));
                chars[4].Add(string.Format("{0}", c));
                chars[5].Add(string.Format("{0}", c));
            }
            Random r = new Random();

            StreamReader reader = new StreamReader(@"H:\keycluedrop\Dropbox\Alien Letter Grid Alloc.txt");

            string[] result = new string[12];
            StreamWriter writer = new StreamWriter(@"H:\keycluedrop\Dropbox\Alien Letter Grid Colour ID.txt");
            for (int row = 0; row < 12; row++)
            {
                string[] stuff = reader.ReadLine().Split(' ');
                for (int col = 0; col < 12; col++)
                {
                    int l = int.Parse(stuff[col]);
                    int s = r.Next(0, chars[l].Count - 1);
                    result[col] = chars[l][s];
                    chars[l].RemoveAt(s);
                }
                writer.WriteLine(string.Join(" ", result));
            }
            reader.Close();

            writer.Flush();
            writer.Close();

            Console.Write("Press any key...");
            Console.Read();
        }
    }
}
