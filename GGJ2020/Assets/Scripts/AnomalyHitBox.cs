using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this code is to make a collider wollows a sprite which is in 3d rotation (We place
//the collider on the projection of the sprite on the 2d plane (the sprite is in the 3 dimensions)
public class AnomalyHitBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteToFollow;
    [SerializeField] private Collider2D collider;
    
    void Update()
    {
        //Follow when the sprite is visible
        if (spriteToFollow != null && spriteToFollow.gameObject.active)
        {
            collider.enabled = true;
            collider.transform.position = new Vector3(spriteToFollow.transform.position.x, 0f,0f);
        } //Disable the collider if the sprite is disabled (when it's behind the rocket)
        else if(!spriteToFollow.gameObject.active)
        {
            collider.enabled = false;
        }
    }
}
