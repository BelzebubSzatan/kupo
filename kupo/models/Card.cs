﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace kupo.models {
    public class Card {
        public string Value { get; set; }
        public System.Drawing.Color Color { get; set; }
        public SpecialActions Action { get; set; }
        public Button Render() {
            return new Button() { 
                WidthRequest=80,
                HeightRequest=150,
                BackgroundColor=Color,
                TextColor=System.Drawing.Color.White,
                Margin=new Thickness(5),
                VerticalOptions=LayoutOptions.FillAndExpand
            };
        }
    }
}
