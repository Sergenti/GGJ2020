using System;
using UnityEngine;

namespace Code.Movement
{
    //This class is likely to be called from an event
    public class SpriteRotate : MonoBehaviour
    {
        [SerializeField] private SpriteMask mask; //We wil scroll the sprite and the mask in opposite directions

        public void Turn(float amount)
        {
            //we scroll the sprite 
            transform.Translate(new Vector3(-amount,0f,0f));
            
            //We scroll the mask in the opposite direction
            if (mask != null)
            {
                mask.transform.Translate(new Vector3(amount,0f));
            }
        }

        private void Update()
        {
            if (transform.position.x > 1.92f)
            {
                transform.SetPositionAndRotation(transform.position- new Vector3(3.84f,0f,0f),Quaternion.identity);
                mask.transform.SetPositionAndRotation(transform.position + new Vector3(1.92f,0f,0f),Quaternion.identity);
            }
            if (transform.position.x < -1.92f)
            {
                transform.SetPositionAndRotation(transform.position- new Vector3(-3.84f,0f,0f),Quaternion.identity);
                mask.transform.SetPositionAndRotation(transform.position + new Vector3(-1.92f,0f,0f),Quaternion.identity);
            }
        }
    }
}
