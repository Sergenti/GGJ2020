using UnityEngine;

namespace Code.Movement
{
    public class Sprite3DRotate : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteToRender;
        [SerializeField] private float magicNumberSpeed = 150f; //This number is the speed of the rotation, I try to make it synchronized we the rotation of th rocket
        
        void Update()
        {
            //If the sprite is facing us, we render it, otherwise we hide it (by setting it to unactivated)
            if (transform.rotation.eulerAngles.y >= 180)
            {
                  spriteToRender.gameObject.SetActive(false);
            }
            else
            {
                  spriteToRender.gameObject.SetActive(true);
            } 
        }
        
        //This function is likely to be called from an event
        public void RotateSprite(float amount)
        {
            transform.Rotate(0f,amount*magicNumberSpeed,0f); 
        } 
    }
}
