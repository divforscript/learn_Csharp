// Exercise - Complete the challenge to add methods to make the game playable

// Dice mini-game challenge
string? userInput;
Random random = new Random();

Console.WriteLine("Would you like to play? (Y/N)");
if (ShouldPlay())
{
    PlayGame();
}


// Functions Area
void PlayGame()
{
    var play = true;

    while (play)
    {
        var target = random.Next(1,6);
        var roll = random.Next(1,7);

        Console.WriteLine($"Roll a number greater than {target} to win!");
        Console.WriteLine($"You rolled a {roll}");
        Console.WriteLine(WinOrLose(target,roll));
        Thread.Sleep(1000);
        Console.WriteLine("\nPlay again? (Y/N)");
        
        play = ShouldPlay();
    }
}

bool ShouldPlay()
{
    int count = 0;
    var response = "?";

    do
    {
        Console.Write(0 < count ? "Wrong input. Would you like to play? (Y/N)\n" : "\r");
        userInput = Console.ReadLine();
        if (userInput != null)
        {
            response = userInput.Trim().ToLower();
            count++;
        }

    } while (!"yn".Contains(response));

    return response == "y" ? true : false;
}

string WinOrLose(int die, int user)
{   
    var result = die < user? "win" : "lose";

    return $"You {result}!";
}