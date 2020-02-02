using Code.Item;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    //Simple displayer, we will later display an animation instead
    public class ToolDisplay : MonoBehaviour
    {
        private Animator anim;
        
        void Start()
        {
            anim = GetComponent<Animator>();
        }

        public void DisplayToolName(RepairTool tool)
        {
            anim.SetInteger("idx",tool.AnimIdx);
        }
    }
}
