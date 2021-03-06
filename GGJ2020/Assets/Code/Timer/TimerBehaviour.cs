using Code.Difficulty;
using UnityEngine;
using UnityEngine.Events;

namespace Code.Timer
{
    public class TimerBehaviour : MonoBehaviour
    {
        public float duration = 1f;
        [SerializeField] private UnityEvent onTimerEnd = null;

        private Timer timer;
        private DifficultyIncrease diff;

        public DifficultyIncrease Diff
        {
            set => diff = value;
        }

        private void Start()
        {
            // Create a new timer and initialise it
            timer = new Timer(duration);

            // Subscribe to the OnTimerEnd event to be able to handle that scenario
            timer.OnTimerEnd += HandleTimerEnd;
        }

        private void HandleTimerEnd()
        {
            // Alert any listeners that the timer has ended
            onTimerEnd.Invoke();

            // Remove this component
            // (Subject to change if I end up deciding that there is a better way to handle the timer ending)
            Destroy(this);
        }

        private void Update() => timer.Tick(Time.deltaTime);
    }
}