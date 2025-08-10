// Exercise - Catch specific exception types

try
{
    Process1();
}
catch
{
    Console.WriteLine("An exception has occurred");
}

Console.WriteLine("Exit program");

static void Process1()
{
    try
    {
        WriteMessage();
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Exception caught in Process1: {ex.Message}");
    }
}

static void WriteMessage()
{
    double float1 = 3000.0;
    double float2 = 0.0;
    int number1 = 3000;
    int number2 = 0;
    byte smallNumber;

    Console.WriteLine(float1 / float2);
    //Console.WriteLine(number1 / number2);

    checked // (1)
    {
        smallNumber = (byte)number1;
    }
}

/*(1)
When performing integral type calculations that assign the value of one integral type to another integral type, the result depends on the overflow-checking context. In a checked context, the conversion succeeds if the source value is within the range of the destination type. Otherwise, an OverflowException is thrown. In an unchecked context, the conversion always succeeds, and proceeds as follows:

If the source type is larger than the destination type, then the source value is truncated by discarding its "extra" most significant bits. The result is then treated as a value of the destination type.

If the source type is smaller than the destination type, then the source value is either sign-extended or zero-extended so that it's of the same size as the destination type. Sign-extension is used if the source type is signed; zero-extension is used if the source type is unsigned. The result is then treated as a value of the destination type.

If the source type is the same size as the destination type, then the source value is treated as a value of the destination type.
*/