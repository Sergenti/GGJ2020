using UnityEngine;

namespace Code.Interaction
{
    public class GetStageType : MonoBehaviour
    {
        private StageType _currentStageType;

        public StageType CurrentStage
        {
            get => _currentStageType;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            //New stage, "focus" on it
            StagePortionDisplay stageDisplay = other.GetComponentInChildren<StagePortionDisplay>();
            
            if(stageDisplay == null){return;}
            
            StageType stage = stageDisplay.StageType; 
            if (stage != null && stage != _currentStageType)
            {
                _currentStageType = stage;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            //If the stage is out of range, remove it from our "focus"
            StageType stage = other.GetComponentInChildren<StagePortionDisplay>().StageType;
            if (stage != null && stage == _currentStageType)
            {
                _currentStageType = null;
            }
        }
    }
}