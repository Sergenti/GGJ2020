using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ItemDisplayer : MonoBehaviour
    {
        private Image image;

        private void Start()
        {
            image = GetComponent<Image>();
        }

        public void DisplayItem(Item.Item item)
        {
            Sprite sprite = item.Icon;
            image.sprite = sprite;
        }
    }
}
