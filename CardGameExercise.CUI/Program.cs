namespace CardGameExercise.CUI;

public static class Program
{
    public static void Main(string[] args)
    {
        bool blnContinueRunning = true;
        bool blnHandledArguments = false;

        while (blnContinueRunning)
        {
            if (args.Any() && !blnHandledArguments)
            {
                HandleFileInput(args[0]);
                blnHandledArguments = true;

                Console.WriteLine("Would you like to continue calculating results? (Y/N)");
                blnContinueRunning = Console.ReadLine()?.Trim().ToUpper() == "Y";
                continue;
            }

            Console.Write("Would you like to provide a CSV file path (1) or a raw list of playing cards (2): ");

            if (!TryReadUserSelection(out string strCardData, out bool blnIsFile))
             continue;

            CardManager cardManager = blnIsFile
                ? CardManager.Parse(File.ReadAllText(strCardData))
                : CardManager.Parse(strCardData);

            DisplayResult(cardManager);
            
            Console.WriteLine("Would you like to continue calculating results? (Y/N)");
            blnContinueRunning = Console.ReadLine()?.Trim().ToUpper() == "Y";
        }
    }

    private static bool TryReadUserSelection(out string strCardData, out bool blnIsFileInput)
    {
        strCardData = string.Empty;
        blnIsFileInput = false;

        switch (Console.ReadLine()?.Trim())
        {
            case "1":
                Console.Write("Enter the CSV file path: ");
                strCardData = Console.ReadLine() ?? "";
                if (!ValidateFilePath(strCardData)) return false;

                blnIsFileInput = true;
                return true;

            case "2":
                Console.Write("Enter the raw list of playing cards: ");
                strCardData = Console.ReadLine() ?? "";
                return !string.IsNullOrWhiteSpace(strCardData);

            default:
                Console.Write("Please enter a valid option (1 or 2): ");
                return false;
        }
    }

    private static void HandleFileInput(string strFilePath)
    {
        if (!ValidateFilePath(strFilePath))
            return;

        Console.WriteLine($"Drag and drop detected with file path: {strFilePath}");
        CardManager cardManager = CardManager.Parse(File.ReadAllText(strFilePath));
        DisplayResult(cardManager);
    }

    private static void DisplayResult(CardManager cardManager)
    {
        string strResult = cardManager.Calculate();

        if (int.TryParse(strResult, out int intScore))
            Console.WriteLine($"This list of cards has a score of: {intScore}");
        else
            Console.WriteLine($"Error when processing cards: {strResult}");
    }

    private static bool ValidateFilePath(string? strFilePath)
    {
        if (string.IsNullOrWhiteSpace(strFilePath))
        {
            Console.WriteLine($"The provided file path was not valid: {strFilePath}");
            return false;
        }

        if (!strFilePath.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"The provided file path must be a .csv file: {strFilePath}");
            return false;
        }

        if (!File.Exists(strFilePath))
        {
            Console.WriteLine($"The provided file path does not exist: {strFilePath}");
            return false;
        }

        return true;
    }
}