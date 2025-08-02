// Exercise: Complete a challenge to apply string interpolation to a form letter

string customerName = "Ms. Barros";

string currentProduct = "Magic Yield";
int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;

// Your logic here

Console.WriteLine(
    $"Dear {customerName},\n\n" +
    $"As a customer of our {currentProduct} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n\n" +
    
    $"Currently, you own {currentShares:N2} shares at a return of {currentReturn:P2}.\n\n" + 
    
    $"Our new product, {newProduct} offers a return of {newReturn:P2}.  Given your current volume, your potential profit would be {newProfit:C2}.\n"
);

Console.WriteLine("Here's a quick comparison:\n");

string comparisonMessage = "";

// Your logic here
comparisonMessage =
currentProduct.PadRight(20) + $"{currentReturn:P2}".PadRight(9) + $"{currentProfit:C2}\n" + newProduct.PadRight(20) + $"{newReturn:P2}".PadRight(9) + $"{newProfit:C2}";

Console.WriteLine(comparisonMessage);