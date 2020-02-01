using Code.Item;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public class ToolDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        // Start is called before the first frame update
        void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void DisplayToolName(RepairTool tool)
        {
            _text.text = tool.Name;
        }
    }
}
