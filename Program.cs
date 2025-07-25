// Exercise: Complete a challenge activity using do and while iteration statements

Random damage = new Random();

string monsterCharacter = "Monster";
int monsterHealth = 10;

string heroCharacter = "Hero";
int heroHealth = 10;

string currentTurn = heroCharacter;
int nextCharacterHealth = 10;
int healthLost = 0;


string winner = "";

//while (0 < monsterHealth && 0 < heroHealth)
while (0 < nextCharacterHealth)
{
    healthLost = damage.Next(1, 11);

    if (currentTurn == heroCharacter)
    {
        monsterHealth -= healthLost;
        nextCharacterHealth = monsterHealth;
        if (nextCharacterHealth <= 0)
            winner = heroCharacter;
        
        currentTurn = monsterCharacter;
 
    }

    else if (currentTurn == monsterCharacter)
    {
        heroHealth -= healthLost;
        nextCharacterHealth = heroHealth;
        if (nextCharacterHealth <= 0)
            winner = monsterCharacter;
        
        currentTurn = heroCharacter;
        
    }

    Console.WriteLine($"{currentTurn} was damaged and lost {healthLost} and now has {nextCharacterHealth} health.");
}


Console.WriteLine($"{winner} wins!");