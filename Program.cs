// Exercise - Complete a challenge activity for nested iteration and selection statements

string[] fraudulentOrderIDs =
[   "B123",
    "C234",
    "A345",
    "C15",
    "B177",
    "G3003",
    "C235",
    "B179"
];


foreach (string orderID in fraudulentOrderIDs)
{
    if (orderID.StartsWith("B"))
    {
        Console.WriteLine(orderID);
    }
}
