using System.Collections.Generic;

namespace RoundStart.Items
{
    public class Itemlist
    {
        private static List<ItemType> _itemTypes = new List<ItemType>();

        public static List<ItemType> GetItemTypes()
        {
            return _itemTypes;
        }

        public static void AddItem(ItemType item)
        {
            _itemTypes.Add(item);
        }

        public static void RemoveItem(ItemType item)
        {
            _itemTypes.Remove(item);
        }

        public static void ItemClear()
        {
            _itemTypes.Clear();
        }
    }
}
