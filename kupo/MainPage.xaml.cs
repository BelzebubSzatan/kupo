﻿using kupo.models;
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
