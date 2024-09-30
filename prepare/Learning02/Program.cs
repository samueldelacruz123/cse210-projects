using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Professional Beggar";
        job1._company = "Badjao Incorporated";
        job1._startYear = 2005;
        job1._endYear = 2050;

        Job job2 = new Job();
        job2._jobTitle = "Professional Complainer";
        job2._company = "Tambay Meet-up Company";
        job2._startYear = 1999;
        job2._endYear = 2099;

        Resume myResume = new Resume();
        myResume._name = "Mc Lovin";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();

    }
}