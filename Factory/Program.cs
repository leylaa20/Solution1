using System;

namespace Factory;

interface IButton
{
    void Render();
    void OnClick();
}

class Windows : IButton
{
    public void OnClick() => Console.WriteLine("Windows OnClick");

    public void Render() => Console.WriteLine("Windows Render");
}


class HTML : IButton
{
    public void OnClick() => Console.WriteLine("HTML OnClick");

    public void Render() => Console.WriteLine("HTML Render");
}


abstract class Dialog
{
    public void Render() { Console.WriteLine("Render"); }
    public abstract IButton CreateButton();
}


class WindowsDialog : Dialog
{
    public override IButton CreateButton() => new Windows();
}


class HTMLDialog : Dialog
{
    public override IButton CreateButton() => new HTML();
}

public class Program
{
    static void Main(string[] args)
    {
        IButton? button = null;
        Dialog? dialog = null;

        while (true)
        {
            Console.WriteLine("\n1) Windows");
            Console.WriteLine("2) HTML");
            Console.WriteLine("0) Exit");
            Console.Write("\n\tEnter choice ");

            dialog = Console.ReadLine() switch
            {
                "1" => new WindowsDialog(),
                "2" => new HTMLDialog(),
                _ => null
            };

            if (dialog == null)
                break;

            button = dialog.CreateButton();
            button?.OnClick();
        }
    }
}
