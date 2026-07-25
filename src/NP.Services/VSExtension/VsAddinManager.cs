using System.Collections.Generic;
using NP.Core.Models;

namespace NP.Services.VSExtension
{
    public class VsAddinManager
    {
        private List<VsAddinInfo> _items;

        public VsAddinManager()
        {
            _items =
                new List<VsAddinInfo>();
        }

        public List<VsAddinInfo> Items
        {
            get
            {
                return _items;
            }
        }

        public void Add(
            string property,
            string value)
        {
            VsAddinInfo item =
                new VsAddinInfo();

            item.Time = System.DateTime.Now;
            item.Property = property;
            item.Value = value;

            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }
    }
}