// Exercise - Complete a challenge activity for creating and throwing exceptions

/* Identified trhown exceptions

*/


string[][] userEnteredValues = new string[][]
{
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
};

Workflow1(userEnteredValues);


static void Workflow1(string[][] userEnteredValues)
{
    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            Process1(userEntries);
            Console.WriteLine("'Process1' completed successfully.\n");
        }
        catch (Exception ex)
        {
            if (ex.GetType().ToString().Contains("Format"))
            {
                Console.WriteLine("'Process1' encountered an issue, process aborted.");
                Console.WriteLine(ex.Message);
            }

            else
            {
                Console.WriteLine("An error occurred during 'Workflow1'.");
                Console.WriteLine(ex.Message);
            }

        }

    }

}

static void Process1(String[] userEntries)
{
    int valueEntered = 0;

    foreach (string userValue in userEntries)
    {
        try
        {
            valueEntered = int.Parse(userValue);
            checked
            {
                int calculatedValue = 4 / valueEntered;
            }
        }
        catch (FormatException)
        {
            throw new FormatException("Invalid data. User input values must be valid integers.\n");
        }

        catch (DivideByZeroException)
        {
            throw new DivideByZeroException("Invalid data. User input values must be non-zero values.\n");
        }


    }

}


/*
MS LEARN SOLUTION
string[][] userEnteredValues = new string[][]
{
            new string[] { "1", "2", "3"},
            new string[] { "1", "two", "3"},
            new string[] { "0", "1", "2"}
};

try
{
    Workflow1(userEnteredValues);
    Console.WriteLine("'Workflow1' completed successfully.");

}
catch (DivideByZeroException ex)
{
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(ex.Message);
}

static void Workflow1(string[][] userEnteredValues)
{
    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            Process1(userEntries);
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        catch (FormatException ex)
        {
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    }
}

static void Process1(String[] userEntries)
{
    int valueEntered;

    foreach (string userValue in userEntries)
    {
        bool integerFormat = int.TryParse(userValue, out valueEntered);

        if (integerFormat == true)
        {
            if (valueEntered != 0)
            {
                checked
                {
                    int calculatedValue = 4 / valueEntered;
                }
            }
            else
            {
                throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
            }
        }
        else
        {
            throw new FormatException("Invalid data. User input values must be valid integers.");
        }
    }
}


*/