using System.Collections;
using Code.EventSystem.Events;
using Code.Item;
using UnityEngine;
using Void = Code.EventSystem.Void;

namespace Code.Behaviour
{
    public class AnomalyBehaviour : MonoBehaviour
    {
        [SerializeField] private RepairTool rightTool;
        [SerializeField] private float destroyDelay = 0.2f; //This delay is here to avoir a glitch where it was not destroying
        [SerializeField] private float durationTime = 10f;
        [SerializeField] private VoidEvent destroyEvent;

        public float DurationTime
        {
            get => durationTime;
            set => durationTime = value;
        }

        private void Start()
        {
            StartCoroutine(Destroy(durationTime));
        }

        //Check if the we try to repair with the right tool
        public bool tryToRepair(RepairTool tool)
        {
            if (tool == rightTool)
            {
               Destroy(this.gameObject,destroyDelay);
               return true;
            }
            return false;
        }

        private IEnumerator Destroy(float time)
        {
            yield return new WaitForSeconds(time);
            destroyEvent.Raise(new Void());
        }
    }
}
