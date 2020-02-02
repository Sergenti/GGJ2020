using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRotate : MonoBehaviour
{
    [SerializeField] private float speedMutliplier = 0.5f;
    [SerializeField] private float valiueDeSesMorts = 3f;

    public void Turn(float ammount)
    {
        transform.Translate(new Vector3(-ammount*speedMutliplier,0f,0f));
    }
    
    private void Update()
    {
        if (transform.position.x > valiueDeSesMorts)
        {
            transform.SetPositionAndRotation(transform.position - new Vector3(2*valiueDeSesMorts, 0f, 0f), Quaternion.identity);
        }

        if (transform.position.x< -valiueDeSesMorts)
        {
            transform.SetPositionAndRotation(transform.position - new Vector3(-2*valiueDeSesMorts, 0f, 0f), Quaternion.identity);
        }
    }
} 
