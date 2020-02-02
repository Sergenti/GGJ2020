using System.Collections.Generic;
using UnityEngine;

namespace Code.Movement
{
    public class AimAtAnomaly : MonoBehaviour
    {
        public static List<Transform> anomalies = new List<Transform>();
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (anomalies.Count != 0)
            {
               AimAt(anomalies[0].TransformPoint(anomalies[0].position)); 
            }
        }

        private void AimAt(Vector3 targetPosition)
        {
           
        }
    }
}
