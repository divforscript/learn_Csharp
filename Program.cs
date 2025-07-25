// Exercise: Complete a challenge activity using for and if statements

string suffix = "";

for (int i = 1; i <= 100; i++)
{
    if (i % 15 == 0)
        suffix = " - FizzBuzz";
    else if (i % 3 == 0)
        suffix = " - Fizz";
    else if (i % 5 == 0)
        suffix = " - Buzz";
    else
        suffix = "";

    Console.WriteLine($"{i}{suffix}");
}

