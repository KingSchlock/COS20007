using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {

        }

        //! A series of checks which run when the look command is used
        //! Returns the same as LookAtIn
        public override string Execute(Player player, string[] text)
        {
            IHaveInventory container;
            string thingId;

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look for that.";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 5 && text[3] != "in")
            {
                return "What do you want to look in?";
            }


            if (text.Length == 3)
            {
                container = player;
            }
            else
            {
                container = FetchContainer(player, text[4]);
            }

            if (container == null)
            {
                return $"I can't find the {text[4]}";
            }

            thingId = text[2];
            return LookAtIn(thingId, container);
        }
        
        //! Grabs a container based on a string
        private IHaveInventory FetchContainer(Player player, string containerId)
        {
            return player.Locate(containerId) as IHaveInventory;
        }

        //! checks if the thing requested exists inside a container, if so return it's full description
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if(container.Locate(thingId) == null)
            {
                return $"I can't find the {thingId}";
            }
            else
            {
                return container.Locate(thingId).FullDescription;
            }
        }
    }
}
