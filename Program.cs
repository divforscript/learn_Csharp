// Data types in C#

string[] values = { "12.3", "45", "ABC", "11", "DEF" };
string message = "";
float total = 0.0f;


foreach (string value in values)
{
    if (float.TryParse(value, out float validParse))
    {
        total += validParse;
    }
    else
    {
        message += value;
    }
}
Console.WriteLine($"Message: {message}");
Console.WriteLine($"Total: {total}");
