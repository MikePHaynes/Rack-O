using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack_O
{
    public class Player
    {
        public String Name { get; set; }
        public int[] Deck { get; set; }
        public bool Won { get; set; }
        
        public Player(String name)
        {
            Name = name;
            Deck = new int[10];
            Won = false;
        }

        public void AddCard(Node card)
        {
            for(var i = 0; i < Deck.Length; i++)
            {
                if(Deck[i] == 0)
                {
                    Deck[i] = card.Value;
                    break;
                }
            }
        }

        public bool Check()
        {
            for (var i = 0; i < Deck.Length - 1; i++)
            {
                if (Deck[i] > Deck[i + 1])
                    return false;
            }
            Won = true;
            return true;         
        }



    }
}
