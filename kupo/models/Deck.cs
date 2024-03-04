using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace kupo.models {
    public class Deck {
        public List<Card> deck=new List<Card>();
        private readonly List<System.Drawing.Color> colors = new List<System.Drawing.Color>() { 
            System.Drawing.Color.Red, System.Drawing.Color.Green,
            System.Drawing.Color.Blue, System.Drawing.Color.Yellow,
        };
        private readonly List<string> Values= new List<string>() { 
            "1","2","3","4","5","6","7","8","9","+2","+4","kolor"
        };
        public void GenerateDeck() {
            foreach (var value in Values) {
                foreach (var color in colors) {
                    deck.Add(new Card() {
                        Color = color,
                        Value = value,
                        Action=GetAction(value)
                    });
                }
            }
            Shuffle();
        }

        private void Shuffle() {
            Random r= new Random();
            deck = deck.OrderBy(z => r.Next()).ToList();
        }

        public Deck()
        {
            GenerateDeck();
        }
        private SpecialActions GetAction(string value) {
            switch (value) {
                case "+2":
                    return SpecialActions.AddTwo;
                case "+4":
                    return SpecialActions.AddFour;
                case "kolor":
                    return SpecialActions.Color;
                default:
                    return SpecialActions.Normal;
            }
        }
        public List<Card> GetPlayerCards(int x) {
            List<Card> cards = deck.GetRange(0,x).OrderBy(z=>z.Color.ToString()).ToList();
            deck.RemoveRange(0,x);
            return cards;
        }
    }
}
