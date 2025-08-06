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
Check if the player consumed the food
Create a method that uses the existing position variables of the player and food
- The method should return a value
- After the user moves the character, call your method to determine the following:
    * Whether or not to use the existing method that changes player appearance
    * Whether or not to use the existing method to redisplay the food
*/


using System;

Random random = new Random();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };
int foodLen = foods[0].Length;

// Console position of the player                       
int playerX = 0;
int playerY = 0;

// Console position of the food                                   
int foodX = 0;
int foodY = 0;
int[] foodXPositions = new int[foodLen];

// Current player string displayed in the Console
string player = states[0];
int playerLen = player.Length;

// Index of the current food
int food = 0;


////////////////////////
// Game run
///////////////////////

InitializeGame();

while (!shouldExit)
{
    // Without parameter: Accept any key. Add "restrict" as parameter to avoid gather non-directional keys. 
    Move();

    // Check if all food was eaten
    if (isAllFoodCollected())
    {
        ShowFood();
    }

}
Console.CursorVisible = true;
/////////////////////////




////////////////////////
/// Functions
///////////////////////

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodY = random.Next(0, height - 1);

    if (foodY == playerY)
    {
        do
        {
            foodX = random.Next(0, width - player.Length);

        } while ((playerX < foodX + foodLen) || (foodX < playerX + playerLen));
    }
    else
    {
        foodX = random.Next(0, width - player.Length);
    }

    for (int i = 0; i < foodLen; i++)
    {
        foodXPositions[i] = foodX + i;
    }

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(string mode = "f")
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
            playerX--;
            break;
        case ConsoleKey.RightArrow:
            playerX++;
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            endGame = mode.Equals("restrict");
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
    updateEatenFood();
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);

    ShowFood();
}

void updateEatenFood()
{
    int lastPlayerX = playerX + playerLen - 1;
    int lastFoodX = foodX + foodLen - 1;

    if (playerY == foodY)
    {
        if (playerX == foodX)
        {
            Array.Clear(foodXPositions, 0, foodLen);
        }
        else if (playerX < foodX && foodX <= lastPlayerX)
        {
            Array.Clear(foodXPositions, 0, lastPlayerX - foodX + 1);
        }
        else if (playerX > foodX && playerX <= lastFoodX)
        {
            Array.Clear(foodXPositions, playerX - foodX, lastFoodX - playerX + 1);
        }
    }
}

bool isAllFoodCollected()
{
    bool response = true;
    for (int i = 0; i < foodLen; i++)
    {
        if (foodXPositions[i] != 0)
        {
            response = false;
            break;
        }
    }

    return response;
}
