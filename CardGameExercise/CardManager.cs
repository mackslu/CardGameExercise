using Microsoft.VisualBasic;

namespace CardGameExercise;

public class CardManager
{
    private List<Card> lstCards { get; set; }
    private List<string> lstErrorMessages { get; set; }

    private CardManager()
    {
        lstCards = new List<Card>();
        lstErrorMessages = new List<string>();
    }

    public static CardManager Parse(string strCardsData)
    {
        CardManager cardManager = new CardManager();
        
        string[] strCards = strCardsData.Trim().Split(','); // Trim the card data to prevent any unwanted spaces that could cause issues with parsing
        
        foreach (string strCard in strCards)
        {
            
            if (strCard.Trim().Length != 2)
            {
                cardManager.lstErrorMessages.Add("Invalid input string");
                return cardManager; // This will break if it is parsed, so return here
            }
            
            Card card = Card.Parse(strCard);
            
            cardManager.lstCards.Add(card);
        }

        if (cardManager.lstCards.Count(card => card.blnUnrecognised ) > 0)
            cardManager.lstErrorMessages.Add("Cards not recognised");

        if (cardManager.lstCards.Count(card => !card.blnJoker) != cardManager.lstCards.Where(card => !card.blnJoker).Distinct().Count())
        {
            cardManager.lstErrorMessages.Add("Cards cannot be duplicated");
        }

        if (cardManager.lstCards.Count(card => card.blnJoker) > 2)
            cardManager.lstErrorMessages.Add("A hand cannot contain more than two Jokers");
        
        return cardManager;
    }

    public string Calculate()
    {
        int intScore;

        if (lstErrorMessages.Any())
        {
            return String.Join(", ", lstErrorMessages);
        }

        intScore = lstCards.Where(card => !card.blnJoker).Sum(card => card.Calculate());  // A joker does not have its own value - so we want to skip this

        intScore *= (int)Math.Pow(2, lstCards.Count(card => card.blnJoker)); // A joker doubles the result, so one joker = doubled, 2 jokers = quadrupled
        return intScore.ToString();
    }
}