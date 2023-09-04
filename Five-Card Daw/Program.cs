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

  enum PlayerHand
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

        static void Main(string[] args)
        {

        }
       

    }
}