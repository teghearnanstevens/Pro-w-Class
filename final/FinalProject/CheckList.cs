public class Checklist
{
    private List<string> _items = new List<string>();

    public void AddItem(string item)
    {
        _items.Add(item);
        Console.WriteLine($"✅ Added checklist item: {item}");
    }

    public void ShowChecklist()
    {
        Console.WriteLine("📋 Checklist:");
        foreach (var item in _items)
        {
            Console.WriteLine($"- {item}");
        }
    }
}
