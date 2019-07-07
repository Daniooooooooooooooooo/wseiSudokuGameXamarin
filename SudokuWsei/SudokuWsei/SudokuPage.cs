using SudokuValidator.Models;
using SudokuWsei.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SudokuWsei
{
    [DesignTimeVisible(false)]
    public partial class SudokuPage : ContentPage
    {
        public IList<SudokuItem> Sudoku { get; private set; }

        public SudokuPage(string sudoku)
        {
            Label header = new Label
            {
                Text = "Sudoku",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            CollectionView collectionView = new CollectionView
            {
                ItemsLayout = new GridItemsLayout(9, ItemsLayoutOrientation.Vertical),

                ItemTemplate = new DataTemplate(() =>
                {
                    Grid grid = new Grid { Padding = 1 };
                    grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 70 });

                    Entry value = new Entry { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                    value.SetBinding(Entry.TextProperty, "Value");
                    value.TextChanged += Value_TextChanged;

                    Grid.SetRowSpan(value, 2);

                    grid.Children.Add(value);

                    return grid;
                })
            };

            Button check = new Button
            {
                Text = "Check"
            };
            check.Clicked += Check_Clicked;

            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Sudoku");

            Title = "Sudoku";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    header,
                    collectionView,
                    check
                }
            };

            CreateSudokuCollection(sudoku);
            BindingContext = this;
        }

        private void Value_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
            {
                var newInput = e.NewTextValue.Length == 2
                    ? e.NewTextValue[1]
                    : e.NewTextValue[0];

                if (!int.TryParse(newInput.ToString(), out var newValue)
                    || newValue < 1 || newValue > 9)
                {
                    (sender as Entry).Text = "";
                }
                else
                {
                    (sender as Entry).Text = newInput.ToString();
                }
            }
        }

        private async void Check_Clicked(object sender, EventArgs e)
        {
            var sudokuString = new StringBuilder();

            foreach (var item in this.Sudoku)
            {
                sudokuString.Append(item.Value);
            }

            var sudokuModel = new SudokuModel(sudokuString.ToString());

            if (SudokuValidator.SudokuValidator.Validate(sudokuModel))
            {
                await DisplayAlert("Won", "Congratulations You won", "Back");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Wrong", "Try Again!", "Back");
            }
        }

        void CreateSudokuCollection(string sudoku)
        {
            Sudoku = new List<SudokuItem>();

            for (int i = 0; i < sudoku.Length; i++)
            {
                Sudoku.Add(new SudokuItem(int.Parse(sudoku[i].ToString())));
            }
        }
    }
}
