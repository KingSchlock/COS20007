using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject //x TODO Implement Inventory field, property and Locate Operation
    {
        Inventory _inventory = new Inventory();
        public Player(string name, string description) : base(new string[] {"me", "inventory"}, name, description)
        {

        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public override string FullDescription //! Can only override virtual properties
        {
            get { return $"You are {Name} {base.FullDescription}.\nYou are carrying\n{Inventory.ItemList}"; }
        }
        public GameObject Locate(string id) //! Checks if the player holds an object with id
        {
            if (this.AreYou(id) == true)
            {
                return this; // returns this object
            }
            return _inventory.Fetch(id); // if the object isn't around then check our inventory for it
            /*! NOTE: 
             *      The Locate operation should return null if no objects match id as the default return value for
             *      Fetch is null.
             */
        }
    }
}
