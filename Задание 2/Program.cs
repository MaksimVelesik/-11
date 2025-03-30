public interface IText
{
    string GetContent();
}

public class PlainText : IText
{
    private string _content;

    public PlainText(string content)
    {
        _content = content;
    }

    public string GetContent()
    {
        return _content;
    }
}

public abstract class TextDecorator : IText
{
    protected IText _text;

    public TextDecorator(IText text)
    {
        _text = text;
    }

    public virtual string GetContent()
    {
        return _text.GetContent();
    }
}

public class BoldDecorator : TextDecorator
{
    public BoldDecorator(IText text) : base(text) { }

    public override string GetContent()
    {
        return $"<b>{base.GetContent()}</b>";
    }
}

public class ItalicDecorator : TextDecorator
{
    public ItalicDecorator(IText text) : base(text) { }

    public override string GetContent()
    {
        return $"<i>{base.GetContent()}</i>";
    }
}

public class UnderlineDecorator : TextDecorator
{
    public UnderlineDecorator(IText text) : base(text) { }

    public override string GetContent()
    {
        return $"<u>{base.GetContent()}</u>";
    }
}

class Program
{
    static void Main(string[] args)
    {
        IText text = new PlainText("Hello, World!");

        IText boldText = new BoldDecorator(text);
        IText italicText = new ItalicDecorator(boldText);
        IText underlinedText = new UnderlineDecorator(italicText);

        Console.WriteLine(underlinedText.GetContent());
    }
}