public class Word
{
    private string _text;
    private bool _visible;

    public Word(string text)
    {
        _text = text;
        _visible = true;
    }

    public void Hide()
    {
        _visible = false;
    }

    public void Show()
    {
        _visible = true;
    }

    public bool IsVisible()
    {
        return _visible;
    }

    public string GetText()
    {
        return _visible ? _text : "_____";
    }

    public string GetRawText()
    {
        return _text;
    }


}
