class Program
{
    static void Main(string[] args)
    {
        // Используем ConstantReader
        IInputReader constantReader = new ConstantReader();
        IntegerParser constantParser = new IntegerParser(constantReader);
        Console.WriteLine($"Parsed value from constant: {constantParser.Parse()}");

        // Используем ConsoleReader
        IInputReader consoleReader = new ConsoleReader();
        IntegerParser consoleParser = new IntegerParser(consoleReader);
        Console.Write("Please enter a number:");
        Console.WriteLine($"Parsed value from console: {consoleParser.Parse()}");
    }
}
interface IInputReader
{
    string ReadFromSource();
}
internal class ConstantReader : IInputReader
{
    public string ReadFromSource()
    {
        return "5";
    } 
}
internal class ConsoleReader : IInputReader
{
    public string ReadFromSource()
    {
        string userInput;
        userInput = Console.ReadLine();
        return userInput;

    }
}
class IntegerParser
{
    private readonly IInputReader _inputReader;

    // Конструктор принимает IInputReader
    public IntegerParser(IInputReader inputReader)
    {
        _inputReader = inputReader;
    }

    public int Parse()
    {
        var inputedValue = _inputReader.ReadFromSource(); // Используем переданный IInputReader
        return int.Parse(inputedValue);
    }
}
