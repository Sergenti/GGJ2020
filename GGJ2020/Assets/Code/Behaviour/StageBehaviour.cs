using Code.Movement;
using UnityEngine;

namespace Code.Behaviour
{
    public class StageBehaviour : MonoBehaviour
    {

        public void  MakeNextStageFall()
        {
            GameObject stageTodrop = null;
            float previousHeight = 99999999f;
            foreach (var obj in GameObject.FindGameObjectsWithTag("Stage"))
            {
                if (obj.transform.position.y < previousHeight)
                {
                    stageTodrop = obj;
                    previousHeight = obj.transform.position.y;
                }
            }
            
            if(stageTodrop == null){return;}

            stageTodrop.GetComponent<FallEntity>().Fall();
        }
    }
}
