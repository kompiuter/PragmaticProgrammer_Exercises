using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex_13
{
    class PascalGenerator : IGenerator
    {
        public void Comment(string cmnt)
        {
            Console.WriteLine($"{{ {cmnt} }}");
        }

        public void EndMessage()
        {
            Console.WriteLine("end;");
        }

        public void Field(string fieldName, string fieldType)
        {
            if (fieldType == "int")
                fieldType = "LongInt";

            if (fieldType.Contains("["))
            {
                Regex regex = new Regex(@"(?<=\[).*(?=\])");
                int arraySize = Int32.Parse(regex.Match(fieldType).Value);

                string arrayType = fieldType.Substring(0, fieldType.IndexOf('['));

                Console.WriteLine($"\t{fieldName}:\tarray[0..{arraySize-1}] of {arrayType};");
            }
            else
                Console.WriteLine($"\t{fieldName}:\t{fieldType};");
        }

        public void StartMessage(string definition)
        {
            Console.WriteLine($"{definition}Msg = packed record");
        }
    }
}
