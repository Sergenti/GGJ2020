using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed, 0);
    }

    void Start()
    {
        // destroy the star when it's leaving the screen, but since I'm shit at coding
        // just destroy it in 2 seconds
        Destroy(gameObject, 2);
    }
}
