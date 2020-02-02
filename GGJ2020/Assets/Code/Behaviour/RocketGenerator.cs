using System.Collections;
using System.Collections.Generic;
using Code.Difficulty;
using Code.Events;
using Code.Movement;
using UnityEngine;

namespace Code.Behaviour
{
    public class RocketGenerator : MonoBehaviour
    {
        
        [SerializeField] private List<GameObject> objPossible = new List<GameObject>();
        [SerializeField] private int amount = 4;
        [SerializeField] private float SIZE = 1f;
        
        public List<GameObject> stages = new List<GameObject>();
        public List<GameObject> anomalies = new List<GameObject>();
        public DifficultyIncrease diff;
        public List<Sprite> fuelSprites = new List<Sprite>();
        public SpriteEvent fuelUpdater;


        private float timeAmount;

        private int oldIndex = 8;
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < amount; i++)
            {
                int type = Random.Range(0, objPossible.Count);
                var newRocket = Instantiate(objPossible[type], new Vector3(0f, i * SIZE, 0f), Quaternion.identity);
                stages.Add(newRocket);
            }
            
            diff.Reset();
            timeAmount = diff.Fuel;
            StartCoroutine(Timer(diff.Fuel));
            StartCoroutine(Spread());
        }

        // Update is called once per frame
        void Update()
        {
            timeAmount -= Time.deltaTime;
            float percentage = timeAmount / diff.Fuel;
            int spriteIdx = (int) (8 * percentage);
            if (spriteIdx < oldIndex)
            {
                fuelUpdater.Raise(fuelSprites[spriteIdx]);
                oldIndex = spriteIdx;
            }
        }

        private void ChangeStage()
        {
           diff.IncreaseDifficulty();
           oldIndex = 8;
           timeAmount = diff.Fuel;
           StartCoroutine(Timer(diff.Fuel));
        }

        private void GenerateAnomaly()
        {
           stages[0].GetComponent<StageBehaviour>().GenerateAnomaly(diff.AnomalyDuration);
           StartCoroutine(Spread());
        }

        private IEnumerator Timer(float duration)
        {
            yield return new WaitForSeconds(duration);
            stages[0].GetComponent<StageBehaviour>().MakeOwnStageFall();
            stages[0].GetComponent<FallEntity>().Fall();
            stages.RemoveAt(0);
            ChangeStage();
        }

        private IEnumerator Spread()
        {
            yield return new WaitForSeconds(diff.AnomalyApparition);
            GenerateAnomaly();
        }
    }
}
