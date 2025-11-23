using System.Diagnostics;

namespace CardGameExercise.Tests;

/*
Tests required for the Card Game parser to be complete:
1) Each permutation of card must be able to be successfully calculated to a score.
2) The user should be able to input a comma separated list via GUI that can be calculated
3) The user should be able to input a CSV file via GUI & file explorer that can be calculated
4) The program should support all card values (2-9, T, J, Q, K, A)
5) The program should support all card suits (C, D, H ,S)
6) The program should support joker cards (JR)
7) The user should be able to see the calculated score via the User Interface
8) The user should be able to see an error message if an invalid card or list is provided
9) Any duplicated cards in a list should result in an error message
9.1) Excluding Joker cards, a joker can appear twice, so an error message must be displayed if three or more jokers appear.
*/

public class CardGameExerciseTests
{
    [Theory]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void GivenACardWithANumericValueAndClubSuit_ThenReturnsNonMultipliedNumber(int intCardValue)
    {
        char chrCardSuit = 'C';
        
        Card parsedCard = Card.Parse(String.Concat(intCardValue, chrCardSuit));
        
        Assert.That(parsedCard.Calculate(), Is.EqualTo(intCardValue));
    }

    [Theory]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void GivenACardWithANumericValueAndDiamondSuit_ThenReturnsDoubledNumber(int intCardValue)
    {
        Card parsedCard = Card.Parse(String.Concat(intCardValue, 'D'));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(intCardValue * 2));
    }

    [Theory]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void GivenACardWithANumericValueAndHeartSuit_ThenReturnsTripledNumber(int intCardValue)
    {
        Card parsedCard = Card.Parse(string.Concat(intCardValue, 'H'));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(intCardValue * 3));
    }

    [Theory]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void GivenACardWithANumericValueAndSpadeSuit_ThenReturnsQuadrupledNumber(int intCardValue)
    {
        Card parsedCard = Card.Parse(string.Concat(intCardValue, 'S'));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(intCardValue * 4));
    }

    [Theory]
    [TestCase(2, 'C')]
    [TestCase(2, 'D')]
    [TestCase(2, 'H')]
    [TestCase(2, 'S')]
    [TestCase(3, 'C')]
    [TestCase(3, 'D')]
    [TestCase(3, 'H')]
    [TestCase(3, 'S')]
    [TestCase(4, 'C')]
    [TestCase(4, 'D')]
    [TestCase(4, 'H')]
    [TestCase(4, 'S')]
    [TestCase(5, 'C')]
    [TestCase(5, 'D')]
    [TestCase(5, 'H')]
    [TestCase(5, 'S')]
    [TestCase(6, 'C')]
    [TestCase(6, 'D')]
    [TestCase(6, 'H')]
    [TestCase(6, 'S')]
    [TestCase(7, 'C')]
    [TestCase(7, 'D')]
    [TestCase(7, 'H')]
    [TestCase(7, 'S')]
    [TestCase(8, 'C')]
    [TestCase(8, 'D')]
    [TestCase(8, 'H')]
    [TestCase(8, 'S')]
    [TestCase(9, 'C')]
    [TestCase(9, 'D')]
    [TestCase(9, 'H')]
    [TestCase(9, 'S')]
    public void GivenACardWithAnyNumericValueAndSuitAndAJoker_ThenReturnsDoubledScore(int intCardValue, char chrSuit)
    {
        string strCardData = string.Concat("JR,", intCardValue, chrSuit);
        CardManager cardManager = CardManager.Parse(strCardData);
        Assert.That(int.Parse(cardManager.Calculate()), Is.EqualTo(Card.Parse(string.Concat(intCardValue, chrSuit)).Calculate() * 2));
    }
    
    [Theory]
    [TestCase(2, 'C')]
    [TestCase(2, 'D')]
    [TestCase(2, 'H')]
    [TestCase(2, 'S')]
    [TestCase(3, 'C')]
    [TestCase(3, 'D')]
    [TestCase(3, 'H')]
    [TestCase(3, 'S')]
    [TestCase(4, 'C')]
    [TestCase(4, 'D')]
    [TestCase(4, 'H')]
    [TestCase(4, 'S')]
    [TestCase(5, 'C')]
    [TestCase(5, 'D')]
    [TestCase(5, 'H')]
    [TestCase(5, 'S')]
    [TestCase(6, 'C')]
    [TestCase(6, 'D')]
    [TestCase(6, 'H')]
    [TestCase(6, 'S')]
    [TestCase(7, 'C')]
    [TestCase(7, 'D')]
    [TestCase(7, 'H')]
    [TestCase(7, 'S')]
    [TestCase(8, 'C')]
    [TestCase(8, 'D')]
    [TestCase(8, 'H')]
    [TestCase(8, 'S')]
    [TestCase(9, 'C')]
    [TestCase(9, 'D')]
    [TestCase(9, 'H')]
    [TestCase(9, 'S')]
    public void GivenACardWithAnyNumericValueAndSuitAndTwoJokers_ThenReturnsQuadrupledScore(int intCardValue, char chrSuit)
    {
        string strCardData = string.Concat("JR,", intCardValue, chrSuit, ",JR");
        CardManager cardManager = CardManager.Parse(strCardData);
        Assert.That(int.Parse(cardManager.Calculate()), Is.EqualTo(Card.Parse(string.Concat(intCardValue, chrSuit)).Calculate() * 4));
        TestContext.WriteLine(cardManager.Calculate());
    }

    [Theory]
    public void GivenMoreThanTwoJokers_ThenReturnsErrorMessage()
    {
        string strCardData = string.Concat("JR,JR,JR");
        CardManager cardManager = CardManager.Parse(strCardData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("A hand cannot contain more than two Jokers"));
        TestContext.WriteLine(cardManager.Calculate());
    }

    [Theory]
    [TestCase('C')]
    [TestCase('D')]
    [TestCase('H')]
    [TestCase('S')]
    public void GivenACardWithATValueAndAnySuit_ThenReturnsTenMultipliedByTheSuit(char chrSuit)
    {
        Card parsedCard = Card.Parse(String.Concat('T', chrSuit));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(10 * parsedCard.GetMultiplicationFactor()));
        TestContext.WriteLine(parsedCard.Calculate());

    }
    
    [Theory]
    [TestCase('C')]
    [TestCase('D')]
    [TestCase('H')]
    [TestCase('S')]
    public void GivenAJackWithAnySuit_ThenReturnsTenMultipliedByTheSuit(char chrSuit)
    {
        Card parsedCard = Card.Parse(String.Concat('J', chrSuit));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(11 * parsedCard.GetMultiplicationFactor()));
        TestContext.WriteLine(parsedCard.Calculate());

    }
    
    [Theory]
    [TestCase('C')]
    [TestCase('D')]
    [TestCase('H')]
    [TestCase('S')]
    public void GivenAQueenWithAnySuit_ThenReturnsTenMultipliedByTheSuit(char chrSuit)
    {
        Card parsedCard = Card.Parse(String.Concat('Q', chrSuit));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(12 * parsedCard.GetMultiplicationFactor()));
        TestContext.WriteLine(parsedCard.Calculate());

    }
    
    [Theory]
    [TestCase('C')]
    [TestCase('D')]
    [TestCase('H')]
    [TestCase('S')]
    public void GivenAKingWithAnySuit_ThenReturnsTenMultipliedByTheSuit(char chrSuit)
    {
        Card parsedCard = Card.Parse(String.Concat('K', chrSuit));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(13 * parsedCard.GetMultiplicationFactor()));
        TestContext.WriteLine(parsedCard.Calculate());

    }
    
    [Theory]
    [TestCase('C')]
    [TestCase('D')]
    [TestCase('H')]
    [TestCase('S')]
    public void GivenAnAceWithAnySuit_ThenReturnsTenMultipliedByTheSuit(char chrSuit)
    {
        Card parsedCard = Card.Parse(String.Concat('A', chrSuit));
        Assert.That(parsedCard.Calculate(), Is.EqualTo(14 * parsedCard.GetMultiplicationFactor()));
        TestContext.WriteLine(parsedCard.Calculate());

    }

    [Theory]
    [TestCase("4D,5D,4D")]
    [TestCase("3H,3H")]

    public void GivenAListWithDuplicatedCards_ThenReturnsErrorMessage(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards cannot be duplicated"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("JR,4D,JR,5D,JR,4D")]
    [TestCase("3H,JR,3H,JR,JR")]

    public void GivenAListWithDuplicatedCardsAndMoreThanTwoJokers_ThenReturnsErrorMessages(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards cannot be duplicated, A hand cannot contain more than two Jokers"));
        TestContext.WriteLine(cardManager.Calculate());
    }

    [Theory]
    [TestCase("1S")]
    [TestCase("2B")]
    [TestCase("2S,1S")]
    public void GivenAnUnRecognisableCard_ThenReturnsErrorMessage(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards not recognised"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("1S,1S")]
    [TestCase("2B,2B")]
    [TestCase("2S,1S,3C,2S")]
    public void GivenAnUnRecognisableCardWithDuplicatedCards_ThenReturnsErrorMessages(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards not recognised, Cards cannot be duplicated"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("JR,1S,JR,JR,1S,JR")]
    [TestCase("2B,JR,JR,2B,JR")]
    [TestCase("2S,JR,JR,1S,3C,JR,2S")]
    public void GivenAnUnRecognisableCardWithDuplicatedCardsWithMoreThanTwoJokers_ThenReturnsErrorMessages(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards not recognised, Cards cannot be duplicated, A hand cannot contain more than two Jokers"));
        TestContext.WriteLine(cardManager.Calculate());
    }

    [Theory]
    [TestCase("2S|3D")]
    [TestCase("3D JR AC")]
    public void GivenAnInvalidCardsDataString_ThenReturnsErrorMessage(string strCardsData) // As this prevents data from being parsed, it cannot be combined with the other error messages
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Invalid input string"));
        TestContext.WriteLine(cardManager.Calculate());
    }

    [Theory]
    [TestCase("")]
    [TestCase(" ")]
    public void GivenAnEmptyString_ThenReturnsErrorMessage(string strEmptyCardsData)
    {
        CardManager cardManager = CardManager.Parse(strEmptyCardsData);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Invalid input string"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase(" 2S  ,3D ")]
    [TestCase("2D, JR, 3D,    8C")]
    public void GivenPoorlySpacedCards_ThenStillParses(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), !Is.EqualTo("Invalid input string"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase(" 2s  ,3D ")]
    [TestCase("2d, Jr, 3S,    8c, tC")]
    public void GivenPoorlyCapitalizedCards_ThenStillParses(string strCardsData)
    {
        CardManager cardManager = CardManager.Parse(strCardsData);
        Assert.That(cardManager.Calculate(), !Is.EqualTo("Invalid input string"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("2")]
    [TestCase("3")]
    [TestCase("4")]
    [TestCase("5")]
    [TestCase("6")]
    [TestCase("7")]
    [TestCase("8")]
    [TestCase("9")]
    public void GivenNonJokerWithRPostFix_ThenReturnsErrorMessage(string strCardValue)
    {
        CardManager cardManager = CardManager.Parse(string.Concat(strCardValue, 'R'));
        Assert.That(cardManager.Calculate(), Is.EqualTo("Cards not recognised"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("10C")]
    [TestCase("111D")]
    public void GivenPoorlyFormattedCard_ThenReturnsErrorMessage(string strCardValue)
    {
        CardManager cardManager = CardManager.Parse(strCardValue);
        Assert.That(cardManager.Calculate(), Is.EqualTo("Invalid input string"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("2C,3D,AH")]
    public void GivenCorrectlyFormattedCard_ThenParses(string strCardValue)
    {
        CardManager cardManager = CardManager.Parse(strCardValue);
        Assert.That(cardManager.Calculate(), Is.EqualTo("50"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("JR, JR, 2C")]
    public void GivenTwoJokers_ThenParses(string strCardValue)
    {
        CardManager cardManager = CardManager.Parse(strCardValue);
        Assert.That(cardManager.Calculate(), Is.EqualTo("8"));
        TestContext.WriteLine(cardManager.Calculate());
    }
    
    [Theory]
    [TestCase("2C")]
    [TestCase("3C")]
    [TestCase("4C")]
    [TestCase("5C")]
    [TestCase("6C")]
    [TestCase("7C")]
    [TestCase("8C")]
    [TestCase("9C")]
    public void GivenAClub_ThenMultiplicationFactorIsCorrect(string strCardValue)
    {
        Card card = Card.Parse(strCardValue);
        Assert.That(card.GetMultiplicationFactor(), Is.EqualTo(1));
        TestContext.WriteLine(card.GetMultiplicationFactor());
    }
    
    [Theory]
    [TestCase("2D")]
    [TestCase("3D")]
    [TestCase("4D")]
    [TestCase("5D")]
    [TestCase("6D")]
    [TestCase("7D")]
    [TestCase("8D")]
    [TestCase("9D")]
    public void GivenADiamond_ThenMultiplicationFactorIsCorrect(string strCardValue)
    {
        Card card = Card.Parse(strCardValue);
        Assert.That(card.GetMultiplicationFactor(), Is.EqualTo(2));
        TestContext.WriteLine(card.GetMultiplicationFactor());
    }
    
    [Theory]
    [TestCase("2H")]
    [TestCase("3H")]
    [TestCase("4H")]
    [TestCase("5H")]
    [TestCase("6H")]
    [TestCase("7H")]
    [TestCase("8H")]
    [TestCase("9H")]
    public void GivenAHeart_ThenMultiplicationFactorIsCorrect(string strCardValue)
    {
        Card card = Card.Parse(strCardValue);
        Assert.That(card.GetMultiplicationFactor(), Is.EqualTo(3));
        TestContext.WriteLine(card.GetMultiplicationFactor());
    }
    
    [Theory]
    [TestCase("2S")]
    [TestCase("3S")]
    [TestCase("4S")]
    [TestCase("5S")]
    [TestCase("6S")]
    [TestCase("7S")]
    [TestCase("8S")]
    [TestCase("9S")]
    public void GivenASpade_ThenMultiplicationFactorIsCorrect(string strCardValue)
    {
        Card card = Card.Parse(strCardValue);
        Assert.That(card.GetMultiplicationFactor(), Is.EqualTo(4));
        TestContext.WriteLine(card.GetMultiplicationFactor());
    }
}