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

        private bool canScroll = true;

        private int _materialListIdx = 0;

        void Update()
        {
            if (!hasPrintOnce)
            {
                if (materialList.GetRepairTool(0) == null) { return; }
                currentMaterialEvent.Raise(materialList.GetRepairTool(0));
                hasPrintOnce = true;
            }

            // check if player has released DPAD on joystick
            if(Input.GetAxisRaw("MaterialScrollJoystick") == 0) canScroll = true;

            if (Input.GetButtonDown("MaterialScrollUp") || (Input.GetAxisRaw("MaterialScrollJoystick") == -1 && canScroll))
            {
                _materialListIdx = (_materialListIdx + 1) % materialList.GetListSize();
                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));

                canScroll = false;
            }
            else if (Input.GetButtonDown("MaterialScrollDown") || (Input.GetAxisRaw("MaterialScrollJoystick") == 1 && canScroll))
            {
                _materialListIdx = (_materialListIdx - 1);

                if (_materialListIdx < 0)
                {
                    _materialListIdx = materialList.GetListSize() - 1;
                }

                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));

                canScroll = false;
            }
        }
    }
}
