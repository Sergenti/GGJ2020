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
   
        private int _materialListIdx = 0;

        void Update()
        {
            if (!hasPrintOnce)
            {
                if(materialList.GetRepairTool(0) == null) {return;}
                currentMaterialEvent.Raise(materialList.GetRepairTool(0));
                hasPrintOnce = true;
            }
   
            if (Input.GetButtonDown("MaterialScrollUp"))
            {
                _materialListIdx = (_materialListIdx + 1) % materialList.GetListSize();
                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
            }
            else if (Input.GetButtonDown("MaterialScrollDown"))
            {
                _materialListIdx = (_materialListIdx- 1);
                if (_materialListIdx < 0)
                {
                    _materialListIdx = materialList.GetListSize() - 1;
                }
                currentMaterialEvent.Raise(materialList.GetRepairTool(_materialListIdx));
            }
        }
    }
}
