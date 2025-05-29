using System;
using System.Collections.Generic;

namespace YouTubeTracker
{
    // Class representing a comment on a video
    public class Comment
    {
        public string CommenterName { get; set; }
        public string CommentText { get; set; }

        public Comment(string commenterName, string commentText)
        {
            CommenterName = commenterName;
            CommentText = commentText;
        }
    }

    // Class representing a video
    public class Video
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int LengthInSeconds { get; set; }

        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, int lengthInSeconds)
        {
            Title = title;
            Author = author;
            LengthInSeconds = lengthInSeconds;
        }

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to hold all videos
            List<Video> videos = new List<Video>();

            // Create Video 1
            Video video1 = new Video("How to Train Your Dog", "PetLover123", 420);
            video1.AddComment(new Comment("Alice", "This was super helpful, thanks!"));
            video1.AddComment(new Comment("Bob", "I tried this with my puppy and it worked!"));
            video1.AddComment(new Comment("Charlie", "Loved the tips on treats!"));
            videos.Add(video1);

            // Create Video 2
            Video video2 = new Video("Best Budget Laptops 2025", "TechTalk", 780);
            video2.AddComment(new Comment("Dana", "Can you review gaming laptops next?"));
            video2.AddComment(new Comment("Eli", "Great breakdown, very informative."));
            video2.AddComment(new Comment("Fay", "I just bought the Acer you recommended!"));
            videos.Add(video2);

            // Create Video 3
            Video video3 = new Video("10 Minute Home Workout", "FitNow", 600);
            video3.AddComment(new Comment("George", "I'm sweating after this—awesome!"));
            video3.AddComment(new Comment("Hannah", "Great routine for beginners."));
            video3.AddComment(new Comment("Ivan", "Can you make one for abs next?"));
            videos.Add(video3);

            // Optional: Create Video 4
            Video video4 = new Video("Top 5 Travel Destinations 2025", "Wanderlust", 900);
            video4.AddComment(new Comment("Jenny", "Can't wait to visit Japan!"));
            video4.AddComment(new Comment("Kyle", "Loved the drone footage!"));
            video4.AddComment(new Comment("Liam", "Adding these to my bucket list."));
            videos.Add(video4);

            // Display all video information
            foreach (Video video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

                Console.WriteLine("Comments:");
                foreach (Comment comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.CommenterName}: {comment.CommentText}");
                }

                Console.WriteLine(new string('-', 40)); // Separator
            }

            Console.WriteLine("Done displaying all videos!");
        }
    }
}
