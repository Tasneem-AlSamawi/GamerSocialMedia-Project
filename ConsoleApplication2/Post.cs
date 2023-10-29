using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
     abstract class Post : IPost
    {
        public string Id { get; private set; }
        public string Content { get; set; }
        public User Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<IComment> Comments { get; private set; }

        public Post(string content, User author)
        {
            Id = Guid.NewGuid().ToString();
            Content = content;
            Author = author;
            CreatedAt = DateTime.Now;
            Comments = new List<IComment>();
        }
    }
}
