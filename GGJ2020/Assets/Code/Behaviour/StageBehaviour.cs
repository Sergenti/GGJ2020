using System;
using Code.Movement;
using UnityEngine;

namespace Code.Behaviour
{
    public class StageBehaviour : MonoBehaviour
    {
        [SerializeField] private Transform transitionLocation;
        [SerializeField] private Transform engineLocation;
        [SerializeField] private GameObject stagePortion;

        private float distance;
        private void Start()
        {
            distance = Vector3.Distance(transitionLocation.position, engineLocation.position);
            int nbrOfCut = (int) (distance / 0.64);
            for (int i = 1; i <= nbrOfCut; i++)
            {
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
        }
    }
}