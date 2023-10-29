using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    abstract class Comment : IComment
    {
        public string Id { get; private set; }
        public string Content { get; set; }
        public User Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public IPost Post { get; private set; }

        public Comment(string content, User author, IPost post)
        {
            Id = Guid.NewGuid().ToString();
            Content = content;
            Author = author;
            CreatedAt = DateTime.Now;
            Post = post;
        }
    }
}
