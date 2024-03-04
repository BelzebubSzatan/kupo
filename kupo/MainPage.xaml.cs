using kupo.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace kupo {
    public partial class MainPage : ContentPage {
        Deck deck=new Deck();
        List<Card> playerCards = new List<Card>();
        List<Card> computerCards = new List<Card>();
        Card LastCards = null;
        bool win=false;
        bool playerAction = true;
        public MainPage() {
            InitializeComponent();
            playerCards = deck.GetPlayerCards(3);
            computerCards = deck.GetPlayerCards(3);
            RenderPlayerCards();
            SetLastCard(null);
        }

        public void RenderPlayerCards() {

        }
        private void PlayerCardClick(object sender, EventArgs e) {

        }
        private async void Wincheck() {
            if(playerCards.Count == 0)
            {
                win = true;
                await DisplayAlert("Wygrana", "Wygrał gracz", "OK");
            }
            if(computerCards.Count == 0)
            {
                win = true;
                await DisplayAlert("Wygrana", "Wygrał komputer", "OK");
            }
        }
        private void SetLastCard(Card c) {
            if(LastCards == null)
            {
                LastCards = deck.deck[0];
                deck.deck.RemoveAt(0);
            }else
            {
                LastCards = c;
            }
            LastCardText.Text = LastCards.Value.ToString();
            LastCardStack.BackgroundColor = LastCards.Color;
        }
        public async void ComputerMove() {
            if (win == true) return;
            List<Card> possibleMove = computerCards.Where(e => e.Color.ToString() == LastCards.Color.ToString() || e.Value == LastCards.Value || e.Action == SpecialActions.Color).ToList();
            if(possibleMove.Count>0)
            {
                Random r = new Random();
                int n = r.Next(possibleMove.Count);
                await Task.Delay(1000);
                SetLastCard(possibleMove[n]);
                SpecialCardAction(playerCards, possibleMove[n]);
                ComputerAction.Text = "Komputer dał" + possibleMove[n].Value + " " + possibleMove[n].Color.ToString();
                computerCards.Remove(possibleMove[n]);
            }else
            {
                ComputerAction.Text = "Komputer dobral";
                computerCards.Add(deck.deck[0]);
                deck.deck.RemoveAt(0);
            }
            playerAction = true;
            Wincheck();
            RenderPlayerCards();
        }
        public void SpecialCardAction(List<Card> target,Card c) {
            if (deck.deck.Count < 10)
                deck.GenerateDeck();
            if(c.Action == SpecialActions.AddTwo)
            {
                for (int i = 0; i < 2; i++)
                {
                    target.Add(deck.deck[i]);
                    deck.deck.RemoveAt(i);
                }
            }
            if(c.Action == SpecialActions.AddFour)
            {
                for (int i = 0; i < 4; i++)
                {
                    target.Add(deck.deck[i]);
                    deck.deck.RemoveAt(i);
                }
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            if(playerAction&&!win)
            {
                playerCards.Add(deck.deck[0]);
                deck.deck.RemoveAt(0);
                playerAction = false;
                ComputerMove();
            }
        }
    }
}
