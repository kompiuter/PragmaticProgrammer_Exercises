using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex_13
{
    class Program
    {
        static IGenerator _generator;
        static void Main(string[] args)
        {
            _generator = new CGenerator();
            //_generator = new PascalGenerator();

            using (var reader = new StreamReader("input.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.StartsWith("#"))
                        _generator.Comment(new Regex(@"(?<=#\s).*").Match(line).Value);
                    else if (line.StartsWith("M"))
                        _generator.StartMessage(new Regex(@"(?<=M\s).*").Match(line).Value);
                    else if (line.StartsWith("E"))
                        _generator.EndMessage();
                    else if (line.StartsWith("F"))
                    {
                        Regex regex = new Regex(@"(?<=F\s)(\w*)\s*(.*)");
                        var match = regex.Match(line);
                        _generator.Field(match.Groups[1].Value, match.Groups[2].Value);
                    }
                    else
                        ; //Ignore anything else (not in our language)
                }
            }
            Console.ReadLine();
        }
    }
}
