using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     class TextComment : Comment
    {
        public TextComment(string content, User author, IPost post)
            : base(content, author, post)
        {
        }
    }
}
