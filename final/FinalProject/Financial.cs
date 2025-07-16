using System;

public abstract class Financial
{
    protected string _userInput;
    public abstract void Load();
    public abstract void Save();
    public abstract void Process();
    public abstract void Display();
}
