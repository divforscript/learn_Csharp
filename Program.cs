// Challenge Project - Make the player consume food

/*
- The code declares the following variables:
    - Variables to determine the size of the Terminal window.
    - Variables to track the locations of the player and food.
    - Arrays `states` and `foods` to provide available player and food appearances
    - Variables to track the current player and food appearance

- The code provides the following methods:
    - A method to determine if the Terminal window was resized.
    - A method to display a random food appearance at a random location.
    - A method that changes the player appearance to match the food consumed.
    - A method that temporarily freezes the player movement.
    - A method that moves the player according to directional input.
    - A method that sets up the initial game state.

- The code doesn't call the methods correctly to make the game playable. The following features are missing:
    - Code to determine if the player has consumed the food displayed.
    - Code to determine if the food consumed should freeze player movement.
    - Code to determine if the food consumed should increase player movement.
    - Code to increase movement speed.
    - Code to redisplay the food after it's consumed by the player.
    - Code to terminate execution if an unsupported key is entered.
    - Code to terminate execution if the terminal was resized.
*/

// Specifications
/*
In this challenge exercise, you need to create a method that determines if the player has consumed the food that affects their movement. When the player consumes the food string with value #####, the appearance is updated to (X_X). You'll add a feature to detect if the player appearance is (X_X), and if so, temporarily prevent the player from moving.

You also want to add an optional feature that detects if the player appearance is (^-^) and if so, increase or decrease the right and left movement speeds by a value of 3 while that appearance is active. When the player state is ('-'), you want the speed to return to normal. You want to make this feature optional since consuming food in this state requires more


Check if the player should freeze
Create a method that checks if the current player appearance is (X_X)
The method should return a value
Before allowing the user to move the character, call your method to determine the following:
Whether or not to use the existing method that freezes character movement
Make sure the character is only frozen temporarily and the player can still move afterwards


Add an option to increase player speed
Modify the existing Move method to support an optional movement speed parameter
Use the parameter to increase or decrease right and left movement speed by 3
Create a method that checks if the current player appearance is (^-^)
The method should return a value
Call your method to determine if Move should use the movement speed parameter

*/


using System;
using System.Net;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Console position of the player                       
int playerX = 0;
int playerY = 0;

// Index of the current food
int food = 0;

// Console position of the food                                   
int foodX = 0;
int foodY = 0;
int foodLen = foods[0].Length;
int firstFoodX = 0;
int lastFoodX = 0;

// Current player string displayed in the Console
string player = states[0];
int playerLen = player.Length;

// Set the default accelerate variable
int speedMultiplier = 3;

////////////////////////
// Game run
///////////////////////

InitializeGame();

while (!shouldExit)
{
    // Without parameter: Accept any key. Add "restrict" as parameter to avoid gather non-directional keys. 

    if (AcceleratePlayer())
    {
        Move(accelerate: true);
    }
    else
    {
        Move();
    }

    if (AteFood())
    {
        switch (foods[food][0])
        {
            case '#':
                ChangePlayer();

                if (ShouldFreeze())
                {
                    FreezePlayer();
                }

                player = states[0];
                break;

            case '$':
                ChangePlayer();
                break;

            case '@':
                ChangePlayer();
                break;
        }

    }

    // Check if all food was eaten
    if (AllFoodCollected())
    {
        ShowFood();
    }

}
Console.Clear();
Console.CursorVisible = true;
/////////////////////////


////////////////////////
/// Functions
///////////////////////

// Reads directional input from the Console and moves the player
// Game modes => 'f': free, accept any key // 'r': restrict, only accept directional keys
void Move(char mode = 'f', bool accelerate = false)
{
    bool endGame = false;
    int lastX = playerX;
    int lastY = playerY;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;
        case ConsoleKey.DownArrow:
            playerY++;
            break;
        case ConsoleKey.LeftArrow:
            playerX -= accelerate ? speedMultiplier : 1;
            break;
        case ConsoleKey.RightArrow:
            playerX += accelerate ? speedMultiplier : 1;
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            endGame = (mode == 'r');
            break;
    }

    // Game end conditions
    if (endGame)
    {
        shouldExit = true;
        Console.Clear();
        return;
    }

    if (TerminalResized())
    {
        Console.Clear();
        // Write message before exiting game
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Console was resized. Program exiting.");
        shouldExit = true;
        Thread.Sleep(1500);
        return;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);

}


bool AteFood()
{
    bool response = false;
    if (playerY == foodY)
    {

        int lastPlayerX = playerX + playerLen - 1;

        if (playerX >= firstFoodX && playerX <= lastFoodX)
        {
            lastFoodX = playerX - 1;
            response = true;
        }

        else if (playerX < firstFoodX && lastPlayerX >= foodX)
        {
            firstFoodX = lastPlayerX + 1;
            response = true;
        }
    }

    return response;
}

bool AllFoodCollected()
{
    return lastFoodX < firstFoodX ? true : false;
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    playerLen = player.Length;
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Increment speed x3
bool AcceleratePlayer()
{
    return player.Contains("^") ? true : false;
}

// Temporarily stops the player from moving
bool ShouldFreeze()
{
    return player.Contains("X") ? true : false;
}

void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];


    // Clear any buffered key presses
    while (Console.KeyAvailable)
    {
        Console.ReadKey(true); // true = don't display the key
    }

}



// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);

    ShowFood();
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);
    foodLen = foods[food].Length;

    // Update food position to a random location, taking care not overwrite the player
    foodX = random.Next(0, width - playerLen);
    foodY = random.Next(0, height - 1);

    if (foodY == playerY)
    {
        if (foodX < playerX && playerX - foodX < foodLen)
            foodY++;
        else if (foodX >= playerX && foodX - playerX < playerLen)
            foodY--;
    }

    // Register key food positions
    firstFoodX = foodX;
    lastFoodX = foodX + foodLen - 1;

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}
