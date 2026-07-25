using System;
using System.Collections.Generic;

namespace NP.Services.Development
{
    public class BuildLogger
    {
        private readonly List<string> _items =
            new List<string>();

        public IEnumerable<string> Items
        {
            get
            {
                return _items;
            }
        }

        public void Add(
            string text)
        {
            _items.Add(
                DateTime.Now.ToString("HH:mm:ss")
                + "  "
                + text);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}