using System;

namespace GestStock.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public bool Borrowed { get; set; }
    }
}