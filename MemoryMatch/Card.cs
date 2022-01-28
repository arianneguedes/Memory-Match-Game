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
    class Card
    {
        public string Symbol { get; set; } //Letters in Webdings
        public int Position { get; set; }
        public bool _turned = false;

        public void Turn() //Function to turn the card
        {
            if (!_turned)
                _turned = true;
        }
    }
}