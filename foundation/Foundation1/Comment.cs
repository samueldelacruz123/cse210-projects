using System;

class Comment
{
    private string commenterName;
    private string text;

    public Comment(string commenterName, string text)
    {
        this.commenterName = commenterName;
        this.text = text;
    }

    public void DisplayComment()
    {
        Console.WriteLine($"{commenterName}: {text}");
    }
}