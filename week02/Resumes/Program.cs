using system;

class Program
{
    static void Main()
    {
        Resume resume = new Resume("Prince Omo");
        resume.AddJob(new Job("Software Developer", "TechCorp", 2023, 2025));
        resume.AddJob(new Job("Intern", "CodeBase Inc.", 2022, 2023));

        resume.Display();
    }
}

/*
 Enhancements:
 - Follows separation of concerns: Resume and Job have distinct responsibilities.
 - Each class is placed in its own file with matching name.
 - TitleCase for class and method names, _underscoreCamelCase for fields.
 - Clean indentation and spacing.
*/

// Resume.cs
using System;
using System.Collections.Generic;

public class Resume
{
    private string _name;
    private List<Job> _jobs = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }

    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    public void Display()
    {
        Console.WriteLine($"Name: {_name}\nJobs:");
        foreach (var job in _jobs)
        {
            Console.WriteLine(job.GetJobDetails());
        }
    }
}

// Job.cs
using System;

public class Job
{
    private string _title;
    private string _company;
    private int _startYear;
    private int _endYear;

    public Job(string title, string company, int startYear, int endYear)
    {
        _title = title;
        _company = company;
        _startYear = startYear;
        _endYear = endYear;
    }

    public string GetJobDetails()
    {
        return $"{_title} at {_company} ({_startYear} - {_endYear})";
    }
}
