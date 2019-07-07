using SudokuValidator.Models;
using SudokuWsei.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SudokuWsei
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class SudokuPage : ContentPage
    {
        public IList<SudokuItem> Sudoku { get; private set; }

        public SudokuPage()
        {
            Label header = new Label
            {
                Text = "Sudoku",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            // Create the CollectionView.
            CollectionView collectionView = new CollectionView
            {
                // Define the layout.
                ItemsLayout = new GridItemsLayout(9, ItemsLayoutOrientation.Vertical),

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for each item
                ItemTemplate = new DataTemplate(() =>
                {
                    Grid grid = new Grid { Padding = 1 };
                    grid.RowDefinitions.Add(new RowDefinition { Height = 35 });
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 70 });

                    Entry value = new Entry { FontAttributes = FontAttributes.Italic, VerticalOptions = LayoutOptions.End };
                    value.SetBinding(Entry.TextProperty, "Value");

                    Grid.SetRowSpan(value, 2);

                    grid.Children.Add(value);

                    return grid;
                })
            };

            Button submit = new Button
            {
                Text = "Check"
            };

            collectionView.SetBinding(ItemsView.ItemsSourceProperty, "Sudoku");

            // Build the page.
            Title = "Sudoku";
            Content = new StackLayout
            {
                Margin = new Thickness(20),
                Children =
                {
                    header,
                    collectionView,
                    submit
                }
            };

            CreateSudokuCollection();
            BindingContext = this;
        }

        void CreateSudokuCollection()
        {
            Sudoku = new List<SudokuItem>();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Sudoku.Add(new SudokuItem(i, j, i * 10 + j));
                }
            }
        }
    }
}
