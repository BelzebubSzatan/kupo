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
            if (win)
                return;
            PlayerCards.Children.Clear();
            playerCards=playerCards.OrderBy(z=>z.Color.ToString()).ToList();
            foreach (Card card in playerCards) {
                Button c = card.Render();
                c.BindingContext = card;
                c.Clicked += PlayerCardClick;
                if(playerAction) {
                    if(card.Color==LastCards.Color|| card.Value==LastCards.Value||card.Action==SpecialActions.Color) {
                        c.BorderColor =Color.Black;
                        c.BorderWidth = 2;
                    }
                }
                PlayerCards.Children.Add(c);
            }
            ComputerCards.Text = computerCards.Count.ToString() + " Ilosc kart przeciwnika";

        }
        private void PlayerCardClick(object sender, EventArgs e) {
            if(win) return;
            Card c=(sender as Button).BindingContext as Card;
            if((sender as Button).BorderColor == Color.Black) {
                SetLastCard(c);
                playerCards.Remove(c);
                playerAction = false;
                Wincheck();
                ComputerMove();
            }
        }
        private void Wincheck() {

        }
        private void SetLastCard(Card c) {

        }
        public void ComputerMove() {

        }
        public void SpecialCardAction(List<Card> target,Card c) {

        }
        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
