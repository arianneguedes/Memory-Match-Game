//Name: Assignment 1 - Games
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Author: Arianne Hoffschneider Guedes Gayer
//Student ID: 425002

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryMatch
{
    class MemoryBoard
    {
        public Card[] cards = new Card[20];
        private string[] _symbols = { "B", "C", "E", "H", "I", "J", "P", "Q", "R", "S" };
        public int _turnedCount = 0; //To count the number of turned cards (can be 0, 1 or 2)
        public int _count = 0; //To count the number of pairs of turned cards

        public void Reset() //Function to randomly sort the cards at the beggining of each match
        {
            Random r = new Random();
            int sortedNumber;
            string[] usedNumbers = new string[20];

            for (int i = 0; i < _symbols.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    do
                    {
                        sortedNumber = r.Next(0, 20);
                    } while (usedNumbers[sortedNumber] != null);

                    cards[sortedNumber] = new Card();
                    cards[sortedNumber].Symbol = _symbols[i];
                    cards[sortedNumber].Position = sortedNumber;
                    usedNumbers[sortedNumber] = _symbols[i];
                }
            }
        }

        public bool Turn(string symbol, int position) //Function to turn one of the cards
        {
            if (_turnedCount == 2)
            {
                return false;
            }

            cards[this.Search(symbol, position)].Turn(); //To select the card to be turned
            _turnedCount ++;

            if (_turnedCount == 2)
            {
                _count++;
            }

            return true;
        }

        public int Search(string symbol, int position) //Function to search for a specific card
        {
            int foundCard = -1;

            foreach (var item in cards)
            {
                if (item.Symbol == symbol && item.Position == position)
                {
                    foundCard = item.Position;
                    break;
                }
            }

            return foundCard;
        }

        public bool Match() //Function to check if both turned cards are equal
        {
            string symbol = "";

            foreach (var item in cards)
            {
                if (item._turned)
                {
                    if (symbol == "")
                    {
                        symbol = item.Symbol;
                    }
                    else
                    {
                        if (symbol == item.Symbol)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return false;
        }

        public void Untap() //Function to untap the cards
        {
            foreach (var item in cards)
            {
                item._turned = false;
            }

            _turnedCount = 0;
        }

    }
}