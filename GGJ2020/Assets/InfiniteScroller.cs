using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 3.8f)
        {
            transform.SetPositionAndRotation(transform.position - new Vector3(0.5f,0,0),Quaternion.identity);
        }

    }
}
