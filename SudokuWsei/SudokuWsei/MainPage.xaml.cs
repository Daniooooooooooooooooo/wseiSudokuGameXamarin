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
    public partial class MainPage : ContentPage
    {
        private List<string> MatrixList = new List<string>();

        public MainPage()
        {
            InitializeComponent();
            MatrixList.Add("530070000600195000098000060800060003400803001700020006060000280000419005000080079");
            MatrixList.Add("876900000010006000040305800400000210090500000050040306029000008004690173000001004");
            MatrixList.Add("000000000093628140060000050030010090050802070040070060080000030017593420000000000");
            MatrixList.Add("004678900030000050200050001500406009900307004302000806410000092090000060005719300");
            MatrixList.Add("000000000000003085001020000000507000004000100090000000500000073002010000000040009");
            MatrixList.Add("100400050600009007000800091400900800060000030007001009250008000900300006040002008");
            MatrixList.Add("000078000003060100000009050100000803008000075930800000070050060409700000560903000");
            MatrixList.Add("080070090900000007002000600030604080000000000070208050004000800500000002010090030");
            MatrixList.Add("500002080000000006007100530030700059002040800750009010098004300100000000020800005");
            MatrixList.Add("000008000700400680300500020030200006400600000006073450070300000051002000900050870");
            MatrixList.Add("534678912672195348198342567859761423426853791713924856961537284287419635345286179");

            IndexPicker.SelectedIndex = 0;
        }

        public async void OnButtonClicked(object sender, EventArgs args)
        {
            int index = IndexPicker.SelectedIndex;
            await Navigation.PushModalAsync(new SudokuPage(MatrixList[index]));
        }
    }
}
