using System;
using System.Collections;
using System.Collections.Generic;
using Code.Difficulty;
using Code.Events;
using Code.EventSystem.Events;
using Code.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Behaviour
{
    public class StageBehaviour : MonoBehaviour
    {
        [Space,Header("Beginning and ending location")]
        [SerializeField] private Transform transitionLocation;
        [SerializeField] private Transform engineLocation;
        [Space]
        [SerializeField] private GameObject stagePortion; //Gameobject to serialize
        [Space]
        [SerializeField] private FloatEvent fallEvent;
        [Space]
        [SerializeField] private List<GameObject> anomalyList = new List<GameObject>();

        [SerializeField] private float margin = 0.5f;



        

        

        private void Start()
        {
            // Compute the number of asset we can place between start and end
            int nbrOfCut = (int) (Vector3.Distance(transitionLocation.position, engineLocation.position) / 0.64);
            for (int i = 1; i <= nbrOfCut; i++)
            {
                //Generate stage portion and set them as children
                var obj = Instantiate(stagePortion, transitionLocation.position + new Vector3(0f,-i* 0.64f,0f), Quaternion.identity);
                obj.transform.SetParent(transform); 
            }
        }

        
        public void MakeOwnStageFall()
        {
            fallEvent.Raise(transitionLocation.TransformPoint(transitionLocation.position).y);
            /**foreach (FallEntity faller in GetComponentsInChildren(typeof(FallEntity)))
            {
                faller.Fall();
            } **/
        }

        

        public void GenerateAnomaly(float persistence)
        {
            int idx = Random.Range(0, anomalyList.Count);
            float position = Random.Range(engineLocation.position.y + margin, transitionLocation.position.y - margin);
            float rotation = Random.Range(0, 360f);

            GameObject newAnomaly = Instantiate(anomalyList[idx], new Vector3(0f, position, 0f), Quaternion.identity);
            newAnomaly.transform.SetParent(transform); 
            //newAnomaly.GetComponentInChildren(typeof(Transform)).transform.Rotate(Vector3.up,rotation);
            newAnomaly.GetComponent<AnomalyBehaviour>().DurationTime = persistence;
        }
    }
}