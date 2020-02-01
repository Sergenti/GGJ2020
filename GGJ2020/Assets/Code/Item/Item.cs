using UnityEngine;

namespace Code.Item
{
    public abstract class Item : ScriptableObject
    {
        //An item is a material or a tool (It will be define by an animation also)
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;

        //Get set
        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }

        //Get set
        public string Name
        {
            get => name; 
            set => name = value;
        }
    }
}
