using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        public Command(string[] idents) : base(idents)
        {
        }

        public abstract string Execute(Player player, string[] text);
    }
}
