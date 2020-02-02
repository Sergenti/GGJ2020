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
        [Space,Header("Range Events")]
        [SerializeField] private VoidEvent inRangeEvent;
        [SerializeField] private VoidEvent exitRangeEvent;
        [Space]
        [SerializeField] private GetStageType getStageType;
        [Space,Header("Result Events")]
        [SerializeField] private VoidEvent wrongMaterialEvent;
        [SerializeField] private VoidEvent wrongToolEvent;
        [SerializeField] private MaterialEvent repairEvent;

        //Will be updated by two events
        private RepairMaterial currentRepairMaterial;
        private RepairTool currentRepairTool;

        //Get with the getStageType
        private RepairMaterial _rightRepairMaterial;

        // ==== Setters ==== //
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
            // To avoid latter troubles
            if(getStageType == null) {return;}
            if(getStageType.CurrentStage == null) {return;}
            if(getStageType.CurrentStage.stageMaterial == null){return;}
            
            _rightRepairMaterial = getStageType.CurrentStage.stageMaterial;
            
            //Check the repairs, and raise different event depending on the result
            if (Input.GetButtonDown("Interact") && _anomalyInRange != null)
            {
                if (currentRepairMaterial == _rightRepairMaterial)
                {
                    if (_anomalyInRange.tryToRepair(currentRepairTool))
                    {
                        repairEvent.Raise(getStageType.CurrentStage.stageMaterial);
                    }
                    else
                    {
                        wrongToolEvent.Raise(new Void());
                    }
                }
                else
                {
                    wrongMaterialEvent.Raise(new Void());
                }
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
