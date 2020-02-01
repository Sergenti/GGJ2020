using Code.Item;
using UnityEngine;

namespace Code.Behaviour
{
    public class AnomalyBehaviour : MonoBehaviour
    {
        [SerializeField] private RepairTool rightTool;
        [SerializeField] private float destroyDelay = 0.2f;

        public bool tryToRepair(RepairTool tool)
        {
            if (tool == rightTool)
            {
               Destroy(this.gameObject,destroyDelay);
               return true;
            }
            return false;
        }
    }
}
