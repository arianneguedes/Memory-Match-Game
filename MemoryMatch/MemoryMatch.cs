//Name: Assignment 1 - Games
//Program: Software Development Diploma
//Course Code: SODV2101 - Rapid Application Development
//Author: Arianne Hoffschneider Guedes Gayer
//Student ID: 425002

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryMatch
{
    public partial class MemoryMatch : Form
    {
        MemoryBoard boardGame = new MemoryBoard();
        private int _invisibleCards = 0;

        public MemoryMatch()
        {
            InitializeComponent();
        }

        private void MemoryMatch_Load(object sender, EventArgs e)
        {
            Reset();
        }

        private void Cards_Click(object sender, EventArgs e)
        {
            Label lblClicked = (Label)sender;
            string tag = lblClicked.Tag.ToString();
            string[] split = tag.Split(',');

            if (lblClicked.Text == "") //To check if the card is already clicked/turned
            {
                if (boardGame._turnedCount == 0) //If there's no clicked/turned card
                {
                    if (boardGame.Turn(split[0], int.Parse(split[1])))
                    {
                        lblClicked.Text = split[0];
                    }
                }
                else
                {
                    if (boardGame._turnedCount == 1)
                    {
                        if (boardGame.Turn(split[0], int.Parse(split[1])))
                        {
                            lblClicked.Text = split[0];
                        }

                        if (boardGame._turnedCount == 2) //If there's two clicked/turned cards
                        {
                            if (boardGame.Match()) //To check if both cards are equal
                            {
                                _invisibleCards += 2;

                                if (_invisibleCards == 20) //To check if all cards are invisible/the game ended
                                {
                                    MessageBox.Show("Congratulations! \nYou've completed the game with " + boardGame._count + " turns!");
                                }

                                //Turn on the timer after the user matches two cards
                                tmrMatch.Enabled = true;
                                tmrMatch.Start();
                            }
                            else
                            {
                                //Turn on the timer after two unmatching cards are displayed in order for the user have the time to memorize the cards
                                tmrCards.Enabled = true;
                                tmrCards.Start();
                            }
                        }
                    }
                }
            }
        }

        public void UntapCards()
        {
            boardGame.Untap();
            ClearCards();
        }

        public void ClearCards()
        {
            lblCard1.Text = "";
            lblCard2.Text = "";
            lblCard3.Text = "";
            lblCard4.Text = "";
            lblCard5.Text = "";
            lblCard6.Text = "";
            lblCard7.Text = "";
            lblCard8.Text = "";
            lblCard9.Text = "";
            lblCard10.Text = "";
            lblCard11.Text = "";
            lblCard12.Text = "";
            lblCard13.Text = "";
            lblCard14.Text = "";
            lblCard15.Text = "";
            lblCard16.Text = "";
            lblCard17.Text = "";
            lblCard18.Text = "";
            lblCard19.Text = "";
            lblCard20.Text = "";
        }

        public void RemoveCards() //Function to make matching cards invisible (to remove them from the board)
        {
            if (lblCard1.Text != "")
                lblCard1.Visible = false;
            if (lblCard2.Text != "")
                lblCard2.Visible = false;
            if (lblCard3.Text != "")
                lblCard3.Visible = false;
            if (lblCard4.Text != "")
                lblCard4.Visible = false;
            if (lblCard5.Text != "")
                lblCard5.Visible = false;
            if (lblCard6.Text != "")
                lblCard6.Visible = false;
            if (lblCard7.Text != "")
                lblCard7.Visible = false;
            if (lblCard8.Text != "")
                lblCard8.Visible = false;
            if (lblCard9.Text != "")
                lblCard9.Visible = false;
            if (lblCard10.Text != "")
                lblCard10.Visible = false;
            if (lblCard11.Text != "")
                lblCard11.Visible = false;
            if (lblCard12.Text != "")
                lblCard12.Visible = false;
            if (lblCard13.Text != "")
                lblCard13.Visible = false;
            if (lblCard14.Text != "")
                lblCard14.Visible = false;
            if (lblCard15.Text != "")
                lblCard15.Visible = false;
            if (lblCard16.Text != "")
                lblCard16.Visible = false;
            if (lblCard17.Text != "")
                lblCard17.Visible = false;
            if (lblCard18.Text != "")
                lblCard18.Visible = false;
            if (lblCard19.Text != "")
                lblCard19.Visible = false;
            if (lblCard20.Text != "")
                lblCard20.Visible = false;
        }

        private void tmrCards_Tick(object sender, EventArgs e)
        {
            tmrCards.Enabled = false;
            UntapCards();
            tmrCards.Stop(); //Turn off the timer
        }

        public void Reset()
        {
            boardGame.Reset();
            _invisibleCards = 0;

            lblCard1.Tag = boardGame.cards[0].Symbol + "," + boardGame.cards[0].Position;
            lblCard2.Tag = boardGame.cards[1].Symbol + "," + boardGame.cards[1].Position;
            lblCard3.Tag = boardGame.cards[2].Symbol + "," + boardGame.cards[2].Position;
            lblCard4.Tag = boardGame.cards[3].Symbol + "," + boardGame.cards[3].Position;
            lblCard5.Tag = boardGame.cards[4].Symbol + "," + boardGame.cards[4].Position;
            lblCard6.Tag = boardGame.cards[5].Symbol + "," + boardGame.cards[5].Position;
            lblCard7.Tag = boardGame.cards[6].Symbol + "," + boardGame.cards[6].Position;
            lblCard8.Tag = boardGame.cards[7].Symbol + "," + boardGame.cards[7].Position;
            lblCard9.Tag = boardGame.cards[8].Symbol + "," + boardGame.cards[8].Position;
            lblCard10.Tag = boardGame.cards[9].Symbol + "," + boardGame.cards[9].Position;
            lblCard11.Tag = boardGame.cards[10].Symbol + "," + boardGame.cards[10].Position;
            lblCard12.Tag = boardGame.cards[11].Symbol + "," + boardGame.cards[11].Position;
            lblCard13.Tag = boardGame.cards[12].Symbol + "," + boardGame.cards[12].Position;
            lblCard14.Tag = boardGame.cards[13].Symbol + "," + boardGame.cards[13].Position;
            lblCard15.Tag = boardGame.cards[14].Symbol + "," + boardGame.cards[14].Position;
            lblCard16.Tag = boardGame.cards[15].Symbol + "," + boardGame.cards[15].Position;
            lblCard17.Tag = boardGame.cards[16].Symbol + "," + boardGame.cards[16].Position;
            lblCard18.Tag = boardGame.cards[17].Symbol + "," + boardGame.cards[17].Position;
            lblCard19.Tag = boardGame.cards[18].Symbol + "," + boardGame.cards[18].Position;
            lblCard20.Tag = boardGame.cards[19].Symbol + "," + boardGame.cards[19].Position;

            lblCard1.Visible = true;
            lblCard2.Visible = true;
            lblCard3.Visible = true;
            lblCard4.Visible = true;
            lblCard5.Visible = true;
            lblCard6.Visible = true;
            lblCard7.Visible = true;
            lblCard8.Visible = true;
            lblCard9.Visible = true;
            lblCard10.Visible = true;
            lblCard11.Visible = true;
            lblCard12.Visible = true;
            lblCard13.Visible = true;
            lblCard14.Visible = true;
            lblCard15.Visible = true;
            lblCard16.Visible = true;
            lblCard17.Visible = true;
            lblCard18.Visible = true;
            lblCard19.Visible = true;
            lblCard20.Visible = true;

            ClearCards();
            boardGame._count = 0;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void tmrMatch_Tick(object sender, EventArgs e)
        {
            RemoveCards();
            boardGame.Untap();
            tmrMatch.Enabled = false;
            tmrMatch.Stop(); //Turn off the timer
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}