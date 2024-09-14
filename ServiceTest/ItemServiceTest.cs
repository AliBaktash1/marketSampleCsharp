using Models;
using NUnit.Framework;
using Service;
using Assert = Xunit.Assert;

namespace ServiceTest
{
    public class ItemServiceTest
    {
        [Test]
        public void AddItem_ShouldAddItemSuccessfully()
        {
            var itemService = new ItemService();
            var item = new Book("C# Book", 29.99m, "B001", "Author Name");

            itemService.AddItem(item);

            Assert.Equal(item, itemService.GetItemById("B001"));
        }

        [Test]
        public void RemoveItem_ShouldRemoveItemSuccessfully()
        {
            var itemService = new ItemService();
            var item = new Book("C# Book", 29.99m, "B001", "Author Name");
            itemService.AddItem(item);

            itemService.RemoveItem("B001");

            Assert.Null(itemService.GetItemById("B001"));
        }
    }
}
