// Exercise - Complete a challenge activity to differentiate between do and while iteration statements

// Code project 2 - Write code that processes the contents of a string array

string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };

int periodLocation = 0;

for (int i = 0; i < myStrings.Length; i++)
{
    periodLocation = myStrings[i].IndexOf(".");

    if (periodLocation < 0)
    {
        Console.WriteLine(myStrings[i]);
        continue;
    }

    while (0 < periodLocation)
    {
        Console.WriteLine(myStrings[i].Substring(0, periodLocation));
        myStrings[i] = myStrings[i].Remove(0, periodLocation + 1).TrimStart();
        periodLocation = myStrings[i].IndexOf(".");
    }
    Console.WriteLine(myStrings[i]);
}


