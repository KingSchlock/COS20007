using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        //! Everything that has an inventory has to have the ability to
        //! locate items.
        GameObject Locate(string id);

        public string Name
        {
            get;
        }
    }
}
