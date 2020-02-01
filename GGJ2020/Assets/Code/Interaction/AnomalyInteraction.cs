using Code.Behaviour;
using Code.EventSystem;
using Code.EventSystem.Events;
using Code.Item;
using UnityEngine;

namespace Code.Interaction
{
    public class AnomalyInteraction : MonoBehaviour
    {
        [SerializeField] private LayerMask anomalyMask;
        [SerializeField] private Collider2D detectionArea;
        [SerializeField] private VoidEvent inRangeEvent;

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
            //If we have an anomaly in range we raise the in range event
            if (_anomalyInRange != null)
            {
                inRangeEvent.Raise(new Void());
            }

            if (Input.GetButtonDown("Interact") && _anomalyInRange != null)
            {
                _anomalyInRange.tryToRepair(currentRepairMaterial,currentRepairTool);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            //If a new anomaly is in range, "focus" on it
            AnomalyBehaviour anomaly = other.GetComponent<AnomalyBehaviour>();
            if (anomaly != null && anomaly != _anomalyInRange)
            {
                _anomalyInRange = anomaly;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            //If the anomaly is out of range, remove it from our "focus"
            AnomalyBehaviour anomaly = other.GetComponent<AnomalyBehaviour>();
            if (anomaly != null && anomaly == _anomalyInRange)
            {
                _anomalyInRange = null;
            }
        }
    }
}
