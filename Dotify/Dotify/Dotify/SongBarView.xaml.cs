using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Dotify
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SongBarView : ContentView
    {
        public SongBarView()
        {

            /*
            var primaryColor = Color.FromHex("#FFFFFF");
            var secondaryColor = Color.FromHex("#242424");

            var grid = new Grid { HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(0,0,0,0), BackgroundColor = primaryColor};
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(24, GridUnitType.Absolute) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(24, GridUnitType.Absolute) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(48, GridUnitType.Absolute) });

            var name = new Label { Text = "Song Name", FontSize = 16, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = secondaryColor };
            var artist = new Label { Text = "Song Artist", FontSize = 12, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, TextColor = secondaryColor };
            var imageButton = new Image { Source = "play_icon.png" };

            Grid.SetRowSpan(imageButton, 2);

            grid.Children.Add(name, 0, 0);
            grid.Children.Add(artist, 0, 1);
            grid.Children.Add(imageButton, 1, 0);
            */
            InitializeComponent();
        }
    }
}