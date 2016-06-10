using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex_13
{
    class CGenerator : IGenerator
    {
        private string _definition;
        
        public void Comment(string cmnt)
        {
            Console.WriteLine($@"/* {cmnt} /*");
        }

        public void EndMessage()
        {
            Console.WriteLine($@"}} {_definition}Msg;");
        }

        public void Field(string fieldName, string fieldType)
        {
            if (fieldType.Contains("["))
            {
                Regex regex = new Regex(@"(?<=\[).*(?=\])");
                int arraySize = Int32.Parse(regex.Match(fieldType).Value);

                string arrayType = fieldType.Substring(0, fieldType.IndexOf('['));

                Console.WriteLine($"\t{arrayType}\t{fieldName}[{arraySize}];");
            }
            else
                Console.WriteLine($"\t{fieldType}\t{fieldName};");
        }

        public void StartMessage(string definition)
        {
            _definition = definition;
            Console.WriteLine("typedef struct {");
        }
    }
}
