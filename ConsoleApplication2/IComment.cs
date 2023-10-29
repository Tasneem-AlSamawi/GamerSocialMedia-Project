using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     interface IComment
    {
        string Id { get; }
        string Content { get; set; }
        User Author { get; }
        DateTime CreatedAt { get; }
        IPost Post { get; }
    }
}
