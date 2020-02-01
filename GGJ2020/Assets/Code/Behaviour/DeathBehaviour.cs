using Code.EventSystem;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Behaviour
{
    public class DeathBehaviour : MonoBehaviour
    {
        [SerializeField] private VoidEvent deathFallEvent; 
        // Start is called before the first frame update
        

        public void CheckFallDeath(float high)
        {
            Debug.Log(high);
            if (high > transform.position.y)
            {
                deathFallEvent.Raise(new Void());
            }
        }
    }
}
