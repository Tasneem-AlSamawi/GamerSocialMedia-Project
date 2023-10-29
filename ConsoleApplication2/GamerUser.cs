using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

   

    
    internal class GamerUser : User
        {

            internal List<Game> Games { get; set; }

            public GamerUser(string username, string email, string password, string gamertag)
                : base(username, email, password)
            {
                Gamertag = gamertag;
                Games = new List<Game>();
            }

            public override void Post(string content)
            {
                IPost post = new TextPost(content, this);
                GamerSocialMediaPlatform.Instance.AddPost(post);
            }

            internal override void Comment(IPost post, string content)
            {
                IComment comment = new TextComment(content, this, post);
                GamerSocialMediaPlatform.Instance.AddComment(post, comment);
            }

            internal void AddGame(Game game)
            {
                Games.Add(game);
            }

            internal void RemoveGame(Game game)
            {
                Games.Remove(game);
            }
        }
    }
    
