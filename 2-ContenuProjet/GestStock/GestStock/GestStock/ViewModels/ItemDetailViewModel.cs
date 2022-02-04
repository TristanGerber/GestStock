using GestStock.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySqlConnector;

namespace GestStock.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        private bool borrowed;
        private string state;
        private Color buttonBackgroundColor;
        public Color ButtonBackgroundColor { get => buttonBackgroundColor; set => SetProperty(ref buttonBackgroundColor, value); }
        public Command BorrowCommand { get; }
        public string Id { get; set; }

        public string State
        {
            get => state;
            set => SetProperty(ref state, value);
        }
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public bool Borrowed
        {
            get => borrowed;
            set
            {
                State = value ? "Rendre" : "Emprunter";
                ButtonBackgroundColor = value ? Color.Red : Color.Green;
                SetProperty(ref borrowed, value);
            }
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public ItemDetailViewModel()
        {
            BorrowCommand = new Command(OnBorrowClicked);
        }

        private void OnBorrowClicked(object obj)
        {
            Borrowed = !Borrowed;
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                Item item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
                Borrowed = item.Borrowed;
                State = "Emprunter";
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
