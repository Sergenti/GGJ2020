using Code.Item;
using UnityEngine;

namespace Code.Behaviour
{
    public class AnomalyBehaviour : MonoBehaviour
    {
        [SerializeField] private RepairTool rightTool;

        

        public bool tryToRepair(RepairTool tool)
        {
            if (tool == rightTool)
            {
                
            }
            return false;
        }
    }
}
