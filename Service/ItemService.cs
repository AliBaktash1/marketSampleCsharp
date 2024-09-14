using Models;

namespace Service
{
    public class ItemService
    {
        private List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine("Item added successfully.");
        }

        public void RemoveItem(string itemId)
        {
            Item item = items.FirstOrDefault(i => i.ItemId == itemId);
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine("Item removed successfully.");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }
        }

        public void DisplayItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Item ID: {item.ItemId}");
            }
        }

        public Item GetItemById(string itemId)
        {
            return items.FirstOrDefault(i => i.ItemId == itemId);
        }
    }
}
