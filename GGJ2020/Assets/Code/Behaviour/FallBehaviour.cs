using Code.EventSystem;
using Code.EventSystem.Events;
using UnityEngine;

namespace Code.Behaviour
{
    public class FallBehaviour : MonoBehaviour
    {
        [SerializeField] private VoidEvent deathFallEvent; 

        //Fall if under the top of the stage who's falling
        public void CheckFallDeath(float high)
        {
            if (high >= transform.TransformPoint(transform.position).y)
            {
                deathFallEvent.Raise(new Void());
            }
        }
    }
}
