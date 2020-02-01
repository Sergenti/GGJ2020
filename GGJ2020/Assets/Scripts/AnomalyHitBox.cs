using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyHitBox : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteToFollow;
    [SerializeField] private Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spriteToFollow != null && spriteToFollow.gameObject.active)
        {
            collider.enabled = true;
            collider.transform.position = new Vector3(spriteToFollow.transform.position.x, 0f,0f);
        }
        else if(!spriteToFollow.gameObject.active)
        {
            collider.enabled = false;
        }
    }
}
