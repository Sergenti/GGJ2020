using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Item
{
    public class RepairToolScroller : MonoBehaviour
    {
        [SerializeField] private ToolEvent currentToolEvent;
        [SerializeField] private RepairToolList toolList;

        private int _toolListIdx = 0;
        
        void Update()
        {

            if (Input.GetButtonDown("ItemScrollUp"))
            {
                _toolListIdx = (_toolListIdx + 1) % toolList.GetListSize();
                currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));
            }
            else if (Input.GetButtonDown("ItemScrollDown"))
            {
                _toolListIdx = (_toolListIdx - 1);
                if (_toolListIdx < 0)
                {
                    _toolListIdx = toolList.GetListSize() - 1;
                }
                currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));
            }
        }
    }
}
