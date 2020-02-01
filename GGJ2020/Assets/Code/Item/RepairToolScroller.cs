using System;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Item
{
    // Scroll through the toolList and raise 3 toolEvent, previous,current and next, tool
    public class RepairToolScroller : MonoBehaviour
    {
        [SerializeField] private ToolEvent previousToolEvent;
        [SerializeField] private ToolEvent currentToolEvent;
        [SerializeField] private ToolEvent nextToolEvent;
        [SerializeField] private RepairToolList toolList;

        private int _toolListIdx = 0;

        //NO OTHER SOLUTION FOR NOW
        private bool hadPrintOnce = false;


        void Update()
        {
            if (!hadPrintOnce)
            {
                if(toolList.GetRepairTool(0) == null){return;}
                currentToolEvent.Raise(toolList.GetRepairTool(0));
                hadPrintOnce = true;
            }

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
