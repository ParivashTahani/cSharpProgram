using System;
using System.IO;
namespace ConsoleApp1
{
   public class Post
    {
        public string _title { get; set; }
        public string _description { get; set; }
        public DateTime _date { get; set; }
        public int _upvoting { get; private set; } = 0;
        public int _downvoting { get; private set; } = 0;

        public Post(string Title, string Description) 
        {
            this._title = Title;
            this._description = Description;
            this._date = DateTime.Now;
        }
        public int UpVoting()
        {
            _upvoting++;
            return _upvoting;
        }
        public int DownVoting()
        {
            _downvoting++;
            return _downvoting;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Post post = new Post("Escape button ","C# Console Application");
            ConsoleKeyInfo cki;
            Console.WriteLine( "Title:{0}", post._title);
            Console.WriteLine("Description:{0}", post._description);
            int upvoteCount = 0;
            int downvoteCount = 0;
            if (File.Exists("voteCounts.txt"))
            {
                string[] lines = File.ReadAllLines("voteCounts.txt");
                if (lines.Length == 2)
                {
                    int.TryParse(lines[0], out upvoteCount);
                    int.TryParse(lines[1], out downvoteCount);
                }
                else
                {
                    
                    File.WriteAllText("voteCounts.txt", "0\n0");
                }
            }   
            do
            {
                Console.WriteLine("Please choose : Like = choose 1 OR Dislike = 0 ");
                int input = Convert.ToInt32(Console.ReadLine());
                cki = Console.ReadKey();
                if (input == 0)
                {
                    int negativeCount = post.DownVoting();
                    downvoteCount++;
                    Console.WriteLine( " Your vote is: {0}", downvoteCount);
                }
                else if (input == 1)
                {
                    int positiveCount = post.UpVoting();
                    upvoteCount++;
                    Console.WriteLine( " Your vote is: {0}", upvoteCount);
                }
                else
                {
                    Console.WriteLine("Your input is not correct.");
                }
            }while (cki.Key != ConsoleKey.Escape);

            // Saving info in our File
            File.WriteAllText("voteCounts.txt", $"{upvoteCount}\n{downvoteCount}");

            //Displaying info from File
            Console.WriteLine("\nFile Information:");
            Console.WriteLine($"Upvote Count: {upvoteCount}");
            Console.WriteLine($"Downvote Count: {downvoteCount}");
        }

    }

}
