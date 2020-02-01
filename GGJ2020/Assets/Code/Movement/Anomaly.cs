using Code.Item;
using UnityEngine;

namespace Code.Movement
{
    public class AnomalyType : MonoBehaviour
    {
        [SerializeField] private RepairTool toolToRepair;
        [SerializeField] private RepairMaterial repairMaterial;
        [SerializeField] private SpriteRenderer anomalySprite;
        
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void Repair(RepairTool tool, RepairMaterial material)
        {
            if (tool == toolToRepair && material == repairMaterial)
            {
                Debug.Log("Lel");
            }
        }
    }
}
