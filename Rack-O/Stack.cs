using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rack_O
{
    public class Stack
    {
        public int Size { get; set; }
        public Node Top { get; set; }

        public Stack()
        {
            Size = 0;
            Top = null;
        }

        public void Push(Node node) 
        { 
            node.Next = Top;
            Top = node;
            Size++;
        }

        public Node Pop()
        {
            if(Size == 0)
                return null;

            Node old = Top;
            Top = Top.Next;
            Size--;
            old.Next = null;
            return old;
        }

        public void Clear()
        {
            Top = null;
            Size = 0;
        }

        public void Swap(Stack deck)
        {
            Top = deck.Top;
            Size = deck.Size;
        }
    }
}
