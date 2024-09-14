namespace Models
{
    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ItemId { get; set; }

        public Item(string name, decimal price, string itemId)
        {
            Name = name;
            Price = price;
            ItemId = itemId;
        }
    }
    
    public class Book : Item
    {
        private string Author { get; set; }

        public Book(string name, decimal price, string itemId, string author)
            : base(name, price, itemId)
        {
            Author = author;
        }
    }


    public class ElectronicDevice : Item
    {
        private string Brand { get; set; }

        public ElectronicDevice(string name, decimal price, string itemId, string brand)
            : base(name, price, itemId)
        {
            Brand = brand;
        }
    }
}
