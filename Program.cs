// Exercise: Complete a challenge to parse a string of orders, sort the orders and tag possible errors

string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";

string[] orders = orderStream.Split(",");
Array.Sort(orders);

foreach (string order in orders)
{
    string error = "";
    if (order.Length != 4)
    {
        error = "- Error";
    }

    Console.WriteLine($"{order,-7} {error}");
}

