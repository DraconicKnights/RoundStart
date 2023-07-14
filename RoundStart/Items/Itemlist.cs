using System.Collections.Generic;

namespace RoundStart.Items
{
    public class Itemlist
    {
        private static List<ItemType> itemTypes = new List<ItemType>();

        public static List<ItemType> GetItemTypes()
        {
            return itemTypes;
        }

        public static void addItem(ItemType item)
        {
            itemTypes.Add(item);
        }

        public static void removeItem(ItemType item)
        {
            itemTypes.Remove(item);
        }

        public static void itemClear()
        {
            itemTypes.Clear();
        }
    }
}
