using System;
using System.Collections.Generic;
using System.Linq;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            _identifiers.AddRange(idents);
        }

        public List<string> Identifiers
        {
            get { return _identifiers; }
            set { _identifiers = value; }
        }

        public bool AreYou(string id) //! Checks if the passed in id is already in the identifier array
        {
            foreach (string identifier in _identifiers)
            {
                if (identifier.ToLower() == id.ToLower())
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
                return _identifiers.First();
            }
        }

        public void AddIdentifier(string id)
        {
            id = id.ToLower();
            Identifiers.Add(id);
        }
    }
}
