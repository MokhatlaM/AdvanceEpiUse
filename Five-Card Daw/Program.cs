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
    enum Value
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
        public CardSuit Suit { get; set; }
        public Value Value { get; set; }
    }

    class Program
    {


        static void Main(string[] args)
        {

        }
       

    }
}