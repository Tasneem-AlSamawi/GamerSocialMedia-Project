using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    

        class GamerSocialMediaPlatform
        {
            public static GamerSocialMediaPlatform instance;
            public List<User> users;
            public List<IPost> posts;

            public GamerSocialMediaPlatform()
            {
                users = new List<User>();
                posts = new List<IPost>();
            }

            public static GamerSocialMediaPlatform Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new GamerSocialMediaPlatform();
                    }
                    return instance;
                }
            }

            public void RegisterUser(User user)
            {
                users.Add(user);
            }

            public void AddPost(IPost post)
            {
                posts.Add(post);
            }

            public List<IPost> GetPosts()
            {
                return posts;
            }

            public void AddComment(IPost post, IComment comment)
            {
                post.Comments.Add(comment);
            }

            public List<IComment> GetComments(IPost post)
            {
                return post.Comments;
            }

            public void DeletePost(IPost post)
            {
                posts.Remove(post);
            }

            public void UpdatePost(IPost post, string newContent)
            {
                post.Content = newContent;
            }

            public void AddGameToUser(GamerUser user, Game game)
            {
                user.AddGame(game);
            }

            public void RemoveGameFromUser(GamerUser user, Game game)
            {
                user.RemoveGame(game);
            }
            public GamerUser GetUserByGamertag(string gamertag)
            {
                return users.FirstOrDefault(u => u.Gamertag == gamertag) as GamerUser;
            }
            public IPost GetFirstPost()
            {
                return posts.FirstOrDefault();
            }
        }

    }

