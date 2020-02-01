using System;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Item
{
    // For now it display the text of the item, I wait for the sprites
    public class Materialscroller : MonoBehaviour
    {
        [SerializeField] private MaterialEvent currentMaterialEvent;
        [SerializeField] private RepairMaterialList materialList;

        //NO SOLUTION FOR NOW
        private bool hasPrintOnce = false;
   
        [SerializeField] private float cooldown = 0.1f;
        private float cooldownTimer = 0f;

        private int _materialListIdx = 0;

        void Update()
        {
            if (!hasPrintOnce)
            {
                if(materialList.GetRepairTool(0) == null) {return;}
                currentMaterialEvent.Raise(materialList.GetRepairTool(0));
                hasPrintOnce = true;
            }
   
            // use cooldown to prevent too fast scrolling using the joystick (cause its DPAD is an axis input)
            if (cooldownTimer >= cooldown)
            {
                if (Input.GetButtonDown("MaterialScrollUp") || Input.GetAxisRaw("MaterialScrollJoystick") == -1)
                {
                    _materialListIdx = (_materialListIdx + 1) % materialList.GetListSize();
                    currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
                }
                else if (Input.GetButtonDown("MaterialScrollDown") || Input.GetAxisRaw("MaterialScrollJoystick") == 1)
                {
                    _materialListIdx = (_materialListIdx - 1);

                    if (_materialListIdx < 0)
                    {
                        _materialListIdx = materialList.GetListSize() - 1;
                    }

                    currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
                }

                // reset timer
                cooldownTimer = 0f;
            }


            // increment cooldown timer
            cooldownTimer += Time.deltaTime;
        }
    }
}
