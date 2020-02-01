using System.Collections;
using System.Collections.Generic;
using Code.Movement;
using UnityEngine;

public class Anomaly : MonoBehaviour
{
    [SerializeField] private float magicNumber = 10f;
    [SerializeField] private SpriteRenderer anomalySprite;

    // Update is called once per frame
    void Update()
    {
       if (transform.rotation.eulerAngles.y >= 180)
       {
           anomalySprite.gameObject.SetActive(false);
       }
       else
       {
           anomalySprite.gameObject.SetActive(true);
       } 
    }

    public void RotateSprite(float amount)
    {
       transform.Rotate(0f,amount*magicNumber,0f); 
    }
}
