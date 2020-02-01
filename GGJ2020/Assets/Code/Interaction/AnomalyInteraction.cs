using Code.Behaviour;
using Code.EventSystem;
using Code.EventSystem.Events;
using Code.Item;
using UnityEngine;

namespace Code.Interaction
{
    public class AnomalyInteraction : MonoBehaviour
    {
        [SerializeField] private VoidEvent inRangeEvent;
        [SerializeField] private VoidEvent exitRangeEvent;

        private RepairMaterial currentRepairMaterial;
        private RepairTool currentRepairTool;

        public RepairMaterial CurrentRepairMaterial
        {
            set => currentRepairMaterial = value;
        }

        public RepairTool CurrentRepairTool
        {
            set => currentRepairTool = value;
        }

        private AnomalyBehaviour _anomalyInRange;


        void Update()
        {
            if (Input.GetButtonDown("Interact") && _anomalyInRange != null)
            {
                _anomalyInRange.tryToRepair(currentRepairMaterial,currentRepairTool);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            //If a new anomaly is in range, "focus" on it
            AnomalyBehaviour anomaly = other.GetComponentInParent<AnomalyBehaviour>();
            if (anomaly != null && anomaly != _anomalyInRange)
            {
                _anomalyInRange = anomaly;
                inRangeEvent.Raise(new Void());
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //If the anomaly is out of range, remove it from our "focus"
            AnomalyBehaviour anomaly = other.GetComponentInParent<AnomalyBehaviour>();
            if (anomaly != null && anomaly == _anomalyInRange)
            {
                _anomalyInRange = null;
                exitRangeEvent.Raise(new Void());
            }
        }
    }
}
