using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_13
{
    interface IGenerator
    {
        void Comment(string cmnt);
        void StartMessage(string definition);
        void Field(string fieldName, string fieldType);
        void EndMessage();
    }
}
