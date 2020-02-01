using System.Collections;
using Code.Difficulty;
using Code.Movement;
using Code.Timer;
using UnityEngine;

namespace Code.Behaviour
{
    public class StageBehaviourFaller : MonoBehaviour
    {
        [SerializeField]
        private DifficultyIncrease diff;


        private void Start()
        {
           diff.Reset();
           StartCoroutine(Timer(diff.Fuel));
        }

        private void IncreaseDiff()
        {
            diff.IncreaseDifficulty();
            StartCoroutine(Timer(diff.Fuel));
        }

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
            stageTodrop.GetComponent<StageBehaviour>().MakeOwnStageFall();
        }

        private IEnumerator Timer(float duration)
        {
           yield return new WaitForSeconds(duration);
           MakeNextStageFall();
           IncreaseDiff();
        }
    }
}
