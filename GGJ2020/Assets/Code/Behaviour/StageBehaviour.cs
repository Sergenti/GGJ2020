using System;
using Code.EventSystem.Events;
using Code.Movement;
using UnityEngine;

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
            foreach (FallEntity faller in GetComponentsInChildren(typeof(FallEntity)))
            {
                faller.Fall();
            } 
            fallEvent.Raise(transitionLocation.position.y + transform.position.y);
        }
    }
}