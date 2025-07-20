// Exercise - Complete a challenge activity to apply business rules

Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

Console.WriteLine($"Days until expiration: {daysUntilExpiration}");

if (daysUntilExpiration <= 10)
{
    if (daysUntilExpiration == 0)
    {
        Console.WriteLine("Your subscription has expired.");
    }

    else if (daysUntilExpiration == 1)
    {
        Console.WriteLine("Your subscription expires within a day!");
        discountPercentage = 20;
        Console.WriteLine($"Renew now and save {discountPercentage}%!");
    }

    else if (1 < daysUntilExpiration && daysUntilExpiration <= 5)
    {
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        discountPercentage = 10;
        Console.WriteLine($"Renew now and save {discountPercentage}%!");
    }

    else
    {
        Console.WriteLine($"Your subscription will expire soon. Renew now!");
    }
}




