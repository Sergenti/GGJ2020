using Code.Movement;
using UnityEngine;

namespace Code.Behaviour
{
    public class StageFallBehaviour : MonoBehaviour
    {
        public FallEntity fe;

        public void CheckFall(float high)
        {
            if (high >= transform.TransformPoint(transform.position).y)
            {
                fe.Fall();
            }
        }
    }
}