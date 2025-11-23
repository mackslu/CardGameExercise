namespace CardGameExercise;

public readonly record struct Card(char chrCardValue, int intCardValue, char chrSuit, bool blnJoker, bool blnUnrecognised) 
{
    private static readonly Dictionary<char, int> setValidSuits = new()
    {
        {'C', 1},
        {'D', 2},
        {'H', 3},
        {'S', 4},
        {'R', 0} // Only used for Jokers
    };
    
    public static Card Parse(string strCardData)
    {
        bool blnJoker, blnUnrecognised;
        char chrSuit;
        
        strCardData = strCardData.ToUpper().Trim();
        if (strCardData.Length < 2) return new Card('.', 0, '.', false, true);
        
        string strCardValue = strCardData[..1]; // Get first character of Card (the card value)
        int.TryParse(strCardValue, out int intCardValue); // If the first character is a numeric value, we can easily parse it

        blnJoker = strCardData == "JR";
        
        switch (strCardValue) // If not, we can check it against all possible other values, without a default case.
        {
            case "T":
                intCardValue = 10;
                break;
            case "J":
                intCardValue = blnJoker ? 0 : 11;
                break;
            case "Q":
                intCardValue = 12;
                break;
            case "K":
                intCardValue = 13;
                break;
            case "A":
                intCardValue = 14;
                break;
        }

        chrSuit = strCardData[1];
        blnUnrecognised = (intCardValue < 2 && !blnJoker) || !setValidSuits.ContainsKey(chrSuit) || (strCardValue != "J" && chrSuit == 'R');  // If the value is 0 or 1, and it's not a Joker, or the suit is not valid, this card is unrecognised.
        
        return new Card(strCardValue[0], intCardValue, chrSuit, blnJoker, blnUnrecognised);
    }

    public int Calculate()
    {
        if (blnUnrecognised) return 0;
        return intCardValue * GetMultiplicationFactor();
    }

    public int GetMultiplicationFactor()
    {
        return setValidSuits[chrSuit];
    }
}