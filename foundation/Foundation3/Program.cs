using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Running runActivity = new Running("03 Nov 2022", 30, 5.0);
        Cycling cycleActivity = new Cycling("04 Nov 2022", 45, 20.0);
        Swimming swimActivity = new Swimming("05 Nov 2022", 25, 30);

        List<Activity> activities = new List<Activity> { runActivity, cycleActivity, swimActivity };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
