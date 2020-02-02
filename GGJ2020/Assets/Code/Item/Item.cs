using UnityEditor.Animations;
using UnityEngine;

namespace Code.Item
{
    public abstract class Item : ScriptableObject
    {
        //An item is a material or a tool (It will be define by an animation also)
        [SerializeField] private string name;
        [SerializeField] private Sprite icon;
        [SerializeField] private AnimatorController animation;
        [SerializeField] private int animIdx;

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

        public AnimatorController Animation
        {
            get => animation;
            set => animation = value;
        }

        public int AnimIdx => animIdx;
    }
}
