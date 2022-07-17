using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rack_O
{
    public partial class Form1 : Form
    {
        public Player[] Players { get; set; }
        Stack Deck { get; set; }

        public Form1()
        {
            InitializeComponent();

            
        }

        private void Select(object sender, EventArgs e)
        {
            Button button = (Button)sender;
        }

        private void DrawSelect(object sender, EventArgs e)
        {

        }

        private void DiscardSelect(object sender, EventArgs e)
        {

        }

        private void Host(object sender, EventArgs e) // Start
        {
            List<int> list = new List<int>();
            for(var i = 0; i < 60; i++)
                list.Add(i + 1);

            Players = new Player[2];
            Players[0] = new Player("Mike");
            Players[1] = new Player("Computer");
            Deck = GenerateDeck(list);
            for (var i = 0; i < (Players.Length * 10); i++)
                Players[i % Players.Length].AddCard(Deck.Pop());
            Slot5.Text = Players[0].Deck[0].ToString();
            Slot10.Text = Players[0].Deck[1].ToString();
            Slot15.Text = Players[0].Deck[2].ToString();
            Slot20.Text = Players[0].Deck[3].ToString();
            Slot25.Text = Players[0].Deck[4].ToString();
            Slot30.Text = Players[0].Deck[5].ToString();
            Slot35.Text = Players[0].Deck[6].ToString();
            Slot40.Text = Players[0].Deck[7].ToString();
            Slot45.Text = Players[0].Deck[8].ToString();
            Slot50.Text = Players[0].Deck[9].ToString();
        }

        private Stack GenerateDeck(List<int> list)
        {
            Random random = new Random();
            Stack deck = new Stack();
            while(list.Count != 0)
            {
                int index = random.Next(list.Count);
                deck.Push(new Node(list[index]));
                list.RemoveAt(index);
            }
            return deck;
        }
    }
}
