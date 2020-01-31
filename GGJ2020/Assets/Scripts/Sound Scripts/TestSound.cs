using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioManager Manager;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("AudioManager").GetComponent<AudioManager>().Play();
        Manager.Play("reparation_metal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
