using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("How to find Skibidy Toilet", "Nathan", 600);
        Video video2 = new Video("How to become The Rizzler", "Drake", 900);

        video1.AddComment(new Comment("Mr. Marinduqeue", "Wow no cap!"));
        video1.AddComment(new Comment("Not Mister Nice Guy", "I think he can beat Goku!"));

        video2.AddComment(new Comment("Mickey McBootleg", "I can feel the rizz in my bones ngl."));
        video2.AddComment(new Comment("Lovely Ducs", "Now I know what to do when I see my crush."));

        videos.Add(video1);
        videos.Add(video2);

        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}