using System;
using System.Collections.Generic;
using System.Linq;

namespace FiveCardDraw
{
    /*Enums:
    Hand, CardValue, CardSuit

    Methods:
    Card - get, Set
    Get Deck
    Shuffle Deck
    Deal Cards
    Check Cards/Hand Strength*/
    enum CardValue
    {
        Ace, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
    }
    enum CardSuit
    {
        Diamonds,
        Hearts,
        Spades,
        Clubs
    }

  enum PlayerHandStrength
    {
        NoPair, OnePair, TwoPair, ThreeOfAKind, Straight, Flush, FullHouse, FourOfAKind, StraightFlush, RoyalFlush
    }

    class Card
    {
        public CardSuit CardSuit { get; set; }
        public CardValue CardValue { get; set; }
    }

    class Program
    {
        static List<Card> getDeck()
        {
            var deck = new List<Card>();
            for (int cardSuit = 0; cardSuit < Enum.GetValues(typeof(CardSuit)).Length; cardSuit++)
            {
                for (int cardValue = 0; cardValue < Enum.GetValues(typeof(CardValue)).Length; cardValue++)
                {
                    deck.Add(new Card { CardSuit = (CardSuit)cardSuit, CardValue = (CardValue)cardValue });
                }
            }
            return deck;
        }

        static void ShuffleDeck(List<Card> cards)
        {
           int i = cards.Count;
            Random random = new Random();
            for (int j = 0; j < i -1; j++)
            {
                int z = random.Next(cards.Count);
                Card temp = cards[j];
                cards[j] = cards[z];
                cards[z] = temp;
            }
        }

        static List<Card> DealCards(List<Card> cards, int AmountOfCards)
        {
            var hand = new List<Card>();

            Random random = new Random();
            for(int i = 0; i < AmountOfCards; i++)
            {
                int j = random.Next(0, cards.Count);
                hand.Add(cards[j]);
                cards.RemoveAt(j);
            }
            return hand;
        }

        static PlayerHandStrength CheckHand(List<Card> hand)
        {
            bool OnePair = false;
            bool TwoPair = false;
            bool ThreeOfAKind = false;
            bool FourOfAKind = false;
            bool FullHouse = false;
            bool Flush = hand.All(card => card.CardSuit == hand[0].CardSuit);
            bool StraightFlush = false;
            bool Straight = false;
            bool HighCard =false;

            for (int i = 0; i < hand.Count - 1; i++)
            {
                if (hand[i].CardValue == hand[i + 1].CardValue)
                {
                    OnePair = true;
                    if (i < hand.Count - 2 && hand[i].CardValue == hand[i + 2].CardValue)
                    {
                        ThreeOfAKind = true;
                        if (i < hand.Count - 3 && hand[i].CardValue == hand[i + 3].CardValue)
                        {
                            FourOfAKind = true;
                        }
                    }
                }
            }

            if (ThreeOfAKind && OnePair)
            {
                FullHouse = true;
            }

            for (int i = 0; i < hand.Count - 1; i++)
            {
                if (hand[i].CardValue + 1 != hand[i + 1].CardValue)
                {
                    break;
                }
                if (i == hand.Count - 2)
                {
                    Straight = true;
                }
            }

        
            if (Straight && Flush)
            {
                return PlayerHandStrength.StraightFlush;
            }
            else if (FourOfAKind)
            {
                return PlayerHandStrength.FourOfAKind;
            }
            else if (FullHouse)
            {
                return PlayerHandStrength.FullHouse;
            }
            else if (Flush)
            {
                return PlayerHandStrength.Flush;
            }
            else if (Straight)
            {
                return PlayerHandStrength.Straight;
            }
            else if (ThreeOfAKind)
            {
                return PlayerHandStrength.ThreeOfAKind;
            }
            else if (OnePair)
            {
                TwoPair = hand.GroupBy(card => card.CardValue)
                                .Count(group => group.Count() == 2) == 2;
                if (TwoPair)
                {
                    return PlayerHandStrength.TwoPair;
                }
                else
                {
                    return PlayerHandStrength.OnePair;
                }
            }

            return PlayerHandStrength.NoPair;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Shuffling... Shuffling... Shuffling");
            List<Card> cards = getDeck();
            ShuffleDeck(cards);

            List<Card> hand = DealCards(cards, 5);
            Console.WriteLine(  "Your hand: ");
            foreach (var card in hand) Console.WriteLine($"{card.CardValue} of {card.CardSuit}");
            Console.WriteLine();
            PlayerHandStrength handStrength = CheckHand(hand);

            Console.WriteLine($"You have: {handStrength}");

        }
       

    }
}