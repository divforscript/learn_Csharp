// Exercise - Complete a challenge activity to differentiate between do and while iteration statements

// Code project 1 - write code that validates integer input

string? userInput;
int numericValue = 0;
bool validInput = false;

Console.WriteLine("Enter an integer value between 5 and 10");

do
{
    userInput = Console.ReadLine();
    validInput = int.TryParse(userInput, out numericValue);

    if (!validInput)
    {
        Console.WriteLine("Sorry, you entered an invalid number, please try again");
        continue;
    }

    if (numericValue < 5 || 10 < numericValue)
    {
        validInput = false;
        Console.WriteLine($"You entered {numericValue}. Please, enter an integer value between 5 and 10");
    }

} while (!validInput);

Console.WriteLine($"Your input value ({numericValue}) has been accepted.");