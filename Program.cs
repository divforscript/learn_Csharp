// Exercise - Complete a challenge activity to differentiate between do and while iteration statements

// Code project 2 - write code that validates string input

string[] roles = new string[3] { "administrator", "manager", "user"};
string? userInput;
bool validInput = false;

Console.WriteLine("Enter your role name (Administrator, Manager, or User)");

do
{
    userInput = Console.ReadLine();
    userInput = userInput.Trim().ToLower();

    for (int i = 0; i < roles.Length; i++)
    {
        if (roles[i] == userInput)
        {
            validInput = true;
            break;
        }
    }

    if (validInput)
        continue;

    Console.WriteLine($"The role name that you entered, \"{userInput}\" is not valid. Enter your role name (Administrator, Manager, or User)");


} while (!validInput);

Console.WriteLine($"Your input value ({userInput}) has been accepted.");


