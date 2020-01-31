using UnityEngine;

namespace Code.Item
{
    public abstract class Item : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;

        public Sprite Icon
        {
            get => icon;
            set => icon = value;
        }

        public string Name
        {
            get => name; 
            set => name = value;
        }
    }
}
