using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication2
{



    public class Program
    {
        public static void Main()
        {



            // Create a gamer user
            Console.ForegroundColor = ConsoleColor.Cyan;



            Console.SetCursorPosition((Console.WindowWidth - "Welcome to Gamer Social Media Platform!".Length) / 2, Console.CursorTop);
            Console.WriteLine("Welcome to Gamer Social Media Platform! \n \n");

            Console.WriteLine("Please enter your details:");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Gamertag: ");
            string gamertag = Console.ReadLine();

            GamerUser user = new GamerUser(username, email, password, gamertag);
            GamerSocialMediaPlatform.Instance.RegisterUser(user);

            Console.WriteLine("Registration successful!");

            // Main menu
            while (true)
            {
                Console.WriteLine("==== Menu ====");
                Console.WriteLine("1. Create a post");
                Console.WriteLine("2. View all posts");
                Console.WriteLine("3. Delete a post");
                Console.WriteLine("4. Update a post");
                Console.WriteLine("5. Add a game to a user");
                Console.WriteLine("6. Remove a game from a user");
                Console.WriteLine("7. Exit");
                Console.WriteLine("==============");
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter your post content:");
                        string content = Console.ReadLine();
                        user.Post(content);
                        Console.WriteLine("Post created!");
                        break;
                    case "2":
                        List<IPost> posts = GamerSocialMediaPlatform.Instance.GetPosts();
                        Console.WriteLine("==== Posts ====");
                        foreach (IPost post in posts)
                        {
                            Console.WriteLine("Post ID: {0}", post.Id);
                            Console.WriteLine("Content: {0}", post.Content);
                            Console.WriteLine("Author: {0}", post.Author.Username);
                            Console.WriteLine("Created At: {0}", post.CreatedAt);
                            Console.WriteLine("==== Comments ====");
                            foreach (IComment comment in post.Comments)
                            {
                                Console.WriteLine("Comment ID: {0}", comment.Id);
                                Console.WriteLine("Content: {0}", comment.Content);
                                Console.WriteLine("Author: {0}", comment.Author.Username);
                                Console.WriteLine("Created At: {0}", comment.CreatedAt);
                            }
                            Console.WriteLine("=================");
                        }


                        break;
                    case "3":
                        Console.WriteLine("Enter the ID of the post you want to delete:");
                        string postIdToDelete = Console.ReadLine();
                        IPost postToDelete = GamerSocialMediaPlatform.Instance.GetPosts().FirstOrDefault(p => p.Id == postIdToDelete);
                        if (postToDelete != null)
                        {
                            GamerSocialMediaPlatform.Instance.DeletePost(postToDelete);
                            Console.WriteLine("Post deleted!");
                        }
                        else
                        {
                            Console.WriteLine("Post not found!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter the ID of the post you want to update:");
                        string postIdToUpdate = Console.ReadLine();
                        IPost postToUpdate = GamerSocialMediaPlatform.Instance.GetPosts().FirstOrDefault(p => p.Id == postIdToUpdate);
                        if (postToUpdate != null)
                        {
                            Console.WriteLine("Enter the new content for the post:");
                            string newContent = Console.ReadLine();
                            GamerSocialMediaPlatform.Instance.UpdatePost(postToUpdate, newContent);
                            Console.WriteLine("Post updated!");
                        }
                        else
                        {
                            Console.WriteLine("Post not found!");
                        }
                        break;
                    // Inside the 'case "5":' block
                    case "5":
                        Console.WriteLine("Enter the gamertag of the user:");
                        string gamertagToAddGame = Console.ReadLine();
                        GamerUser userToAddGame = GamerSocialMediaPlatform.Instance.GetUserByGamertag(gamertagToAddGame);
                        if (userToAddGame != null)
                        {
                            Console.WriteLine("Enter the details of the game:");
                            Game newGame = new Game();
                            newGame.Name = Console.ReadLine();
                            newGame.Genre = Console.ReadLine();
                            // Read other game properties...

                            GamerSocialMediaPlatform.Instance.AddGameToUser(userToAddGame, newGame);
                            Console.WriteLine("Game added to the user!");
                        }
                        else
                        {
                            Console.WriteLine("User not found!");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Enter the gamertag of the user:");
                        string gamertagToRemoveGame = Console.ReadLine();
                        GamerUser userToRemoveGame = GamerSocialMediaPlatform.Instance.GetUserByGamertag(gamertagToRemoveGame);
                        if (userToRemoveGame != null)
                        {
                            Console.WriteLine("Enter the name of the game to remove:");
                            string gameNameToRemove = Console.ReadLine();
                            Game gameToRemove = userToRemoveGame.Games.FirstOrDefault(g => g.Name == gameNameToRemove);
                            if (gameToRemove != null)
                            {
                                GamerSocialMediaPlatform.Instance.RemoveGameFromUser(userToRemoveGame, gameToRemove);
                                Console.WriteLine("Game removed from the user!");
                            }
                            else
                            {
                                Console.WriteLine("Game not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("User not found!");
                        }
                        break;
                    case "7":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}