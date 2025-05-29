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