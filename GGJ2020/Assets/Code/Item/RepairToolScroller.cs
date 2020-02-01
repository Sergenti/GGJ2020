using System;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Item
{
    // Scroll through the toolList and raise 3 toolEvent, previous,current and next, tool
    public class RepairToolScroller : MonoBehaviour
    {
        [Space,Header("Events")]
        [SerializeField] private ToolEvent previousToolEvent;
        [SerializeField] private ToolEvent currentToolEvent;
        [SerializeField] private ToolEvent nextToolEvent;
        [Space]
        [SerializeField] private RepairToolList toolList;
        [SerializeField] private float cooldown = 0.1f;
        private float cooldownTimer = 0f;

        private int _toolListIdx = 0;

        //NO OTHER SOLUTION FOR NOW
        private bool hadPrintOnce = false;


        void Update()
        {
            //Force to select an item at the beginning of thw game
            if (!hadPrintOnce)
            {
                if(toolList.GetRepairTool(0) == null){return;}
                currentToolEvent.Raise(toolList.GetRepairTool(0));
                hadPrintOnce = true;
            }

            Debug.Log("Up: " + Input.GetAxisRaw("ItemScrollUp") + "\nDown: " + Input.GetAxisRaw("ItemScrollDown"));
            // use cooldown to prevent too fast scrolling using the joystick (cause its triggers are axis input)
            if (cooldownTimer >= cooldown)
            {
                if (Input.GetButtonDown("ItemScrollUp") || Input.GetAxisRaw("ItemScrollUp") == 1)
                {
                    _toolListIdx = (_toolListIdx + 1) % toolList.GetListSize();
                    currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));
                }
                else if (Input.GetButtonDown("ItemScrollDown") || Input.GetAxisRaw("ItemScrollDown") == 1)
                {
                    _toolListIdx = (_toolListIdx - 1);

                    if (_toolListIdx < 0)
                    {
                        _toolListIdx = toolList.GetListSize() - 1;
                    }

                    currentToolEvent.Raise(toolList.GetRepairTool(_toolListIdx));
                }

                // reset timer
                cooldownTimer = 0f;
            }
            
            // increment timer
            cooldownTimer += Time.deltaTime;
        }
    }
}
