using Code.Item;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    //Simple displayer, we will later display an animation instead
    public class ToolDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        public void DisplayToolName(RepairTool tool)
        {
            _text.text = tool.Name;
        }
    }
}
