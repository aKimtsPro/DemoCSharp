using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCSharpBase
{

    // [Flags]
    enum Right
    {

        Read = 1,     // 0001
        Write = 2,    // 0010
        Execute = 4   // 0100

    }
}
