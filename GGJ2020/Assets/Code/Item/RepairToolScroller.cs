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
        private bool canScrollUp = true;
        private bool canScrollDown = true;

        private int _toolListIdx = 0;

        //NO OTHER SOLUTION FOR NOW
        private bool hadPrintOnce = false;


        void Update()
        {
            if (!hadPrintOnce)
            {
                if (toolList.GetRepairTool(0) == null) { return; }
                currentToolEvent.Raise(toolList.GetRepairTool(0));
                hadPrintOnce = true;
            }

            // check if joystick triggers have been released
            if (Input.GetAxisRaw("ItemScrollUp") == 0 && !canScrollUp)      canScrollUp = true;
            if (Input.GetAxisRaw("ItemScrollDown") == 0 && !canScrollDown)  canScrollDown = true;

            // check if player has pressed an item scroll button
            if (Input.GetButtonDown("ItemScrollUp") || (Input.GetAxisRaw("ItemScrollUp") == 1 && canScrollUp))
            {
                _toolListIdx = (_toolListIdx + 1) % toolList.GetListSize();
                currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));

                canScrollUp = false;
            }
            else if (Input.GetButtonDown("ItemScrollDown") || (Input.GetAxisRaw("ItemScrollDown") == 1 && canScrollDown))
            {
                _toolListIdx = (_toolListIdx - 1);

                if (_toolListIdx < 0)
                {
                    _toolListIdx = toolList.GetListSize() - 1;
                }

                currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));

                canScrollDown = false;
            }
        }
    }
}
