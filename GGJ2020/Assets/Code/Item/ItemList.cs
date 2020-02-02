using System.Collections.Generic;
using UnityEngine;

namespace Code.Item
{
    public abstract class ItemList<Item> : ScriptableObject
    {
        [SerializeField]private List<Item> items = new List<Item>();
        
        public Item GetRepairTool(int idx)
        {
            return items[idx];
        }
       
        public int GetListSize()
        {
            return items.Count;
        }

        public List<Item> Items => items;
    }
}