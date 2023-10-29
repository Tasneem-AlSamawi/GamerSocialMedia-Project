using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     class TextPost : Post
    {
        public TextPost(string content, User author)
            : base(content, author)
        {
        }
    }
}
