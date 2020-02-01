using System;
using Code.Behaviour;
using Code.EventSystem.Events;
using Code.Item;
using UnityEngine;
using Void = Code.EventSystem.Void;

namespace Code.Interaction
{
    public class AnomalyInteraction : MonoBehaviour
    {
        [SerializeField] private VoidEvent inRangeEvent;
        [SerializeField] private VoidEvent exitRangeEvent;
        [SerializeField] private GetStageType getStageType;

        [SerializeField] private VoidEvent wrongMaterialEvent;
        [SerializeField] private VoidEvent wrongToolEvent;
        [SerializeField] private VoidEvent repairEvent;

        private RepairMaterial currentRepairMaterial;
        private RepairTool currentRepairTool;

        private RepairMaterial _rightRepairMaterial;

        public RepairMaterial CurrentRepairMaterial
        {
            set => currentRepairMaterial = value;
        }

        public RepairTool CurrentRepairTool
        {
            set => currentRepairTool = value;
        }

        private AnomalyBehaviour _anomalyInRange;

        private void Start()
        {
            getStageType = GetComponent<GetStageType>();
        }


        void Update()
        {
            if(getStageType.CurrentStage == null) {return;}
            _rightRepairMaterial = getStageType.CurrentStage.stageMaterial;
            if (Input.GetButtonDown("Interact") && _anomalyInRange != null && currentRepairMaterial == _rightRepairMaterial)
            {
                if (_anomalyInRange.tryToRepair(currentRepairTool))
                {
                   repairEvent.Raise(new Void()); 
                }
                else
                {
                   wrongToolEvent.Raise(new Void()); 
                }
            }
            else if (currentRepairMaterial != _rightRepairMaterial && Input.GetButtonDown("Interact"))
            {
                wrongMaterialEvent.Raise(new Void()); 
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
