using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> identifiers = new();

        public IdentifiableObject(string[] idents)
        {
            identifiers.AddRange(idents);
        }

        public List<string> Identifiers
        {
            get { return identifiers; }
            set { identifiers = value; }
        }

        public bool AreYou(string id) //! Checks if the passed in id is already in the identifier array
        {
            foreach (string identifier in identifiers)
            {
                if(identifier.ToLower() == id.ToLower())
                {
                    return true;
                }
            }

            return false;
        }

        public string FirstId
        {
            get
            {
                if(identifiers.Count == 0)
                {
                    return "";
                }
                else { return identifiers.First(); }
            }
        }

        public void AddIdentifier(string id)
        {
            id = id.ToLower();
            Identifiers.Add(id);
        }
    }
}
