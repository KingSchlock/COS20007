using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {

        }

        public string ItemList //! Holds a string containing a list of our inventory items
        {
            get {
                string list = "";
                foreach (Item itm in _items)
                {
                    list += "\t" + "a " + itm.Name + " " + "(" + itm.FirstId + ")\n";
                };
                return list;
            }
        }

        public bool HasItem(string id) //! Checks inventory for specific item and if the item exists in inventory, returns true.
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return true;
                }
            }
            return false; //x Error: Has item is always returning true. stupid fucking error.
        }

        public Item Fetch(string id) //! Checks our inventory for a specific item and returns it
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }

        public void Put(Item itm) //! Adds item to inventory
        {
            _items.Add(itm);
        }

        public Item Take(string id) //! stores the fetched item in a new Item and returns it
        {
            Item itm = Fetch(id);

            if(_items != null)
            {
                _items.Remove(itm);
                return itm;
            }
            return null; //! do i need to remove the item manually with itm.
            //x Error with possibly null array
        }
    }
}
