using System;
using Code.Item;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
    public class ItemDisplayer : MonoBehaviour
    {
        private Animator anim;

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void DisplayItem(Item.Item item)
        {
            anim.SetInteger("abc",item.AnimIdx);
        }
    }
}
