using DailyNotes.Models;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DailyNotes.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// しぶしぶコードビヘイビアに書きます・・・
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (Notes)e.SelectedItem;

            DisplayAlert("ItemSelected", item.Id.ToString(), "Ok");
        }
    }
}
