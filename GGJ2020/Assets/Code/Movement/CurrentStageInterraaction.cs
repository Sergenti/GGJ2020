using System;
using Code.EventSystem.Events;
using UnityEngine;
using Void = Code.EventSystem.Void;

namespace Code.Movement
{
    public class CurrentStageInterraaction : MonoBehaviour
    {
        private RocketStage _currentStage = null;

        [SerializeField] private VoidEvent fallEvent = null;
        

        public void CheckStageFall(RocketStage stage)
        {
            if (stage == _currentStage)
            {
                fallEvent.Raise(new Void());
            }
        }
        
        private void OnTriggerEnter(Collider other)
        {
            RocketStage rocket = other.GetComponent<RocketStage>();
            if (rocket != null && rocket != _currentStage)
            {
                _currentStage = rocket;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            RocketStage rocket = other.GetComponent<RocketStage>();
            if (rocket != null && rocket == _currentStage)
            {
                _currentStage = null;
            }
        }
    }
}
