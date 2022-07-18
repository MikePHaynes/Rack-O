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
        public Stack Deck { get; set; }
        public Stack Discarded { get; set; }
        public int Choice { get; set; }

        public Form1()
        {
            InitializeComponent();
            DisableSelections();
            DisableSlots();
        }

        private void Select(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int toDiscard = int.Parse(button.Text);
            button.Text = Choice.ToString();
            switch(button.Name)
            {
                case "Slot5":
                    Players[0].Deck[0] = Choice;
                    break;
                case "Slot10":
                    Players[0].Deck[1] = Choice;
                    break;
                case "Slot15":
                    Players[0].Deck[2] = Choice;
                    break;
                case "Slot20":
                    Players[0].Deck[3] = Choice;
                    break;
                case "Slot25":
                    Players[0].Deck[4] = Choice;
                    break;
                case "Slot30":
                    Players[0].Deck[5] = Choice;
                    break;
                case "Slot35":
                    Players[0].Deck[6] = Choice;
                    break;
                case "Slot40":
                    Players[0].Deck[7] = Choice;
                    break;
                case "Slot45":
                    Players[0].Deck[8] = Choice;
                    break;
                case "Slot50":
                    Players[0].Deck[9] = Choice;
                    break;
            }
            if(Players[0].Check())
                Application.Exit();
            Discard.Text = toDiscard.ToString();
            Discarded.Push(new Node(toDiscard));
            DisableSlots();
            EnableSelections();
        }

        private void DrawSelect(object sender, EventArgs e)
        {
            DisableSelections();
            Choice = Deck.Pop().Value;
            Message.Text = $"You drew a {Choice}!";
            EnableSlots();
        }

        private void DiscardSelect(object sender, EventArgs e)
        {
            DisableSelections();
            Choice = Discarded.Pop().Value;
            EnableSlots();
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
            Discarded = new Stack();
            Discarded.Push(Deck.Pop());
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
            Discard.Text = Discarded.Top.Value.ToString();
            EnableSelections();
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

        private void DisableSlots()
        {
            Slot5.Enabled = false;
            Slot10.Enabled = false;
            Slot15.Enabled = false;
            Slot20.Enabled = false;
            Slot25.Enabled = false;
            Slot30.Enabled = false;
            Slot35.Enabled = false;
            Slot40.Enabled = false;
            Slot45.Enabled = false;
            Slot50.Enabled = false;
        }

        private void EnableSlots()
        {
            Slot5.Enabled = true;
            Slot10.Enabled = true;
            Slot15.Enabled = true;
            Slot20.Enabled = true;
            Slot25.Enabled = true;
            Slot30.Enabled = true;
            Slot35.Enabled = true;
            Slot40.Enabled = true;
            Slot45.Enabled = true;
            Slot50.Enabled = true;
        }

        private void DisableSelections()
        {
            Discard.Enabled = false;
            Draw.Enabled = false;
        }

        private void EnableSelections()
        {
            Discard.Enabled = true;
            Draw.Enabled = true;
        }
    }
}
