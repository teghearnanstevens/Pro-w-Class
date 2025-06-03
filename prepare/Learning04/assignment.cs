
using System;

public class Assignment
{


    private string _studentName = "John Doe";
    private string _topic = "C#";

    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    public string GetStudentName()
    {
        return _studentName;
    }
    
    


}